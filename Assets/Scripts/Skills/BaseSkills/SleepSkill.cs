using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepSkill : MonoBehaviour, ISkill
{
    public int skillValue;          //base skill value
    public string description;      //skill description
    public int accuracy;            //base skill accuracy

    public SleepSkill(int val = 2, int acc = 50, string desc = null)
    {
        skillValue = val;
        accuracy = acc;
        description = desc;
    }

    public void execute(Crit caster, Crit target)
    {
        //calculating the final value of the skill accuracy
        int random = Random.Range(0, 10000);
        if (random <= accuracy * caster.Accuracy)    //if the skill hits the target
        {
            //put the target to sleep
            //TODO animation
            target.InflictSleep(skillValue);
        }
        target.miss();
    }
}

