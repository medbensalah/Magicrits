using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.SceneManagement;

public class Highlighter : MonoBehaviour
{
    private SpriteShapeRenderer shr;
    public static string BGIndex;       //background index for eventual fight
    FightLoaderOut fightLoader;         //reference to fight loader game object

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
        shr.color = new Color32(255, 255, 255, 100);
        MouseCursorManager.fightCursorBool = true;
    }
    void OnMouseExit()
    {
        shr.color = new Color32(255, 255, 255, 0);
        MouseCursorManager.fightCursorBool = false;
    }

    //action on mouse up
    private void OnMouseUpAsButton()
    {
        Debug.Log("click");
        Search();

        if (gameObject.tag.Equals("Decoration"))
        {
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
        //setting the bgindex based on the fight caller scene
        if(scene.Contains("forest") || scene.Contains("plain"))
        {
            BGIndex = "forest";
        }

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
                Debug.Log("click");
                fightLoader.LoadFight("Transition1_start");
                break;
        }
    }
}
