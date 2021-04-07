using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPlanSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public FlightPlanSkill()
    {
        // Magical Attack Skill
        MASkill maSkill = new MASkill(val, acc);
        skills.Add(maSkill);

        // Physical Attack Skill
        PABuffSkill pabuffSkill = new PABuffSkill(val, acc);
        skills.Add(pabuffSkill);

        // Physical Defense Skill
        PDDebuffSkill pddebuffSkill = new PDDebuffSkill(val, acc);
        skills.Add(pddebuffSkill);

        // Sleep Skill
        SleepSkill sleepSkill = new SleepSkill(val, acc);
        skills.Add(sleepSkill);
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
