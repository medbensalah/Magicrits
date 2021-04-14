using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, ICritController
{
    public FightInit fightInitializer;
    public GameObject leftArrow;
    public GameObject rightArrow;

    public Sprite activeLeftArrow;
    public Sprite inactiveLeftArrow;
    public Sprite activeRightArrow;    
    public Sprite inactiveRightArrow;

    int lastPage;

    private int currentPage;
    private int pages;
    // Start is called before the first frame update
    void Start()
    {
        currentPage = 1;
        pages = fightInitializer.pages;
        if(pages > 1)
        {
            rightArrow.GetComponent<Image>().sprite = activeRightArrow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        lastPage = 4;
        if (pages > 1 && Input.GetMouseButtonDown(0))
        {
            if (hit)
            {
                if (hit.transform.gameObject.name.Equals(leftArrow.name) && currentPage != 1)
                {
                    currentPage--;
                    rightArrow.GetComponent<Image>().sprite = activeRightArrow;

                    if (currentPage == 1)
                    {
                        leftArrow.GetComponent<Image>().sprite = inactiveLeftArrow;
                    }

                }

                else if (hit.transform.gameObject.name.Equals(rightArrow.name) && currentPage != pages)
                {
                    currentPage++;
                    leftArrow.GetComponent<Image>().sprite = activeLeftArrow;

                    if (currentPage == pages)
                    {
                        rightArrow.GetComponent<Image>().sprite = inactiveRightArrow;
                    }
                }
                lastPage = (currentPage == pages) ? fightInitializer.nbSkills % 4 : 4;
                for (int i = 0; i < lastPage; ++i)
                {
                    fightInitializer.skillSlots[i].GetComponent<Image>().sprite = fightInitializer.available;
                    fightInitializer.skillSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = fightInitializer.skillInfo[fightInitializer.nbSkills - (i + 4 * (currentPage - 1)) - 1].name;
                    fightInitializer.skillSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = fightInitializer.elements[fightInitializer.skillInfo[fightInitializer.nbSkills - (i + 4 * (currentPage - 1)) - 1].type];
                }
                if (currentPage == pages)
                {
                    for (int i = lastPage; i < 4; ++i)
                    {
                        fightInitializer.skillSlots[i].GetComponent<Image>().sprite = fightInitializer.none;
                        fightInitializer.skillSlots[i].GetComponentInChildren<TextMeshProUGUI>().text = "";
                        fightInitializer.skillSlots[i].transform.GetChild(0).GetComponent<Image>().sprite = fightInitializer.noSymbol;
                    }
                }
            }
        }
    }
}
