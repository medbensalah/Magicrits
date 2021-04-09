using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteGnashingSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public EliteGnashingSkill()
    {
        // Physical Attack Skill
          skills.Add(new PASkill(val, acc));
        // Physical Attack Skill
        skills.Add(new PABuffSkill(val, acc));
        // Heal Skill
        skills.Add(new HealSkill(val, acc));

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
