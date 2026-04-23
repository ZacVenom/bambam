using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{

    public Text txt;
    void Update()
    {
        txt.text = "Most kills: " + PlayerPrefs.GetInt("HS", 0).ToString();
    }
}
