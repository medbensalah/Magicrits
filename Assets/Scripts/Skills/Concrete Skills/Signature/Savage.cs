﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savage : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;
    public SkillType type;

    public Savage()
    {
        // Magic Attack Skill
        skills.Add(new PASkill(val, acc));  
        skills.Add(new PABuffSkill(2, acc));
        skills.Add(new MABuffSkill(2, acc));
        skills.Add(new HealSkill(20, acc));
    }

    //skill execution
    public void execute(Crit caster, Crit target)
    {
        foreach (ISkill skill in skills)
        {
            //executing all base skills
            skill.execute(caster, target);
        }
    }
}
