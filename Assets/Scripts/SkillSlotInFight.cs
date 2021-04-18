using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotInFight : MonoBehaviour
{
    public FightInit fightInitializer;

    private void OnMouseEnter()
    {
        if (FightManager.locked == false)
        {
            GetComponent<Image>().sprite = fightInitializer.golden;
            transform.GetChild(2).gameObject.SetActive(true);
        }
        
    }
    private void Update()
    {
        if (FightManager.locked == true)
        {
            GetComponent<Image>().sprite = fightInitializer.locked;
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            GetComponent<Image>().sprite = fightInitializer.available;
        }
    }
    private void OnMouseExit()
    {
        GetComponent<Image>().sprite = fightInitializer.available;
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
