using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteSugarRushSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public EliteSugarRushSkill()
    {
        // Multi Damage Skill (4 Magical Attack Skills)
        MASkill maSkill1 = new MASkill(val, acc);
        skills.Add(maSkill1);
        MASkill maSkill2 = new MASkill(val, acc);
        skills.Add(maSkill2);
        MASkill maSkill3 = new MASkill(val, acc);
        skills.Add(maSkill3);
        MASkill maSkill4 = new MASkill(val, acc);
        skills.Add(maSkill4);

        skills.Add(new MDDebuffSkill(7, 90));
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
