using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTeam : MonoBehaviour
{
    public static List<Crit> team = new List<Crit>();
    public CritStorage critStorage;


    private void Start()
    {
        Init(ChooseCrit.choice);
    }

    public void Init(int choice)
    {
        AddCrit(choice); 
    }

    public void AddCrit(string critName)
    {
        if(team.Count() < 4)
        {
            Crit myCrit = Instantiate((Crit)critStorage.Magicrits.First(x => x.critName.Equals(critName)));
            myCrit.GetComponent<SpriteRenderer>().enabled = false;
            DontDestroyOnLoad(myCrit);

            team.Add(Instantiate((Crit)critStorage.Magicrits.First(x => x.critName.Equals(critName))));
        }
        else
        {
            //TODO transfer to inventory
        }
    }
    public void AddCrit(int crit)
    {
        if(team.Count() < 4)
        {
            Crit myCrit = Instantiate(critStorage.Magicrits[crit]);
            myCrit.GetComponent<SpriteRenderer>().enabled = false;
            DontDestroyOnLoad(myCrit);

            team.Add(myCrit);
        }
        else
        {
            //TODO transfer to inventory
        }
    }
}
