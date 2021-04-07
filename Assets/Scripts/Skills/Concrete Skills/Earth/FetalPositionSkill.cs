using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FetalPositionSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public FetalPositionSkill()
    {
        // Speed Skill
        SpeedDebuffSkill speeddebuffSkill = new SpeedDebuffSkill(val, acc);
        skills.Add(speeddebuffSkill);

        // Accuracy Skill
        AccuracyDebuffSkill accuracydebuffSkill = new AccuracyDebuffSkill(val, acc);
        skills.Add(accuracydebuffSkill);
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
