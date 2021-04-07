using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//starting fight entery animation
public class FightLoaderOut : MonoBehaviour
{
    //reference to the animator gameobject
    public Animator animator;
    //reference to LOGO animator
    public Animator logo;
    //time to wait before changing game scene
    public float transitionTime = 1f;
    
    public void LoadFight(string animation)
    {
        //calling the animation updated overtime
        StartCoroutine(Load(animation));
    }

    IEnumerator Load(string animation)
    {
        //playing the animation
        animator.Play(animation);
        //showing the logo
        logo.Play("LOGO");
        //waiting for transition time asynchronously with partial return
        //meaning : ending the call but reentering the coroutine
        yield return new WaitForSeconds(transitionTime);
        if(SceneManager.GetActiveScene().name != "FightScene")
        {
            //change scene to fight scene
            SceneManager.LoadScene("FightScene");
        }
    }
}
