﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison_STD : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int turns;
    public int acc;
    public SkillType type;

    public Poison_STD()
    {
        // Putting enemy to sleep
        skills.Add(new PoisonSkill(val, acc, turns));
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