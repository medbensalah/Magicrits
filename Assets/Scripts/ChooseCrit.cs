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
    int index = 2;
    public static int choice = -1;

    private void Update()
    {
        Select();
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
                    selected = 22;
                    index = 0;
                    if (Input.GetMouseButtonUp(0))
                    {
                        Choose();
                    }
                    break;
                case "Cubsprout":
                    selected = 0;
                    index = 1;
                    if (Input.GetMouseButtonUp(0))
                    {
                        Choose();
                    }
                    break;
                case "Bubbles":
                    selected = 10;
                    index = 2;
                    if (Input.GetMouseButtonUp(0))
                    {
                        Choose();
                    }
                    break;
                case "Flutterpat":
                    selected = 39;
                    index = 3;
                    if (Input.GetMouseButtonUp(0))
                    {
                        Choose();
                    }
                    break;
                case "Hoopty":
                    selected = 31;
                    index = 4;
                    if (Input.GetMouseButtonUp(0))
                    {
                        Choose();
                    }
                    break;
            }
        }

        transform.position = Vector3.Lerp(transform.position, crits[index].position, 0.08f);
        GetComponent<Light2D>().color = Color.Lerp(currentColor, colors[index], 0.08f);

    }

    public void Choose()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Color currentColor = GetComponent<Light2D>().color;
        choice = selected;
        
        SceneManager.LoadScene("Plains1");
    }    
}
