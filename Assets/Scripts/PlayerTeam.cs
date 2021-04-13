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
        switch (choice)
        {
            case 0:
                team.Add(critStorage.Magicrits.Where(x => x.name.Equals("Lumera")).First());
                break;
            case 1:
                team.Add(critStorage.Magicrits.Where(x => x.name.Equals("Cubsprout")).First());
                choice = 1;
                break;
            case 2:
                team.Add((Crit)critStorage.Magicrits.Where(x => x.name.Equals("Bubbles")).First());
                choice = 2;
                break;
            case 3:
                team.Add((Crit)critStorage.Magicrits.Where(x => x.name.Equals("Flutterpat")).First());
                choice = 3;
                break;
            case 4:
                team.Add((Crit)critStorage.Magicrits.Where(x => x.name.Equals("Hoopty")).First());
                choice = 4;
                break;
        }
    }

    public void AddCrit(string critName)
    {
        if(team.Count() < 4)
        {
            team.Add((Crit)critStorage.Magicrits.Where(x => x.name.Equals(critName)));
        }
        else
        {
            //TODO transfer to inventory
        }
    }
}
