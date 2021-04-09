using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisdirectionSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public MisdirectionSkill()
    {
        // Physical Attack Skill
        skills.Add(new PADebuffSkill(val, acc));
        // Physical Defense Skill
        skills.Add(new PDDebuffSkill(val, acc));
        // Magic Attack Skill
        skills.Add(new MADebuffSkill(val, acc));
        // Magic Defense Skill
        skills.Add(new MDDebuffSkill(val, acc));
        // Accuracy Skill
        skills.Add(new AccuracyDebuffSkill(5, acc));
        // Speed Skill
        skills.Add(new SpeedDebuffSkill(10, acc));
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
