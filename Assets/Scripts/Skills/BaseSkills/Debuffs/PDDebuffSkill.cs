﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PDDebuffSkill : MonoBehaviour, ISkill
{
    //skill's base value
    public int skillValue;
    //skill's base accuracy
    public int accuracy;

    public PDDebuffSkill(int val, int acc = 100)
    {
        skillValue = val;
        accuracy = acc;
    }

    public void execute(Crit caster, Crit target)
    {
        int random = Random.Range(0, 10000);            //calculating skill success probability
        if (random <= accuracy * caster.Accuracy)       //deciding if the skill is gonna success
        {
            //TODO animation
            target.DecreasePD(skillValue);
            return;
        }
        target.miss();
    }
}
