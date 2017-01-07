using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour {

    protected object[] Param;

    public virtual void Open (object[] param = null) {
        Param = param;
        gameObject.SetActive (true);
    }

    public virtual void Close () {
        gameObject.SetActive (false);
    }
}
