﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarHighSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public SugarHighSkill()
    {
        // Confuse Skill
        ConfuseSkill confuseSkill = new ConfuseSkill(val, acc);
        skills.Add(confuseSkill);
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
