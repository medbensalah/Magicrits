using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject effectOnEnemy;
    public GameObject effectOnPlayer;
    public GameObject parent;
    public float width;
    public static bool animatorLock = false;
    //public Animator effectOnEnemyAnimator;
    //public Animator effectOnPlayerAnimator;

    public static Crit enemy;

    public static Queue<KeyValuePair<Crit, string>> queue = new Queue<KeyValuePair<Crit, string>>();
    public static int count = 0;

    public Color green;
    public Color red;
    public Color yellow;
    public Color white;


    public static void PushToAnimationManager(KeyValuePair<Crit, string> message)
    {
        queue.Enqueue(message);
            count++;

    }

public static void setEnemy(Crit e)
    {
        enemy = e;
    }

    //private void Start()
    //{
    //    effectOnEnemyAnimator = effectOnEnemy.GetComponent<Animator>();
    //    effectOnPlayerAnimator = effectOnPlayer.GetComponent<Animator>();
    //}

    // Update is called once per frame
    void Update()
    {
        if(count > 0)
        {
            FightManager.locked = true;
            if (!animatorLock)
                StartCoroutine(Display());
        }
    }

    IEnumerator Display()
    {
        animatorLock = true;
        KeyValuePair<Crit, string> message = queue.Peek();
        GameObject go;
        if (message.Key == enemy)
        {
            go = Instantiate(effectOnEnemy, parent.transform);
        }
        else
        {
            go = Instantiate(effectOnPlayer, parent.transform);
        }
        if (go.GetComponent<Animator>().GetCurrentAnimatorStateInfo(-1).tagHash == 0)
        {
            SetEffect(go.GetComponent<TextMeshProUGUI>() , message.Value);
                

            go.GetComponent<Animator>().Play("DisplayEffect", -1, 0f);
            count--;
            queue.Dequeue();
            Destroy(go, 0.6f);
            yield return new WaitForSeconds(0.3f);
            animatorLock = false;
        }
        if( count == 0)
        {
            yield return new WaitForSeconds(0.7f);
            FightManager.locked = false;
        }
        
    }

    public void SetEffect(TextMeshProUGUI text, string message)
    {
        text.text = message;
        if (message[0] == '-')
        {
            text.color = red;
        }
        else if (message.Equals("Confuse") || message.Equals("Sleep")){
            text.color = yellow;
        }
        else if (message.ToLower().Contains("heal"))
        {
            text.color = green;
        }
        else
        {
            text.color = white;
        }
    }

}
