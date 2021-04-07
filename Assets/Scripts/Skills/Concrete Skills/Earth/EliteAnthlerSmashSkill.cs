using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteAnthlerSmashSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public EliteAnthlerSmashSkill()
    {
        // Physical Attack Skill
        PASkill paSkill1 = new PASkill(val, acc);
        skills.Add(paSkill1);


        // Physical Attack Skill
        PASkill paSkill2 = new PASkill(val, acc);
        skills.Add(paSkill2);
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
