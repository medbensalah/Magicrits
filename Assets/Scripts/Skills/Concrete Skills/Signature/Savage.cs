using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Savage : MonoBehaviour, ISkill
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
            PABuffSkill m1 = new PABuffSkill();
            MABuffSkill m2 = new MABuffSkill();
            HealSkill m3 = new HealSkill();
            m.init(val, acc);
            m1.init(2, acc);
            m2.init(2, acc);
            m3.init(20, acc);
            skills.Add(m);
            skills.Add(m1);
            skills.Add(m2);
            skills.Add(m3);
        }
        foreach (ISkill skill in skills)
        {
            //executing all base skills
            string type = skill.GetType().ToString().ToLower();
            if (type.Contains("buff") || type.Contains("heal") || type.Contains("hot"))
            {
                skill.execute(caster, caster);

            }
            else
            {
                skill.execute(caster, target);
            }
        }
    }
}
