using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkill
{
    void execute(Crit caster, Crit target);
}
