using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShielsUpSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public ShielsUpSkill()
    {
        // Physical Attack Skill
        PABuffSkill pabuffSkill = new PABuffSkill(6, 100);
        skills.Add(pabuffSkill);

        // Magical Attack Skill
        MABuffSkill mabuffSkill = new MABuffSkill(6, 100);
        skills.Add(mabuffSkill);
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
