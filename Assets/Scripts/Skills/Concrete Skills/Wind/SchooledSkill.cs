using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchooledSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public SchooledSkill()
    {
        // Physical Damage Skill
        skills.Add(new PASkill(25, acc));

        // Physical Defense Skill
        skills.Add(new PDDebuffSkill(10, acc));
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
