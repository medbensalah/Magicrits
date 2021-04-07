using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public SleepingSkill()
    {
        // Sleep (2 turns) Skill
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
