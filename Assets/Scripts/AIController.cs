using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIController : MonoBehaviour, ICritController
{
    public Crit crit;
    public Crit foe;
    public int nbSkills;
    public FightInit fightInitializer;
    public List<MonoBehaviour> buffs = new List<MonoBehaviour>();
    public List<MonoBehaviour> debuffs = new List<MonoBehaviour>();
    public List<MonoBehaviour> heals = new List<MonoBehaviour>();
    public List<MonoBehaviour> poisons = new List<MonoBehaviour>();
    public List<MonoBehaviour> confuses = new List<MonoBehaviour>();
    public List<MonoBehaviour> sleeps = new List<MonoBehaviour>();
    public List<MonoBehaviour> magics = new List<MonoBehaviour>();
    public List<MonoBehaviour> physicals = new List<MonoBehaviour>();

    public List<MonoBehaviour> prefs = new List<MonoBehaviour>();


    bool attack = false;

    public string GetSkill()
    {
        string skill = "";
        if (crit.Confused > 0)
        {
            int rnd = Random.Range(1, nbSkills - 1);
            skill = crit.skills[rnd].GetType().GetField("name").GetValue(crit.skills[rnd]).ToString();
        }
        else
        {

            if (crit.Level < foe.Level - 1 && foe.Health * 1.0f / foe.MaxHealth > 0.2f)
            {
                if (!attack)
                {
                    //**************************************************************
                    int rnd = Random.Range(1, 3);
                    if (rnd == 1 && buffs.Count > 0)
                    {
                        skill = buffs[buffs.Count - 1].GetType().GetField("name").GetValue(buffs[buffs.Count - 1]).ToString();
                    }
                    else if (rnd == 2 && debuffs.Count > 0)
                    {
                        skill = debuffs[debuffs.Count - 1].GetType().GetField("name").GetValue(debuffs[debuffs.Count - 1]).ToString();
                    }
                    else if (confuses.Count > 0 && foe.Confused == 0 && foe.Asleep == 0)
                    {
                        skill = confuses[confuses.Count - 1].GetType().GetField("name").GetValue(confuses[confuses.Count - 1]).ToString();
                    }
                    else if (sleeps.Count > 0 && foe.Confused == 0 && foe.Asleep == 0)
                    {
                        skill = sleeps[sleeps.Count - 1].GetType().GetField("name").GetValue(sleeps[sleeps.Count - 1]).ToString();
                    }
                    attack = true;

                    //**************************************************************
                }
                else
                {
                    if (foe.Asleep == 0 && foe.Confused == 0)
                    {
                        //**************************************************************
                        int rnd = Random.Range(1, 7);
                        if (rnd <= 3)
                        {
                            skill = prefs[0].GetType().GetField("name").GetValue(prefs[0]).ToString();
                        }
                        else if (rnd <= 5 && prefs.Count >= 2)
                        {
                            skill = prefs[1].GetType().GetField("name").GetValue(prefs[1]).ToString();
                        }
                        else if (rnd <= 6 && prefs.Count >= 3)
                        {
                            skill = prefs[2].GetType().GetField("name").GetValue(prefs[2]).ToString();
                        }
                        else if (poisons.Count >= 1)
                        {
                            skill = poisons[poisons.Count - 1].GetType().GetField("name").GetValue(poisons[poisons.Count - 1]).ToString();
                        }

                        //*****************************************************************************
                    }
                    else
                    {
                         //**************************************************************
                        int rnd = Random.Range(1, 3);
                        if (rnd == 1 && buffs.Count > 0)
                        {
                            skill = buffs[buffs.Count - 1].GetType().GetField("name").GetValue(buffs[buffs.Count - 1]).ToString();
                        }
                        else if (rnd == 2 && debuffs.Count > 0)
                        {
                            skill = debuffs[debuffs.Count - 1].GetType().GetField("name").GetValue(debuffs[debuffs.Count - 1]).ToString();
                        }
                        else if (heals.Count >= 2 && crit.Health * 1.0f / crit.MaxHealth < 0.5f)
                        {
                            skill = heals[heals.Count - 2].GetType().GetField("name").GetValue(heals[heals.Count - 2]).ToString();
                        }
                        else if (heals.Count == 1 && crit.Health * 1.0f / crit.MaxHealth < 0.5f)
                        {
                            skill = heals[heals.Count - 1].GetType().GetField("name").GetValue(heals[heals.Count - 1]).ToString();
                        }

                        //*********************************************************************************
                    }
                }
            }
            else if (foe.Health * 1.0f / foe.MaxHealth > 0.2f)
            {
                if (crit.Health * 1.0f / crit.MaxHealth > 0.5f)
                {
                     //*************************************************************************************
                    int rnd = Random.Range(1, 20);

                    if (rnd == 1 && buffs.Count > 0)
                    {
                        skill = buffs[buffs.Count - 1].GetType().GetField("name").GetValue(buffs[buffs.Count - 1]).ToString();
                    }
                    else if (rnd == 2 && debuffs.Count > 0)
                    {
                        skill = debuffs[debuffs.Count - 1].GetType().GetField("name").GetValue(debuffs[debuffs.Count - 1]).ToString();
                    }
                    else if (rnd == 3 && poisons.Count > 0)
                    {
                        skill = poisons[poisons.Count - 1].GetType().GetField("name").GetValue(poisons[poisons.Count - 1]).ToString();
                    }
                    else if (rnd == 4 && sleeps.Count > 0)
                    {
                        skill = sleeps[sleeps.Count - 1].GetType().GetField("name").GetValue(sleeps[sleeps.Count - 1]).ToString();
                    }
                    else if (rnd == 5 && sleeps.Count > 0)
                    {
                        skill = confuses[confuses.Count - 1].GetType().GetField("name").GetValue(confuses[confuses.Count - 1]).ToString();
                    }
                    else if (rnd <= 12)
                    {
                        skill = prefs[0].GetType().GetField("name").GetValue(prefs[0]).ToString();
                    }
                    else if (rnd <= 17 && prefs.Count > 1)
                    {
                        skill = prefs[1].GetType().GetField("name").GetValue(prefs[1]).ToString();
                    }
                    else if (prefs.Count > 2)
                    {
                        skill = prefs[2].GetType().GetField("name").GetValue(prefs[2]).ToString();
                    }
                    //*************************************************************************************
                }
                else
                {

                    //*************************************************************************************
                    int rnd = Random.Range(1, 30);
                    if (rnd == 1 && buffs.Count > 0 && heals.Count >= 1)
                    {
                        skill = buffs[buffs.Count - 1].GetType().GetField("name").GetValue(buffs[buffs.Count - 1]).ToString();
                    }
                    else if (rnd == 2 && debuffs.Count > 0)
                    {
                        skill = debuffs[debuffs.Count - 1].GetType().GetField("name").GetValue(debuffs[debuffs.Count - 1]).ToString();
                    }
                    else if (rnd == 3 && poisons.Count > 0)
                    {
                        skill = poisons[poisons.Count - 1].GetType().GetField("name").GetValue(poisons[poisons.Count - 1]).ToString();
                    }
                    else if (rnd == 4 && sleeps.Count > 0)
                    {
                        skill = sleeps[sleeps.Count - 1].GetType().GetField("name").GetValue(sleeps[sleeps.Count - 1]).ToString();
                    }
                    else if (rnd == 5 && sleeps.Count > 0)
                    {
                        skill = confuses[confuses.Count - 1].GetType().GetField("name").GetValue(confuses[confuses.Count - 1]).ToString();
                    }
                    else if (rnd <= 12)
                    {
                        skill = prefs[0].GetType().GetField("name").GetValue(prefs[0]).ToString();
                    }
                    else if (rnd <= 17 && prefs.Count > 1)
                    {
                        skill = prefs[1].GetType().GetField("name").GetValue(prefs[1]).ToString();
                    }
                    else if (rnd <= 19 && prefs.Count > 2)
                    {
                        skill = prefs[2].GetType().GetField("name").GetValue(prefs[2]).ToString();
                    }
                    else
                    {
                        skill = heals[heals.Count - 1].GetType().GetField("name").GetValue(heals[heals.Count - 1]).ToString();
                    }

                    //********************************************************************************************************
                }
            }
            else if (foe.Health * 1.0f / foe.MaxHealth <= 0.2f)
            {

                //*****************************************************************************
                skill = prefs[0].GetType().GetField("name").GetValue(prefs[0]).ToString();
            }
            skill = prefs[0].GetType().GetField("name").GetValue(prefs[0]).ToString();
        }
        return skill;
    }

    public void SetCrit(Crit crit)
    {
        this.crit = crit;
        ClassifySkills();
        OrderSkills();
    }

    public void SetFoe(Crit foe)
    {
        this.foe = foe;
    }

    public void ClassifySkills()
    {
        int lvl = crit.Level;
        nbSkills = lvl <= 3 ? 2 :
                       lvl <= 6 ? 3 :
                       lvl <= 9 ? 4 :
                       lvl <= 12 ? 5 :
                       lvl <= 15 ? 6 :
                       lvl <= 18 ? 7 :
                       lvl <= 21 ? 8 :
                       lvl <= 24 ? 9 :
                       lvl <= 27 ? 10 :
                       lvl <= 29 ? 11 :
                       lvl <= 34 ? 12 : 13;
        heals = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Heal).ToList();
        //Debug.Log("heals :" + heals.Count);
        buffs = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Buff).ToList();
        //Debug.Log("buffs :" + buffs.Count);
        debuffs = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Debuff).ToList();
        //Debug.Log("debuffs :" + debuffs.Count);
        poisons = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Poison).ToList();
        //Debug.Log("poisons :" + poisons.Count);
        confuses = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Confuse).ToList();
        //Debug.Log("consuses :" + confuses.Count);
        sleeps = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Sleep).ToList();
        //Debug.Log("sleeps :" + sleeps.Count);
        physicals = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type == (int)SkillType.Physical).ToList();
        //Debug.Log("phys :" + physicals.Count);
        magics = crit.skills.Where(skill => crit.skills.IndexOf(skill) < nbSkills &&
        fightInitializer.skillInfo[crit.skills.IndexOf(skill)].type < 6).ToList();
        //Debug.Log("mag :" + magics.Count);
    }

    public void OrderSkills()
    {
        if (PhysicalOrientation())
        {
            Debug.Log(PhysicalOrientation() + "phys");
            if (physicals.Count >= 1)
            {
                prefs.Add(physicals[physicals.Count - 1]);
            }
            if (physicals.Count >= 2)
            {
                prefs.Add(physicals[physicals.Count - 2]);
            }
            if (magics.Count >= 1)
            {
                prefs.Add(magics[magics.Count - 1]);
            }
            if (magics.Count >= 2)
            {
                prefs.Add(magics[magics.Count - 2]);
            }
        }
        else
        {
            if (magics.Count >= 1)
            {
                prefs.Add(magics[magics.Count - 1]);
            }
            if (magics.Count >= 2)
            {
                prefs.Add(magics[magics.Count - 2]);
            }
            if (physicals.Count >= 1)
            {
                prefs.Add(physicals[physicals.Count - 1]);
            }
            if (physicals.Count >= 2)
            {
                prefs.Add(physicals[physicals.Count - 2]);
            }
        }
    }

    public bool PhysicalOrientation()
    {
        return crit.PAUpRate > crit.MAUpRate;
    }
}
