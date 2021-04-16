using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Schooled : MonoBehaviour, ISkill
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;
    public SkillType type;

    //skill execution
    public void execute(Crit caster, Crit target)
    {
        if (!skills.Any())
        {
            PASkill m = new PASkill();
            WreakHavoc m1 = new WreakHavoc();
            m.init(val, acc);
            m1.init(30);
            skills.Add(m);
            skills.Add(m1);
        }
        foreach (ISkill skill in skills)
        {
            //executing all base skills
            skill.execute(caster, target);
        }
    }
}
