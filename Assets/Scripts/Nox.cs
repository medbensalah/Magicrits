using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nox : MonoBehaviour
{
    public DialogueManager dm;
    public AudioClip noxBGM;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!DialogueManager.inDialogue)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.transform.gameObject == gameObject && Input.GetMouseButtonDown(0) && !DialogueManager.inDialogue)
                {
                    dm.TriggerDialogue(0);
                    SoundManager.instance.PlayBGM(noxBGM);
                }
            }
        }
    }
}
