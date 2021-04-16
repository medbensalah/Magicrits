using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreakHavoc : MonoBehaviour, ISkill
{
    //skill's base accuracy
    public int accuracy;

    public void init(int acc = 100)
    {
        accuracy = acc;
    }

    public void execute(Crit caster, Crit target)
    {
        int random = Random.Range(0, 10000);            //calculating skill success probability
        if (random <= accuracy * caster.Accuracy)       //deciding if the skill is gonna success
        {
            //TODO animation
            target.DecreasePA(7);
            target.DecreaseMA(7);
            target.DecreasePD(7);
            target.DecreaseMD(7);
            target.DecreaseSpeed(20);
            target.DecreaseAccuracy(10);
            return;
        }
        target.miss();
    }
}
