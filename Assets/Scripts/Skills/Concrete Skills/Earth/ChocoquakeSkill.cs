using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoquakeSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public ChocoquakeSkill()
    {
        // Magic Attack Skill
        MASkill maSkill = new MASkill(val, acc);
        skills.Add(maSkill);

        // Chance of Sleep Skill
        SleepSkill sleepSkill = new SleepSkill(2, 30);
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
