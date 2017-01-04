using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitConfirmUI : MonoBehaviour {

    public CanvasGroup uiCanvasGroup, confirmQuitCanvasGroup, UImatchwaiting;

    private void Awake()
    {
        //disable the quit confirmation panel
        DoConfirmQuitNo();
    }

    /// <summary>
    /// Called if clicked on No (confirmation)
    /// </summary>
    public void DoConfirmQuitNo()
    {
        Debug.Log("Back to the game");

        ////enable the normal ui
        uiCanvasGroup.alpha = 1;
        uiCanvasGroup.interactable = true;
        uiCanvasGroup.blocksRaycasts = true;

        //disable the confirmation quit ui
        confirmQuitCanvasGroup.alpha = 0;
        confirmQuitCanvasGroup.interactable = false;
        confirmQuitCanvasGroup.blocksRaycasts = false;

        UImatchwaiting.alpha = 0;
        UImatchwaiting.interactable = false;
        UImatchwaiting.blocksRaycasts = false;

    }

    /// <summary>
    /// Called if clicked on Yes (confirmation)
    /// </summary>
    public void DoConfirmQuitYes()
    {
        Application.Quit();
    }

    /// <summary>
    /// Called if clicked on Quit
    /// </summary>
    public void DoQuit()
    {
        //reduce the visibility of normal UI, and disable all interaction
        uiCanvasGroup.alpha = 0.5f;
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;

        //enable interaction with confirmation gui and make visible
        confirmQuitCanvasGroup.alpha = 1;
        confirmQuitCanvasGroup.interactable = true;
        confirmQuitCanvasGroup.blocksRaycasts = true;
    }

    public void match_waiting()
    {
        //reduce the visibility of normal UI, and disable all interaction
        uiCanvasGroup.alpha = 0.5f;
        uiCanvasGroup.interactable = false;
        uiCanvasGroup.blocksRaycasts = false;

        //enable interaction with confirmation gui and make visible
        UImatchwaiting.alpha = 1;
        UImatchwaiting.interactable = true;
        UImatchwaiting.blocksRaycasts = true;
    }

}
