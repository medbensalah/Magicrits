    using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float xMargin = 1f;  // Distance in the x axis the player can move before the camera follows.
    public float yMargin = 1f;  // Distance in the y axis the player can move before the camera follows.

    public Transform player;

    private void Awake()
    {
        //moving camera to be centered on the player
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        //if player is out of margins move the camera along with him
        if (CheckYMargin() && CheckXMargin())
        {
            if(player.position.x < transform.position.x)
            {
                if(player.position.y < transform.position.y)
                {
                    transform.position = new Vector3(player.position.x + xMargin, player.position.y + yMargin, transform.position.z);
                }
                else if(player.position.y > transform.position.y)
                {
                    transform.position = new Vector3(player.position.x + xMargin, player.position.y - yMargin, transform.position.z);
                }
            }
            else if(player.position.x > transform.position.x)
            {
                if(player.position.y < transform.position.y)
                {
                    transform.position = new Vector3(player.position.x - xMargin, player.position.y + yMargin, transform.position.z);
                }
                else if(player.position.y > transform.position.y)
                {
                    transform.position = new Vector3(player.position.x - xMargin, player.position.y - yMargin, transform.position.z);
                }
            }
        }
        else if (CheckXMargin())
        {
            if(player.position.x < transform.position.x)
            {
                transform.position = new Vector3(player.position.x + xMargin, transform.position.y, transform.position.z);
            }
            else if(player.position.x > transform.position.x)
            {
                transform.position = new Vector3(player.position.x - xMargin, transform.position.y, transform.position.z);
            }
        }
        else if (CheckYMargin())
        {
            if(player.position.y < transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y + yMargin, transform.position.z);
            }
            else if(player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, player.position.y - yMargin, transform.position.z);
            }
        }
    }

    //checking for player touching the margin allowed for its movement
    bool CheckXMargin()
    {
        return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
    }

    bool CheckYMargin()
    {
        return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
    }
}