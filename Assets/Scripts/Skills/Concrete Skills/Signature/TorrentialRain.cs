using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TorrentialRain : MonoBehaviour, ISkill
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
            MASkill m = new MASkill();
            SleepSkill m1 = new SleepSkill();
            m.init(val, acc);
            m1.init(val, acc);
            skills.Add(m);
            skills.Add(m1);
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
