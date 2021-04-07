using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    //array for default cursor animation
    [SerializeField] private Texture2D[] cursorTextureArray;
    //reference to the fight cursor sprite
    [SerializeField] private Texture2D fightCursor;
    //number of frames per animation
    [SerializeField] private int frameCount;
    //framerate of the cursor animation
    [SerializeField] private float frameRate;

    //becomes true while in fight
    public static bool fightCursorBool = false;

    //reference to the current cursor frame
    private int currentFrame;
    //timer to change animation frames
    private float frameTimer;

    // Start is called before the first frame update
    void Start()
    {
        //setting the default cursor and giving (0,0) as its hotspot with auto mode
        Cursor.SetCursor(cursorTextureArray[0], Vector2.zero, CursorMode.Auto);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //resetting frame timer
        frameTimer -= Time.deltaTime;
        if (!fightCursorBool)
        {
            //managing the animation changes
            if (frameTimer <= 0.0f)
            {
                frameTimer += frameRate;
                currentFrame = (currentFrame + 1) % frameCount;
                Cursor.SetCursor(cursorTextureArray[currentFrame], Vector2.zero, CursorMode.Auto);
            }
        }
        else
        {
            //setting the fight cursor sprite to the cursor
            Cursor.SetCursor(fightCursor, Vector2.zero, CursorMode.Auto);
        }
    }
}
