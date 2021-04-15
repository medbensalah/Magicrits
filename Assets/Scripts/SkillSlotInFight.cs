using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlotInFight : MonoBehaviour
{
    public FightInit fightInitializer;

    private void OnMouseEnter()
    {
        GetComponent<Image>().sprite = fightInitializer.golden;
        transform.GetChild(2).gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        GetComponent<Image>().sprite = fightInitializer.available;
        transform.GetChild(2).gameObject.SetActive(false);
    }
}
