using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Buttons : MonoBehaviour
{
    public Text text;
    public GameObject textG;
    public GameObject play;
    public GameObject con;
    public GameObject exi;
    public GameObject textP;
    public GameObject controls;
    public AudioMixer audioMixer;

    int x = 3;
    public string txt;
    public void Start()
    {
        controls.SetActive(true);
        controls.SetActive(false);
    }
    public void PlayGame()
    {
        textG.SetActive(true);
        textP.SetActive(true);
        play.SetActive(false);
        con.SetActive(false);
        exi.SetActive(false);
        audioMixer.SetFloat("volume", GetFloat("VolumePref"));
        StartCoroutine(lol());
        text.text = (x).ToString();

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator lol()
    {
        Time.timeScale = 1;
        while (x>0) {
            yield return new WaitForSeconds(1);
            text.text = (x-1).ToString();
            x--;
        }
        x = 3;
        SceneManager.LoadScene(1);
    }
    public float GetFloat(string KeyName)
    {
        return PlayerPrefs.GetFloat(KeyName);
    }




}
