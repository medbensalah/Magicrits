using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnbreakableSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public UnbreakableSkill()
    {
        // Physical Defense Skill
        PDBuffSkill pdbuffSkill = new PDBuffSkill(val, acc);
        skills.Add(pdbuffSkill);

        // Magical Defense Skill
        MDBuffSkill mdbuffSkill = new MDBuffSkill(val, acc);
        skills.Add(mdbuffSkill);
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
