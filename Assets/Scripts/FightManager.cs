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
    public Crit caster;
    public Crit target;
    public Crit[] CTParams = new Crit[2];
    public Crit[] CCParams = new Crit[2];
    
    public GameObject playerInfo;
    public GameObject enemyInfo;

    public float enemyHpWidth;
    public float enemyHpHeight;
    
    public PlayerController playerController;
    public AIController aiController;

    private bool? playerTurn = null;
    private bool inChange = false;
    public Gradient gradient;
    public static bool locked = false;
    public static bool animLock = false;

    int turn = 0;
    bool advanced = false;

    GameObject anim;

    public Transform animation;

    public GameObject[] animations;
    // Start is called before the first frame update
    void Start()
    {
        enemyHpWidth = enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.x;
        enemyHpHeight = enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta.y;

        player = fightinitializer.playerCrit.gameObject;
        enemy = fightinitializer.enemyCrit.gameObject;

        CCParams[0] = caster;
        CCParams[1] = caster;
        CTParams[0] = caster;
        CTParams[1] = target;

        AnimationManager.setEnemy(enemy.GetComponent<Crit>());
    }

    IEnumerator Unlock()
    {
        yield return new WaitForSeconds(0.5f);
        locked = false;
        animLock = false;
    }

    // Update is called once per frame
    void Update()
    {
        enemyInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = enemy.GetComponent<Crit>().Health + "/" + enemy.GetComponent<Crit>().MaxHealth;

        Vector2 currentSize = enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta;

        Vector2 newHpSize = new Vector2(enemy.GetComponent<Crit>().Health * enemyHpWidth / enemy.GetComponent<Crit>().MaxHealth, enemyHpHeight);
        enemyInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(currentSize, newHpSize, 0.085f);
        Color current = enemyInfo.transform.GetChild(1).GetComponent<Image>().color;
        enemyInfo.transform.GetChild(1).GetComponent<Image>().color = Color.Lerp(current,
            gradient.Evaluate(1 - enemy.GetComponent<Crit>().Health * 1.0f / enemy.GetComponent<Crit>().MaxHealth),
            Time.deltaTime);

        playerInfo.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = player.GetComponent<Crit>().Health + "/" + player.GetComponent<Crit>().MaxHealth;

        Vector2 currentSize2 = playerInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta;

        Vector2 newHpSize2 = new Vector2(player.GetComponent<Crit>().Health * enemyHpWidth / player.GetComponent<Crit>().MaxHealth, enemyHpHeight);
        playerInfo.transform.GetChild(1).GetComponent<RectTransform>().sizeDelta = Vector2.Lerp(currentSize2, newHpSize2, 0.085f);
        Color current2 = playerInfo.transform.GetChild(1).GetComponent<Image>().color;
        playerInfo.transform.GetChild(1).GetComponent<Image>().color = Color.Lerp(current2,
            gradient.Evaluate(1 - player.GetComponent<Crit>().Health * 1.0f / player.GetComponent<Crit>().MaxHealth),
            Time.deltaTime);
        if (playerTurn == null)
        {
            playerController.SetCrit(player.GetComponent<Crit>());
            player.GetComponent<Crit>().controller = playerController;
            aiController.SetCrit(enemy.GetComponent<Crit>());
            aiController.SetFoe(player.GetComponent<Crit>());
            enemy.GetComponent<Crit>().controller = aiController;
            playerTurn = DecideStarter();
        }
        if (!locked && !animLock && !AnimationManager.animatorLock && player.GetComponent<Crit>().Alive)
        {
            if (player.GetComponent<Crit>().Asleep != 0)
            {
                playerTurn = false;
            }
            if (playerTurn == true || enemy.GetComponent<Crit>().Asleep > 0)
            {
                caster = player.GetComponent<Crit>();
                //confuse here
                if(caster.Confused > 0)
                {
                    int rnd = UnityEngine.Random.Range(1, 2);
                    target = rnd == 1 ? enemy.GetComponent<Crit>() : player.GetComponent<Crit>();
                }
                else 
                { 
                target = enemy.GetComponent<Crit>();
                }
                CCParams[0] = caster;
                CCParams[1] = caster;
                CTParams[0] = caster;
                CTParams[1] = target;

                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit && Input.GetMouseButtonDown(0))
                {
                    string name = player.GetComponent<Crit>().controller.GetSkill();
                    if (name != "")
                    {
                        var skill = player.GetComponent<Crit>().skills.Where(x => x.GetType().GetField("name").GetValue(x).ToString().Equals(name)).First();
                        
                          

                        

                        string type = skill.GetType().ToString().ToLower();
                        
                        if (type.Contains("debuff"))
                        {
                            DestroyImmediate(anim);
                            anim = Instantiate(animations.First(x => x.name.StartsWith("Debuff")), animation);
                        }
                        else if (type.Contains("buff"))
                        {
                            DestroyImmediate(anim);
                            anim = Instantiate(animations.First(x => x.name.StartsWith("Buff")), animation);
                        }
                        else if (type.Contains("heal") || type.Contains("hot"))
                        {
                            DestroyImmediate(anim);
                            anim = Instantiate(animations.First(x => x.name.StartsWith("Heal")), animation);
                        }

                        if ((!type.Contains("debuff") && type.Contains("buff")) || type.Contains("heal") || type.Contains("hot"))
                        {
                            skill.GetType().GetMethod("execute").Invoke(skill, CCParams);
                            anim.transform.position = new Vector3(caster.transform.position.x, anim.transform.position.y, 0);
                        }
                        else
                        {
                            if (!type.Contains("debuff")) {
                                DestroyImmediate(anim);
                                anim = Instantiate(animations.First(x => x.name.StartsWith(name)), animation);
                            }
                            skill.GetType().GetMethod("execute").Invoke(skill, CTParams);
                            anim.transform.position = new Vector3(target.transform.position.x, anim.transform.position.y, 0);
                        }
                        animLock = true;    
                        inChange = true;
                        StartCoroutine(ChangeTurn());
                    }
                }

            }

            else if (!inChange)
            {
                if (enemy.GetComponent<Crit>().Asleep <= 0)
                {
                    caster = enemy.GetComponent<Crit>();
                    //confuse here
                    if(caster.Confused > 0)
                    {
                        int rnd = UnityEngine.Random.Range(1, 2);
                        target = rnd == 1 ? enemy.GetComponent<Crit>() : player.GetComponent<Crit>();
                    }
                    else
                    {
                        target = player.GetComponent<Crit>();
                    }
                    CCParams[0] = caster;
                    CCParams[1] = caster;
                    CTParams[0] = caster;
                    CTParams[1] = target;
                    string name = enemy.GetComponent<Crit>().controller.GetSkill();
                    if (name != "")
                    {
                        var skill = enemy.GetComponent<Crit>().skills.Where(x => x.GetType().GetField("name").GetValue(x).ToString().Equals(name)).First();
                        //if (name != "NoxUlt")
                        //{
                        //    DestroyImmediate(anim);
                        //    anim = Instantiate(animations[2], GameObject.Find("Canvas").transform);
                        //    anim.GetComponent<Animator>().Play("Elite Sugar Rush");
                        //}
                        //else
                        //{
                        //    anim = Instantiate(animations[1], GameObject.Find("Canvas").transform);
                        //    //anim.GetComponent<Animator>().Play("Bash");
                        //}
                        //anim.transform.position = target.transform.position;
                        //anim.transform.localScale = new Vector2(-Mathf.Abs(anim.transform.localScale.x),
                        //    anim.transform.localScale.y);
                        //animLock = true;

                        string type = skill.GetType().ToString().ToLower(); if (type.Contains("debuff"))
                        {
                            DestroyImmediate(anim);
                            anim = Instantiate(animations.First(x => x.name.StartsWith("Debuff")), animation);
                        }
                        else if (type.Contains("buff"))
                        {
                            DestroyImmediate(anim);
                            anim = Instantiate(animations.First(x => x.name.StartsWith("Buff")), animation);
                        }
                        else if (type.Contains("heal") || type.Contains("hot"))
                        {
                            DestroyImmediate(anim);
                            anim = Instantiate(animations.First(x => x.name.StartsWith("Heal")), animation);
                        }

                        if ((!type.Contains("debuff") && type.Contains("buff")) || type.Contains("heal") || type.Contains("hot"))
                        {
                            skill.GetType().GetMethod("execute").Invoke(skill, CCParams);
                            anim.transform.position = new Vector3(caster.transform.position.x, anim.transform.position.y, 0);
                        }
                        else
                        {
                            if (!type.Contains("debuff"))
                            {
                                DestroyImmediate(anim);
                                anim = Instantiate(animations.First(x => x.name.StartsWith(name)), animation);
                            }
                            skill.GetType().GetMethod("execute").Invoke(skill, CTParams);
                            anim.transform.position = new Vector3(target.transform.position.x, anim.transform.position.y, 0);
                        }
                        animLock = true;
                        inChange = true;
                        StartCoroutine(ChangeTurn());
                    }

                }

            }
        }

        if (turn % 2 == 0 && !advanced)
        {
            advanced = true;

            enemy.GetComponent<Crit>().advanceTurn();
            player.GetComponent<Crit>().advanceTurn();
        }
        
    }

    IEnumerator ChangeTurn()
    {
        advanced = false;
        turn++;
        inChange = locked = true;
        playerTurn = !playerTurn;
        inChange = false;
        yield return new WaitUntil(() => (!locked) && (!animLock));
        if (player.GetComponent<Crit>().Health == 0)
        {
            Debug.Log(locked + "  " + animLock);
            new WaitWhile(() => locked || animLock);
            Debug.Log(locked + "  " + animLock);
            player.GetComponent<Crit>().Alive = false;
            ChangeCrit();
        }
    }

    public void ChangeCrit()
    {
        Debug.Log("here");
        fightinitializer.playerCrit.transform.SetParent(null);
        fightinitializer.PlayerInitNext();
        player = fightinitializer.playerCrit.gameObject;
        Crit crit = PlayerTeam.team.FirstOrDefault(x => x.Alive == true);

        playerController.SetCrit(player.GetComponent<Crit>());
        player.GetComponent<Crit>().controller = playerController;
        if (crit == null)
        {
            Debug.Log("Lose");
        }
        else
        {
        }
    }

    private bool DecideStarter()
    {
        return player.GetComponent<Crit>().Speed >= enemy.GetComponent<Crit>().Speed ? true : false;
    }

}
