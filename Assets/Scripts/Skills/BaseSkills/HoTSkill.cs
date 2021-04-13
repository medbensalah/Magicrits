using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoTSkill : MonoBehaviour, ISkill
{
    public int skillValue;          //base skill value
    public int accuracy;            //base skill accuracy
    public int turns;               //base skill number of turns
    public HoTSkill(int val, int acc = 100, int t = 3)
    {
        skillValue = val;
        accuracy = acc;
        turns = t;
    }

    public void execute(Crit caster, Crit target)
    {
        //calculating the final value of the skill accuracy
        int random = Random.Range(0, 10000);
        if (random <= accuracy * caster.Accuracy)    //if the skill hits the target
        {
            //TODO animation
            target.InflictHoT(skillValue, turns);
            return;
        }
        target.miss();
    }
}
