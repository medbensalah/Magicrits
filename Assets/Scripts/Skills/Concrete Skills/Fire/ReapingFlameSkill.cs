using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReapingFlameSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public ReapingFlameSkill()
    {
        // Magic Damage Skill
        skills.Add(new MASkill(val, acc));

        // Wreak Havoc
        //TODO Wreak Havoc

        skills.Add(new PADebuffSkill(3, 100));
        skills.Add(new MADebuffSkill(3, 100));
        skills.Add(new PDDebuffSkill(3, 100));
        skills.Add(new MDDebuffSkill(3, 100));

        skills.Add(new SpeedDebuffSkill(5, 100));
        skills.Add(new AccuracyDebuffSkill(3, 100));
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
