﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBarrageSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public BoulderBarrageSkill()
    {
        // Multiple Magic Attack Skill
        skills.Add(new MASkill(val, acc));
        skills.Add(new MASkill(val, acc));
        skills.Add(new MASkill(val, acc));
        skills.Add(new MASkill(val, acc));

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
