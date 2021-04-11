using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;

public class ChooseCrit : MonoBehaviour
{
    //array of crits to choose from
    public Transform[] crits = new Transform[5];
    public Color[] colors = new Color[5];
    private int selected = 2;
    public static int choice = -1;

    private void FixedUpdate()
    {
        Select();
        if (Input.GetMouseButtonUp(0))
        {
            Choose();
        }
    }

    public void Select()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Color currentColor = GetComponent<Light2D>().color;
        if (hit.collider != null)
        {
            switch (hit.collider.gameObject.GetComponent<Crit>().name)
            {
                case "Lumera":
                    selected = 0;
                    break;
                case "Cubsprout":
                    selected = 1;
                    break;
                case "Bubbles":
                    selected = 2;
                    break;
                case "Flutterpat":
                    selected = 3;
                    break;
                case "Hoopty":
                    selected = 4;
                    break;
            }
        }

        transform.position = Vector3.Lerp(transform.position, crits[selected].position, Time.deltaTime * 5);
        GetComponent<Light2D>().color = Color.Lerp(currentColor, colors[selected], Time.deltaTime * 5);

    }

    public void Choose()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Color currentColor = GetComponent<Light2D>().color;
        if (hit.collider != null)
        {
            switch (hit.collider.gameObject.GetComponent<Crit>().name)
            {
                case "Lumera":
                    choice = 0;
                    break;
                case "Cubsprout":
                    choice = 1;
                    break;
                case "Bubbles":
                    choice = 2;
                    break;
                case "Flutterpat":
                    choice = 3;
                    break;
                case "Hoopty":
                    choice = 4;
                    break;
            }
        }
        SceneManager.LoadScene("Plains1");
    }    
}
