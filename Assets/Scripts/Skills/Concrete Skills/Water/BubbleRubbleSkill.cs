using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleRubbleSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public BubbleRubbleSkill()
    {
        // Magical Attack Skill
        skills.Add(new MASkill(6, 95));
        // Magical Attack Skill
        skills.Add(new MASkill(7, 95));
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
