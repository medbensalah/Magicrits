using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LayerManagement : MonoBehaviour
{
    public GameObject pharaoh;
    public GameObject elevated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (elevated.GetComponent<TilemapRenderer>().sortingOrder == 2)
            {
                elevated.GetComponent<TilemapRenderer>().sortingOrder = 1;
                pharaoh.GetComponent<SpriteRenderer>().sortingOrder = 2;
            }
            else
            {
                elevated.GetComponent<TilemapRenderer>().sortingOrder = 2;
                pharaoh.GetComponent<SpriteRenderer>().sortingOrder = 3;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
