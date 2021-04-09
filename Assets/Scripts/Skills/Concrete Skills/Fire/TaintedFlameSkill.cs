using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaintedFlameSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public TaintedFlameSkill()
    {
        // Magic Damage Skill
        skills.Add(new MASkill(25, 95));

        // Heal Skill
        skills.Add(new HealSkill(20, 100));
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
