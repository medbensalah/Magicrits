﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public BarrageSkill()
    {
        // Multiple Physical Attack Skill
        for (int i = 0; i < 10; i++)
            skills.Add(new PASkill(val, acc));

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