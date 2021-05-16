using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTemple1 : MonoBehaviour
{
    public GameObject player;
    public CritStorage critStorage;
    public FightLoaderOut fightLoader;
    public DialogueManager dm;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerTeam>().AddCrit(27);
        player.GetComponent<PlayerTeam>().AddCrit(25);
        player.GetComponent<PlayerTeam>().AddCrit(47);
        player.GetComponent<PlayerTeam>().AddCrit(13);
        foreach(Crit crit in PlayerTeam.team)
        {
            crit.LevelUp(33);
        }
        Highlighter.BGIndex = "final";
        Highlighter.critIndex = "nox";
    }

    // Update is called once per frame
    void Update()
    {
        if (dm.dialogs[0].done)
        {
            fightLoader.LoadFight("Transition1_start");

        }
    }
}
