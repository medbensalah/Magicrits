using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurendelSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public DurendelSkill()
    {
        // Physical Damage Skill
        skills.Add(new PABuffSkill(val, acc));

        // Physical Defense Skill
        skills.Add(new PDDebuffSkill(val, acc));
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
