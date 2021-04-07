using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistOfFurySkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public FistOfFurySkill()
    {
        // Physical Attack Skill
        PASkill paSkill1 = new PASkill(val, acc);
        skills.Add(paSkill1);

        // Physical Attack Skill
        PASkill paSkill2 = new PASkill(val, acc);
        skills.Add(paSkill2);

        // Physical Attack Skill
        PASkill paSkill3 = new PASkill(val, acc);
        skills.Add(paSkill3);

        // Physical Attack Skill
        PASkill paSkill4 = new PASkill(val, acc);
        skills.Add(paSkill4);
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
