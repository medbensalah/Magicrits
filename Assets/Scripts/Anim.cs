using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{

    private void AnimEnd()
    {
        Debug.Log(gameObject.name + "  end");
        FightManager.animLock = false;
    }


}
