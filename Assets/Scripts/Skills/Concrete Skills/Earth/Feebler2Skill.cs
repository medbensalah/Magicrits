using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feebler2Skill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public Feebler2Skill()
    {
        // Physical Attack Skill
        PADebuffSkill padebuffSkill = new PADebuffSkill(val, acc);
        skills.Add(padebuffSkill);

        // Magical Attack Skill
        MADebuffSkill madebuffSkill = new MADebuffSkill(val, acc);
        skills.Add(madebuffSkill);

        // Physical Defense Skill
        PDDebuffSkill pddebuffSkill = new PDDebuffSkill(val, acc);
        skills.Add(pddebuffSkill);

        // Magical Defense Skill
        MDDebuffSkill mddebuffSkill = new MDDebuffSkill(val, acc);
        skills.Add(mddebuffSkill);

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
