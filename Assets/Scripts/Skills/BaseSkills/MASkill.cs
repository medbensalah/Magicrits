using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASkill :  ISkill
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
            //calculating damage
            //damage is at least 1
            int damage = (caster.MagicAttack + skillValue < target.MagicDefense) ?
                1 : caster.MagicAttack + skillValue - target.MagicDefense;
            int randomizer = Random.Range(-damage / 10, damage / 10);
            damage = (caster.MagicAttack + skillValue < target.MagicDefense + randomizer) ?
                1 : caster.MagicAttack + skillValue - target.MagicDefense + randomizer;

            //TODO animation
            target.TakeDamage(damage, caster.CritType);
            return;
        }
        target.miss();
    }
}

