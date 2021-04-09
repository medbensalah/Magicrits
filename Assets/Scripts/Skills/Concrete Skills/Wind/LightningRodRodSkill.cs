﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningRodRodSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public LightningRodRodSkill()
    {
        // Physical Damage Skill
        skills.Add(new PASkill(20, acc));

        // Physical Damage Buff Skill
        skills.Add(new PABuffSkill(7, acc));
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