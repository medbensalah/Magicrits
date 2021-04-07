using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpraySkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public SpraySkill()
    {
        // Magical Attack Skill
        MASkill maSkill = new MASkill(val, acc);
        skills.Add(maSkill);
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
