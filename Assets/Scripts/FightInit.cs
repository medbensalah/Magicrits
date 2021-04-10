using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightInit : MonoBehaviour
{
    //possible Scene backgrounds
    public Sprite[] backgroundSprites = new Sprite[11];

    //possible enemies
    public GameObject[] enemies = new GameObject[50];

    //place holders
    public GameObject[] placeholder = new GameObject[2];
    public GameObject enemyCrit;
    public GameObject player;
    public GameObject enemyInfo;
    public GameObject playerInfo;

    SpriteRenderer sr;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //animation to enter the fight scene
        animator.Play("Transition1_end");
    }

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        int bg = 0;
        int enemy = 0;
        //choosing fight background based on caller scene name
        if (Highlighter.BGIndex.Equals("forest"))
        {
            bg = Random.Range(0, 3);
        }
        //setting the fight background
        sr.sprite = backgroundSprites[bg];



        enemy = Random.Range(1, 100);
        //choosing enemy based on caller scene name
        if (Highlighter.critIndex.Equals("plain"))
        {
                enemy = enemy <= 3 ? 10 :
                        enemy <= 5 ? 4 :
                        enemy <= 11 ? 8 :
                        enemy <= 17 ? 9 :
                        enemy <= 25 ? 5 :
                        enemy <= 33 ? 2 :
                        enemy <= 41 ? 3 :
                        enemy <= 61 ? 6 :
                        enemy <= 81 ? 1 : 2;
        }
        if (Highlighter.critIndex.Equals("forest"))
        {
            enemy = enemy <= 1 ? 25 :
                    enemy <= 2 ? 16 :
                    enemy <= 3 ? 18 :
                    enemy <= 4 ? 51 :
                    enemy <= 5 ? 101 :
                    enemy <= 8 ? 13 :
                    enemy <= 11 ? 24 :
                    enemy <= 16 ? 14 :
                    enemy <= 21 ? 22 :
                    enemy <= 26 ? 21 :
                    enemy <= 31 ? 23 :
                    enemy <= 36 ? 68 :
                    enemy <= 44 ? 11 :
                    enemy <= 52 ? 12 :
                    enemy <= 60 ? 15 :
                    enemy <= 68 ? 19 :
                    enemy <= 76 ? 20 :
                    enemy <= 84 ? 26 :
                    enemy <= 92 ? 27 : 28;
        }
        if (Highlighter.critIndex.Equals("cave"))
        {
            enemy = enemy <= 1 ? 44 :
                    enemy <= 2 ? 37 :
                    enemy <= 3 ? 38 :
                    enemy <= 4 ? 39 :
                    enemy <= 6 ? 45 :
                    enemy <= 9 ? 42 :
                    enemy <= 16 ? 29 :
                    enemy <= 23 ? 30 :
                    enemy <= 30 ? 31 :
                    enemy <= 37 ? 32 :
                    enemy <= 44 ? 33 :
                    enemy <= 51 ? 34 :
                    enemy <= 58 ? 35 :
                    enemy <= 65 ? 36 :
                    enemy <= 72 ? 40 :
                    enemy <= 79 ? 41 :
                    enemy <= 86 ? 43 :
                    enemy <= 93 ? 68 : 69 ;
        }
        if (Highlighter.critIndex.Equals("mount"))
        {
            enemy = enemy <= 1 ? 63 :
                    enemy <= 4 ? 53 :
                    enemy <= 7 ? 54 :
                    enemy <= 10 ? 47 :
                    enemy <= 13 ? 48 :
                    enemy <= 16 ? 51 :
                    enemy <= 22 ? 46 :
                    enemy <= 28 ? 49 :
                    enemy <= 34 ? 50 :
                    enemy <= 40 ? 52 :
                    enemy <= 46 ? 94 :
                    enemy <= 52 ? 55 :
                    enemy <= 58 ? 56 :
                    enemy <= 64 ? 57 :
                    enemy <= 70 ? 58 :
                    enemy <= 76 ? 59 :
                    enemy <= 82 ? 60 :
                    enemy <= 88 ? 61 : 62;
        }
        if (Highlighter.critIndex.Equals("desert"))
        {
            enemy = enemy <= 2 ? 69 :
                    enemy <= 4 ? 67 :
                    enemy <= 6 ? 76 :
                    enemy <= 13 ? 64 :
                    enemy <= 20 ? 65 :
                    enemy <= 27 ? 66 :
                    enemy <= 34 ? 68 :
                    enemy <= 41 ? 71 :
                    enemy <= 48 ? 72 :
                    enemy <= 55 ? 73 :
                    enemy <= 62 ? 74 :
                    enemy <= 69 ? 75 :
                    enemy <= 76 ? 77 :
                    enemy <= 83 ? 78 : 70;
        }
        if (Highlighter.critIndex.Equals("temple"))
        {
            enemy = Random.Range(77, 101);
        }
        Crit critScript = enemyCrit.GetComponent<Crit>();
        critScript = enemies[enemy].GetComponent<Crit>();
        enemyCrit.GetComponent<SpriteRenderer>().sprite = critScript.ActiveSprite;

        var enemyFrame = enemyInfo.transform.GetChild(0).GetComponent<Image>().sprite = critScript.ActiveFrame;
    }
}
