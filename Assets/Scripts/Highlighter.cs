﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;
using Unity.Jobs;

public class Highlighter : MonoBehaviour
{
    private SpriteShapeRenderer shr;
    public static string BGIndex;       //background index for eventual fight
    public static string critIndex;     //crit index for eventual fight
    FightLoaderOut fightLoader;         //reference to fight loader game object
    bool searched = false;              //keep track if object is searchable again

    private void Awake()
    {
        //changing the highlighter plane so that it does not overlap
        //the gameobject's collider
        transform.position = new Vector3(transform.position.x, transform.position.y, -0.5f);
        fightLoader = GameObject.Find("FightLoaderOut").GetComponent<FightLoaderOut>();
    }

    //when hovering on the collider the gameobject is highlighted
    void OnMouseEnter()
    {
        if (!searched)
        {
            shr.color = new Color32(255, 255, 255, 100);
            MouseCursorManager.fightCursorBool = true;
        }
    }
    void OnMouseExit()
    {
        if (!searched)
        {
            shr.color = new Color32(255, 255, 255, 0);
            MouseCursorManager.fightCursorBool = false;
        }
    }

    //action on mouse up
    private void OnMouseUpAsButton()
    {

        if (!DialogueManager.inDialogue)
        {
            if (!searched)
            {
                if (transform.parent.gameObject.tag.Equals("Decoration"))
                {
                    shr.color = new Color32(255, 255, 255, 0);
                    MouseCursorManager.fightCursorBool = false;
                    searched = true;
                    Search();
                }
            }
        }
    }

    void Start()
    {
        shr = GetComponent<SpriteShapeRenderer>();
        shr.color = new Color32(255, 255, 255, 0);
    }

    //method to search wold decorations
    private void Search()
    {
        //getting the active scene name
        //needs to be passed to next scene so that 
        //we can return to this one 
        string scene = SceneManager.GetActiveScene().name.ToLower();
        


        //probability of search result
        //85% fight
        //8% gold
        //5% item
        //2% platinum
        int random = Random.Range(0, 100);

        switch (random > 15 ? "Encounter" :
            random > 10 ? "Item" :
            random > 2 ? "Gold" : "Platinum"
            )
        {
            case "Encounter":

                //setting the bgindex based on the fight caller scene
                if (scene.Contains("forest") || scene.Contains("plain"))
                {
                    BGIndex = "forest";
                }
                
                else if (scene.Contains("temple"))
                {
                    BGIndex = "temple";
                }

                //setting the critIndex based on the fight caller scene
                
                if (scene.Contains("desert"))
                {
                    critIndex = "desert";
                }
                if (scene.Contains("plain") || scene.Contains("forest"))
                {
                    critIndex = "plain";
                }
                if (scene.Contains("mount"))
                {
                    critIndex = "mount";
                }
                if (scene.Contains("cave"))
                {
                    critIndex = "cave";
                }
                if (scene.Contains("temple"))
                {
                    critIndex = "temple";
                }

                fightLoader.LoadFight("Transition1_start");
                break;
        }
    }
}
