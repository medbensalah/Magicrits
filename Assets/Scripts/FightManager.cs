using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public FightInit fightinitializer;
    public GameObject player;
    public GameObject enemy;
    public Crit[] PTParams = new Crit[2];
    public Crit[] ETParams = new Crit[2];

    public GameObject playerInfo;
    public GameObject enemyInfo;


    public PlayerController playerController;

    private bool? playerTurn = null;

    // Start is called before the first frame update
    void Start()
    {
        //player =
        //fightinitializer.playerCritScript.gameObject;
        foreach (var n in player.GetComponent<Crit>().skills)
        {
            Debug.Log(n.GetType().GetField("name").GetValue(n));
        }
        PTParams[0] = player.GetComponent<Crit>();
        PTParams[1] = enemy.GetComponent<Crit>();
        ETParams[0] = enemy.GetComponent<Crit>();
        ETParams[1] = player.GetComponent<Crit>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTurn == null)
        {
            player.GetComponent<Crit>().controller = playerController;
            playerTurn = DecideStarter();
        }
        if(playerTurn == true)
        {
            //RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //if (hit && Input.GetMouseButtonDown(0))
            //{
            //    string skillName;
            //    if (hit.collider.gameObject.name.ToLower().Contains("slot"))
            //    {
            //        skillName = hit.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text;
            //        var skill = player.skills.Where(x => x.GetType().GetField("name").GetValue(x).ToString().Equals(skillName)).First();
            //        Debug.Log(skillName);
            //        skill.GetType().GetMethod("execute").Invoke(skill, PTParams);
            //    }
            //}
            string name = player.GetComponent<Crit>().controller.GetSkill();
            if (name != "")
            {
                Debug.Log(name);
                // var skill = player.skills.Where(x => x.GetType().GetField("name").GetValue(x).ToString().Equals(name)).First();
               

        //        skill.GetType().GetMethod("execute").Invoke(skill, PTParams);
            }


          //  enemyInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = enemy.Health + "/" + enemy.MaxHealth;
        }






    }

    public void ChangeCrit(GameObject go)
    {
        //player = go;
        //foreach (var n in player.GetComponent<Crit>().skills)
        //{
        //    Debug.Log(n.GetType().GetField("name").GetValue(n));
        //}
    }

    private bool DecideStarter()
    {
        return player.GetComponent<Crit>().Speed >= enemy.GetComponent<Crit>().Speed ? true : false;
    }

}
