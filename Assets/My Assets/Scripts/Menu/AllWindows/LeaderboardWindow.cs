using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardWindow : Window {
    [SerializeField]
    private tk2dTextMesh Plase, Name, Lvl, Rank, Points;
    [SerializeField]
    private GameObject Example;
    [SerializeField]
    private GameObject Content;

    private const float Space = -0.7f;

    // Use this for initialization
    void Start () {
        float startPosition = Example.transform.localPosition.y;
        float x = Example.transform.localPosition.x;
        float z = Example.transform.localPosition.z;

        for (int i = 0; i < 100; i++) {
            Plase.text = (i + 1).ToString();
            GameObject go = Instantiate (Example) as GameObject;
            go.transform.parent = Content.transform;
            go.transform.localPosition = new Vector3 (x, startPosition + (i * Space), z);
        }

        Example.SetActive (false);
    }
}
