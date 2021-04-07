﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetalPosition2Skill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public FetalPosition2Skill()
    {
        // Physical Attack Skill
        PADebuffSkill padebuffSkill = new PADebuffSkill(val, acc);
        skills.Add(padebuffSkill);

        // Magical Attack Skill
        MADebuffSkill madebuffSkill = new MADebuffSkill(val, acc);
        skills.Add(madebuffSkill);
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
