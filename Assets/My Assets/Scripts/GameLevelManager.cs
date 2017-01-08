using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLevelManager : MonoBehaviour
{
    int currentlevel, requiredlevel1, requiredlevel2, requiredlevel3, requiredlevel4, requiredlevel5, requiredlevel6;
    public Text lvl1, lvl2, lvl3, lvl4, lvl5, lvl6;
    public GameObject lock1, lock2, lock3, lock4, lock5, lock6;

    void OnEnable()
    {
        Get_Setlevels();
    }

    void Get_Setlevels()
    {
        currentlevel = PlayerPrefs.GetInt("achvmnts");
        int level1 = PlayerPrefs.GetInt("lvl1");
        int level2 = PlayerPrefs.GetInt("lvl2");
        int level3 = PlayerPrefs.GetInt("lvl3");
        int level4 = PlayerPrefs.GetInt("lvl4");
        int level5 = PlayerPrefs.GetInt("lvl5");
        int level6 = PlayerPrefs.GetInt("lvl6");


        if (level1 > currentlevel)
        {
            requiredlevel1 = level1 - currentlevel;
            lvl1.text = requiredlevel1.ToString() + " Left to Unlock";
        }
        else
        {
            lvl1.text = "Unlocked";
            lock1.SetActive(false);
            PlayerPrefs.SetInt("lvl1unlocked", 1);
        }

        if (level2 > currentlevel)
        {
            requiredlevel2 = level2 - currentlevel;
            lvl2.text = requiredlevel2.ToString() + " Left to Unlock";
        }
        else
        {
            lvl2.text = "Unlocked";
            lock2.SetActive(false);
            PlayerPrefs.SetInt("lvl2unlocked", 1);
        }

        if (level3 > currentlevel)
        {
            requiredlevel3 = level3 - currentlevel;
            lvl3.text = requiredlevel3.ToString() + " Left to Unlock";
        }
        else
        {
            lvl3.text = "Unlocked";
            lock3.SetActive(false);
            PlayerPrefs.SetInt("lvl3unlocked", 1);
        }

        if (level4 > currentlevel)
        {
            requiredlevel4 = level4 - currentlevel;
            lvl4.text = requiredlevel4.ToString() + " Left to Unlock";
        }
        else
        {
            lvl4.text = "Unlocked";
            lock4.SetActive(false);
            PlayerPrefs.SetInt("lvl4unlocked", 1);
        }

        if (level5 > currentlevel)
        {
            requiredlevel5 = level5 - currentlevel;
            lvl5.text = requiredlevel5.ToString() + " Left to Unlock";
        }
        else
        {
            lvl5.text = "Unlocked";
            lock5.SetActive(false);
            PlayerPrefs.SetInt("lvl5unlocked", 1);
        }

        if (level6 > currentlevel)
        {
            requiredlevel6 = level6 - currentlevel;
            lvl6.text = requiredlevel5.ToString() + " Left to Unlock";
        }
        else
        {
            lvl6.text = "Unlocked";
            lock6.SetActive(false);
            PlayerPrefs.SetInt("lvl6unlocked", 1);
        }

    }

    #region button functions
    public void level1_play_click()
    {
        if (PlayerPrefs.GetInt("lvl1unlocked") == 1)
        {
            //TODO: Load Level
        }

    }

    public void level2_play_click()
    {
        if (PlayerPrefs.GetInt("lvl2unlocked") == 1)
        {
            //TODO: Load Level
        }

    }

    public void level3_play_click()
    {
        if (PlayerPrefs.GetInt("lvl3unlocked") == 1)
        {
            //TODO: Load Level
        }
    }

    public void level4_play_click()
    {
        if (PlayerPrefs.GetInt("lvl4unlocked") == 1)
        {
            //TODO: Load Level
        }
    }

    public void level5_play_click()
    {
        if (PlayerPrefs.GetInt("lvl5unlocked") == 1)
        {
            //TODO: Load Level
        }
    }

    public void level6_play_click()
    {
        if (PlayerPrefs.GetInt("lvl6unlocked") == 1)
        {
            //TODO: Load Level
        }
    }

    #endregion
}
