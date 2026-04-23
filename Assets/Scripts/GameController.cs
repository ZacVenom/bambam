using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int moneyCount = 0;
    public int x = 0;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject bossSpawner;
    public GameObject pistol;
    public GameObject rifle;
    public GameObject shotgun;
    public GameObject sniper;
    public GameObject spawner4;
    public GameObject spawner5;
    public GameObject spawner6;
    public GameObject spawner7;
    public GameObject spawner8;
    public GameObject bossSpawner1;
    public GameObject bossSpawner2;

    public GameObject text;
    public GameObject ms;
    public GameObject dmg;
    public GameObject hp;
    public GameObject am;

    public GameObject rs;

    public GameObject au;
    public GameObject su;
    public GameObject ssu;



    public GameObject gr;
    public GameObject gu;

    int y = -150;
    bool canCont = true;

    bool gotAuto = false;
    bool gotGrenade = false;
    bool gotMoreGrenade = false;
    bool gotReloadSpeed = false;
    Player player;
    Gun gun;
    int rand = 0;

    public int countCoin;
    public int coins;
    public int trueCoin;

    int EVERY_WHAT = 10;
    private void Start()
    {
        moneyCount = 0;
        trueCoin = 0;
        x = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }
    private void Update()
    {
        GameObject[] gameObjectsCoins;
        gameObjectsCoins = GameObject.FindGameObjectsWithTag("Coin");
        countCoin = gameObjectsCoins.Length;

        if (coins > countCoin)
        {
            player.StartCoroutine(player.TemporarySpeed());
            if((trueCoin % 10) > ((trueCoin + (coins - countCoin))%10))
            {
                moneyCount += 10;
                canCont = true;
            }
            trueCoin += coins - countCoin;
        }
        coins = countCoin;
        //y = -150
        //1 = -200
        //2 = 0
        //3 = 200

        if (moneyCount % EVERY_WHAT == 0 && moneyCount > 5 && canCont == true)
        { 
            canCont = false;
            text.SetActive(true);
            rand = Random.Range(2, 4);
            if (rand == 2)
            {
                if (moneyCount >= 70 && gotAuto == false)
                {
                    au.SetActive(true);
                    au.transform.localPosition = new Vector3(0, y, 0);
                    su.SetActive(true);
                    su.transform.localPosition = new Vector3(-200, y, 0);
                    ssu.SetActive(true);
                    ssu.transform.localPosition = new Vector3(200, y, 0);
                }
                else
                {
                    if (moneyCount >= 50 && gotReloadSpeed == false)
                    {
                        rs.SetActive(true);
                        rs.transform.localPosition = new Vector3(-200, y, 0);
                    }
                    else
                    {
                        ms.SetActive(true);
                        ms.transform.localPosition = new Vector3(-200, y, 0);
                    }

                    dmg.SetActive(true);
                    dmg.transform.localPosition = new Vector3(0, y, 0);

                    if (moneyCount >= 90 && gotGrenade == false)
                    {
                        gr.SetActive(true);
                        gr.transform.localPosition = new Vector3(200, y, 0);
                    }
                    else if (moneyCount >= 100 && gotGrenade == true && gotMoreGrenade == false)
                    {
                        gu.SetActive(true);
                        gu.transform.localPosition = new Vector3(200, y, 0);
                    }
                    else
                    {
                        hp.SetActive(true);
                        hp.transform.localPosition = new Vector3(200, y, 0);
                    }
                }
            }
            else if (rand == 3)
            {
                if (moneyCount >= 70 && gotAuto == false)
                {
                    au.SetActive(true);
                    au.transform.localPosition = new Vector3(0, y, 0);
                    su.SetActive(true);
                    su.transform.localPosition = new Vector3(-200, y, 0);
                    ssu.SetActive(true);
                    ssu.transform.localPosition = new Vector3(200, y, 0);
                }
                else
                {
                    if (moneyCount >= 50 && gotReloadSpeed == false)
                    {
                        rs.SetActive(true);
                        rs.transform.localPosition = new Vector3(-200, y, 0);
                    }
                    else
                    {
                        ms.SetActive(true);
                        ms.transform.localPosition = new Vector3(-200, y, 0);
                    }
                    
                    dmg.SetActive(true);
                    dmg.transform.localPosition = new Vector3(0, y, 0);
                
                    if (moneyCount >= 90 && gotGrenade == false)
                    {
                        gr.SetActive(true);
                        gr.transform.localPosition = new Vector3(200, y, 0);
                    }
                    else if (moneyCount >= 100 && gotGrenade == true && gotMoreGrenade == false)
                    {
                        gu.SetActive(true);
                        gu.transform.localPosition = new Vector3(200, y, 0);
                    }
                    else
                    {
                        am.SetActive(true);
                        am.transform.localPosition = new Vector3(200, y, 0);
                    }

                }
            }
            Time.timeScale = 0;
        }

        if (moneyCount >= 30)
        {
            spawner1.SetActive(true);
        }
        if (moneyCount >= 40)
        {
            spawner2.SetActive(true);
        }
        if (moneyCount >= 50)
        {
            spawner3.SetActive(true);
            betterEnemy1();
        }
        if (moneyCount >= 60)
        {
            bossSpawner.SetActive(true);
        }
        if(moneyCount >= 90)
        {
            spawner4.SetActive(true);
            bossSpawner1.SetActive(true);
        }
        if(moneyCount >= 100)
        {
            spawner5.SetActive(true);
            betterEnemy2();
        }
        if (moneyCount >= 110)
        {
            spawner6.SetActive(true);
            spawner7.SetActive(true);
            spawner8.SetActive(true);
            bossSpawner2.SetActive(true);
        }

    }

    public void msUpgrade()
    {
        player.upgradeMS(2.5f);
        turnOff();
    }
    public void dmgUpgrade()
    {
        gun.upgradeDMG(20);
        turnOff();
    }
    public void hpUpgrade()
    {
        player.upgradeHP(50);
        turnOff();
    }
    public void ammoUpgrade()
    {
        gun.ACUpgrade(10);
        turnOff();
    }

    public void reloadUpgrade()
    {
        gun.reloadSpeedd(1);
        gotReloadSpeed = true;
        turnOff();
    }
    public void autoUpgrade()
    {
        gotAuto = true;
        gun.Automatic(1);
        pistol.SetActive(false);
        rifle.SetActive(true);
        turnOff();
    }
    public void shotgunUpgrade()
    {
        gotAuto = true;
        gun.Automatic(2);
        pistol.SetActive(false);
        shotgun.SetActive(true);
        turnOff();
    }
    public void sniperUpgrade()
    {
        gotAuto = true;
        gun.Automatic(3);
        Camera.main.orthographicSize = 10;
        pistol.SetActive(false);
        sniper.SetActive(true);
        turnOff();
    }
    public void grenades()
    {
        gotGrenade = true;
        gun.Bem();
        EVERY_WHAT = 20;
        turnOff();
    }
    public void grenadeUpgrade()
    {
        gun.gCounter();
        gotMoreGrenade = true;
        turnOff();
    }
    public void turnOff()
    {
        text.SetActive(false);
        ms.SetActive(false);
        dmg.SetActive(false);
        hp.SetActive(false);
        am.SetActive(false);
        rs.SetActive(false);
        au.SetActive(false);
        su.SetActive(false);
        ssu.SetActive(false);
        gr.SetActive(false);
        gu.SetActive(false);
        Time.timeScale = 1;

    }



    /*public void Money(int money)
    {
        moneyCount += money;
        canCont = true;
    }*/



    public void betterEnemy1()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in enemies)
        {
            Enemy enemy = Enemy.GetComponent<Enemy>();
            enemy.MoreMS(1);
        }
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject Boss in bosses)
        {
            Enemy enemy = Boss.GetComponent<Enemy>();
            enemy.MoreMS(1);
        }
    }
    public void betterEnemy2()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Enemy in enemies)
        {
            Enemy enemy = Enemy.GetComponent<Enemy>();
            enemy.MoreMS2(2);
        }
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        foreach (GameObject Boss in bosses)
        {
            Enemy enemy = Boss.GetComponent<Enemy>();
            enemy.MoreMS2(0.5f);
        }
    }
 
}
