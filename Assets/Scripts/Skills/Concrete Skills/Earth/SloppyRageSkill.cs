using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SloppyRageSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public SloppyRageSkill()
    {
        // Physical Defense Skill
        skills.Add(new PDDebuffSkill(7, 100));

        // Magic Defense Skill
        skills.Add(new MDDebuffSkill(7, 100));

        // Physical Attack Skill
        skills.Add(new PABuffSkill(14, 100));

        // Magic Attack Skill
        skills.Add(new MABuffSkill(14, 100));

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
