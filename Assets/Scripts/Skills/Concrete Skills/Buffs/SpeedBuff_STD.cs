﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff_STD : MonoBehaviour, ISkill
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;
    public SkillType type;

    public SpeedBuff_STD()
    {
        // Putting enemy to sleep
        skills.Add(new SpeedBuffSkill(val, acc));
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
