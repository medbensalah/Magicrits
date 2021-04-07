using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MercilessSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public MercilessSkill()
    {
        // Physical Attack Skill
        PABuffSkill paBuffSkill = new PABuffSkill(val, acc);
        skills.Add(paBuffSkill);

        // Elemental Attack Skill
        MABuffSkill maBuffSkill = new MABuffSkill(val, acc);
        skills.Add(maBuffSkill);
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
