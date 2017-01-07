using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum WindowsType {
    Settings, Achievements, Mail, DayliReward, DailyChallenge, Profile, Leaderboard
}

public enum PageType {
    MainMenu,
}

public class MainMenuController : MonoBehaviour {

    private Window ActiveWindow;
    private Page ActivePage;

    [SerializeField]
    private Window Settings;
    [SerializeField]
    private Window Achievements;
    [SerializeField]
    private Window DailyChallenge;
    [SerializeField]
    private Window DayliReward;
    [SerializeField]
    private Window Leaderboard;
    [SerializeField]
    private Window Mail;
    [SerializeField]
    private Window Profile;

    [Space]
    [SerializeField]
    private Page MainMenu;

    private Dictionary<WindowsType, Window> AllWindows = new Dictionary<WindowsType, Window> ();
    private Dictionary<PageType, Page> AllPage = new Dictionary<PageType, Page> ();

    void Start () {
        AllWindows.Add (WindowsType.Settings, Settings);
        AllWindows.Add (WindowsType.Achievements, Achievements);
        AllWindows.Add (WindowsType.DailyChallenge, DailyChallenge);
        AllWindows.Add (WindowsType.DayliReward, DayliReward);
        AllWindows.Add (WindowsType.Leaderboard, Leaderboard);
        AllWindows.Add (WindowsType.Mail, Mail);
        AllWindows.Add (WindowsType.Profile, Profile);

        AllPage.Add (PageType.MainMenu, MainMenu);
    }

    private void ButtonOpenNewWindow (string name) {
        OpenNewWindow ((WindowsType)Enum.Parse(typeof (WindowsType), name));
    }

    public void OpenNewWindow (WindowsType windowsType) {
        if (ActiveWindow != null) {
            ActiveWindow.Close ();
        }

        ActiveWindow = AllWindows[windowsType];
        AllWindows[windowsType].Open();
    }

    public void CloseWindow () {
        if (ActiveWindow != null) {
            ActiveWindow.Close ();
        }
    }

    private void ButtonOpenNewPage (string name) {
        OpenNewPage ((PageType)Enum.Parse (typeof (PageType), name));
    }

    public void OpenNewPage (PageType pageType) {
        if (ActivePage != null) {
            ActivePage.Close ();
        }

        ActivePage = AllPage[pageType];
        AllPage[pageType].Open ();
    }

    public void ClosePage () {
        if (ActivePage != null) {
            ActivePage.Close ();
        }
    }
}
