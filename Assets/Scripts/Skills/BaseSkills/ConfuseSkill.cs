using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfuseSkill : MonoBehaviour, ISkill
{
    public int skillValue;          //base skill value
    public int accuracy;            //base skill accuracy

    public void init(int val, int acc = 100)
    {
        skillValue = val;
        accuracy = acc;
    }
    public void execute(Crit caster, Crit target)
    {
        //calculating the final value of the skill accuracy
        int random = Random.Range(0, 10000);
        if (random <= accuracy * caster.Accuracy)    //if the skill hits the target
        {
            //confuse the target
            //TODO animation
            target.InflictConfuse(skillValue);
            return;
        }
        target.miss();
    }
}