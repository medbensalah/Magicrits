using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidowmakerSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public WidowmakerSkill()
    {
        // Magic Damage Skill
        skills.Add(new MASkill(val, 100));

        // Physical Attack Skill
        skills.Add(new PADebuffSkill(7, 30));
        // Magic Attack Skill
        skills.Add(new MADebuffSkill(7, 30));

        // Physical Denfense Skill
        skills.Add(new PADebuffSkill(7, 30));
        // Magic Denfense Skill
        skills.Add(new MADebuffSkill(7, 30));

        // Speed Skill
        skills.Add(new SpeedDebuffSkill(10, 30));

        // Accurac Skill
        skills.Add(new AccuracyDebuffSkill(10, 30));

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
