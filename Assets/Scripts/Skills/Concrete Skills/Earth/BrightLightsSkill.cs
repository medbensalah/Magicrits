using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightLightsSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public BrightLightsSkill()
    {
        // Physical Attack Skill
        PADebuffSkill padebuffSkill = new PADebuffSkill(val, acc);
        skills.Add(padebuffSkill);

        // Magic Attack Skill
        MADebuffSkill madebuffSkill = new MADebuffSkill(val, acc);
        skills.Add(madebuffSkill);

        // Physical Defense Skill
        PDDebuffSkill pddebuffSkill = new PDDebuffSkill(val, acc);
        skills.Add(pddebuffSkill);

        // Magic Defense Skill
        MDDebuffSkill mddebuffSkill = new MDDebuffSkill(val, acc);
        skills.Add(mddebuffSkill);

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
