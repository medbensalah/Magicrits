using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CankerLeafSkill : MonoBehaviour
{
    //array of base skills
    [SerializeField] private List<ISkill> skills = new List<ISkill>();
    //skill description
    public string Description;
    public string name;
    public int val;
    public int acc;

    public CankerLeafSkill()
    {
        // Magic Damage Skill
        skills.Add(new MASkill(40, 100));

        // Confuse Skill
        skills.Add(new ConfuseSkill(2, 30));
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
