﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedDebuffSkill : MonoBehaviour, ISkill
{
    //skill's base value
    public int skillValue;
    //skill's effect description
    public string description;
    //skill's base accuracy
    public int accuracy;

    public SpeedDebuffSkill(int val, int acc = 100, string desc = null)
    {
        skillValue = val;
        accuracy = acc;
        description = desc;
    }

    public void execute(Crit caster, Crit target)
    {
        int random = Random.Range(0, 10000);            //calculating skill success probability
        if (random <= accuracy * caster.Accuracy && target.Speed - skillValue > 0)       //deciding if the skill is gonna success
        {                                                                                //speed must be positive
            //TODO animation
            target.DecreaseSpeed(skillValue);
        }
        target.miss();
    }
}
