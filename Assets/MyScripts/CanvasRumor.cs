using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRumor : MonoBehaviour
{
    public Animator myAnim;
    public MyGameManager gameMan;
    public GameObject[] rumorsPanels;
    public GameObject nextBtn, previousBtn;

    GameObject currentSelectedPanel;
    int indexOfCurrentSelectedPanel = 0;

    private void Start()
    {
        currentSelectedPanel = rumorsPanels[0];
        if (indexOfCurrentSelectedPanel == 0)
        {
            previousBtn.SetActive(false);
        }
        Update_Current_Panel();
    }

    public void Start_Game()
    {
        StartCoroutine(startGameCouroutine());
    }

    IEnumerator startGameCouroutine()
    {
        yield return new WaitForEndOfFrame();
        gameMan.canPlay = true;

    }

    public void Start_Anim()
    {
        myAnim.Play("CanvasRumorHide");
    }
    

    void Update_Current_Panel()
    {
        currentSelectedPanel.SetActive(false);
        currentSelectedPanel = rumorsPanels[indexOfCurrentSelectedPanel];
        currentSelectedPanel.SetActive(true);
    }

    public void Next_Btn()
    {
        indexOfCurrentSelectedPanel++;
        previousBtn.SetActive(true);

        if (indexOfCurrentSelectedPanel == rumorsPanels.Length - 1)
        {
            nextBtn.SetActive(false);
        }
        Update_Current_Panel();
    }
    public void Previous_Btn()
    {
        indexOfCurrentSelectedPanel--;
        nextBtn.SetActive(true);
        if (indexOfCurrentSelectedPanel == 0)
        {
            previousBtn.SetActive(false);
        }
        Update_Current_Panel();
    }
}
