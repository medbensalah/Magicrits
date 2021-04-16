using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public FightInit fightinitializer;
    public GameObject player;
    public GameObject enemy;
    public Crit[] PTParams = new Crit[2];
    public Crit[] ETParams = new Crit[2];

    public GameObject playerInfo;
    public GameObject enemyInfo;

    public float enemyHpWidth;
    public float enemyHpHeight;
    
    public PlayerController playerController;

    private bool? playerTurn = null;

    public Gradient gradient;

    // Start is called before the first frame update
    void Start()
    {
        enemyHpWidth = enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
        enemyHpHeight = enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y;

        player = fightinitializer.playerCrit.gameObject;
        enemy = fightinitializer.enemyCrit.gameObject;
        PTParams[0] = player.GetComponent<Crit>();
        PTParams[1] = enemy.GetComponent<Crit>();
        ETParams[0] = enemy.GetComponent<Crit>();
        ETParams[1] = player.GetComponent<Crit>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playerTurn == null)
        {
            player.GetComponent<Crit>().controller = playerController;
            playerTurn = DecideStarter();
        }
        if(playerTurn == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit && Input.GetMouseButtonDown(0))
            {
                string name = player.GetComponent<Crit>().controller.GetSkill();
                if (name != "")
                {
                    var skill = player.GetComponent<Crit>().skills.Where(x => x.GetType().GetField("name").GetValue(x).ToString().Equals(name)).First();


                    skill.GetType().GetMethod("execute").Invoke(skill, PTParams);
                }

            }


            enemyInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = enemy.GetComponent<Crit>().Health + "/" + enemy.GetComponent<Crit>().MaxHealth;

            Vector2 currentSize = enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta;

            Vector2 newHpSize = new Vector2(enemy.GetComponent<Crit>().Health * enemyHpWidth / enemy.GetComponent<Crit>().MaxHealth, enemyHpHeight);
            enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(currentSize , newHpSize, 0.07f);
            Color current =  enemyInfo.transform.GetChild(1).GetComponent<Image>().color;
            enemyInfo.transform.GetChild(1).GetComponent<Image>().color = Color.Lerp(current,
                gradient.Evaluate( 1 - enemy.GetComponent<Crit>().Health * 1.0f / enemy.GetComponent<Crit>().MaxHealth),
                Time.deltaTime);
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
