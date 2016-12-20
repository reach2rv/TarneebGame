using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{

    public Text CSilver;
    public Text CGold;
    public Text CSwag;
    public Text UserName;

    // Use this for initialization


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        updateinfo();
    }

    public void updateinfo()
    {
        CGold.text = PlayerPrefs.GetFloat("cGold").ToString();
        CSilver.text = PlayerPrefs.GetFloat("cSilver").ToString();
        CSwag.text = PlayerPrefs.GetFloat("cSwag").ToString();
        UserName.text =PlayerPrefs.GetString("displayName");
    }

}
