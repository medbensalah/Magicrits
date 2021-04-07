using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASkill : MonoBehaviour, ISkill
{
    public int skillValue;          //base skill value
    public string description;      //skill description
    public int accuracy;            //base skill accuracy

    public MASkill(int val, int acc = 100, string desc = null)
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
            //calculating damage
            //damage is at least 1
            int damage = (caster.MagicAttack + skillValue < target.MagicDefense) ?
                1 : caster.MagicAttack + skillValue - target.MagicDefense;
            //TODO animation
            target.TakeDamage(damage);
        }
        target.miss();
    }
}

