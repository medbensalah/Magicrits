using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightInit : MonoBehaviour
{
    //possible Scene backgrounds
    public Sprite[] backgroundSprites = new Sprite[11];

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
        //choosing fight background based on caller scene name
        if (Highlighter.BGIndex.Equals("forest"))
        {
            bg = Random.Range(0, 3);
        }
        //setting the fight background
        sr.sprite = backgroundSprites[bg];
    }
}
