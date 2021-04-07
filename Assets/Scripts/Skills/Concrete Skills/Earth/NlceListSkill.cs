using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NlceListSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public NlceListSkill()
    {
        // Physical Attack Skill
        PABuffSkill pabuffSkill = new PABuffSkill(val, acc);
        skills.Add(pabuffSkill);

        // Magical Attack Skill
        MABuffSkill mabuffSkill = new MABuffSkill(val, acc);
        skills.Add(mabuffSkill);

        // Physical Defense Skill
        PDBuffSkill pdbuffSkill = new PDBuffSkill(val, acc);
        skills.Add(pdbuffSkill);

        // Magical Defense Skill
        MDBuffSkill mdbuffSkill = new MDBuffSkill(val, acc);
        skills.Add(mdbuffSkill);

        // Speed Skill
        SpeedBuffSkill speedbuffSkill = new SpeedBuffSkill(val, acc);
        skills.Add(speedbuffSkill);

        // Accuracy Skill
        AccuracyBuffSkill accuracybuffSkill = new AccuracyBuffSkill(val, acc);
        skills.Add(accuracybuffSkill);
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
