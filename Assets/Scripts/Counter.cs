using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text txt;
    public int count;
    public int kill;
    public int killcount = 0;
    public int money = 0;
    public int kills;


    //----------
    public int countCoin;
    public int coins;
    //----------
    
    void Update()
    {
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Enemy");   
        count = gameObjects.Length;
        //--------------
        GameObject[] gameObjectsCoins;
        gameObjectsCoins = GameObject.FindGameObjectsWithTag("Coin");
        countCoin = gameObjectsCoins.Length;

        if(coins > countCoin)
        {
            money += coins - countCoin;
        }
        coins = countCoin;
        //--------------

        if (kill > count)
        {
            killcount += kill - count;
        }       
        kill = count;
        txt.text = "    : " + killcount + "\n" + "    : " + money;
        if (killcount>=300)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Enemy in enemies)
            {
                Enemy enemy = Enemy.GetComponent<Enemy>();
                if (enemy != null) {
                enemy.lessHPBack1();
                }
            }
            
        }
        /*if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteKey("HS");
        }*/
    }
    /*public void Money(int moneycount)
    {
        money += moneycount;
    }*/
    public void Kills(int a)
    {
        if (PlayerPrefs.GetInt("HS") < killcount)
        {
            kills = killcount;
            PlayerPrefs.SetInt("HS", kills);
            
        }
        else
        {
            kills = PlayerPrefs.GetInt("HS");
            PlayerPrefs.SetInt("HS", kills);
        }
    }
}
