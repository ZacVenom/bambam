using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public Text txt;
    public int moneyCount = 0;
    public int x = 0;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject bossSpawner;
    public GameObject pistol;
    public GameObject rifle;
    public GameObject spawner4;
    public GameObject spawner5;
    public GameObject spawner6;
    public GameObject spawner7;
    public GameObject spawner8;
    public GameObject bossSpawner1;
    public GameObject bossSpawner2;
    int a = 0;
    bool canBuy = true;
    bool b = false;
    bool c = false;
    Player player;
    Gun gun;
    private void Start()
    {
        moneyCount = 0;
        x = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
    }
    /* 
      Deprecated legacy code to show off how bad it was
                                                       */
    private void Update()
    {
        if (Input.GetKey(KeyCode.O) && Input.GetKey(KeyCode.P))
        {
            moneyCount = 130;
            //x = 12;
        }
        if (moneyCount < 10)
        {
            txt.text = "Next Upgrade (10g): " + "\n" + "Move speed";
        }
        if (moneyCount >= 10 && x == 0)
        {
            Upgrade();
        }
        if (moneyCount < 20 && moneyCount >= 10)
        {
            txt.text = "Next Upgrade (20g): " + "\n" + "Damage";
        }
        if (moneyCount >= 20 && x == 1)
        {
            Upgrade();
        }
        if (moneyCount < 30 && moneyCount >= 20)
        {
            txt.text = "Next Upgrade (30g): " + "\n" + "Ammo count";
        }
        if (moneyCount >= 30 && x == 2)
        {
            Upgrade();
        }
        if (moneyCount < 40 && moneyCount >= 30)
        {
            txt.text = "Next Upgrade (40g): " + "\n" + "Reload speed";
        }
        if (moneyCount >= 40 && x == 3)
        {
            Upgrade();
        }
        if (moneyCount < 50 && moneyCount >= 40)
        {
            txt.text = "Next Upgrade (50g): " + "\n" + "More max HP";
        }
        if (moneyCount >= 50 && x == 4)
        {
            Upgrade();
        }
        if (moneyCount < 60 && moneyCount >= 50)
        {
            txt.text = "Next Upgrade (60g): " + "\n" + "More speed";
        }
        if (moneyCount >= 60 && x == 5)
        {
            Upgrade();
        }
        if (moneyCount < 70 && moneyCount >= 60)
        {
            txt.text = "Next Upgrade (70g): " + "\n" + "More damage";
        }
        if (moneyCount >= 70 && x == 6)
        {
            Upgrade();

        }
        if (moneyCount < 80 && moneyCount >= 70)
        {
            txt.text = "Next Upgrade (80g): " + "\n" + "Automatic rifle";
        }
        if (moneyCount >= 80 && x == 7)
        {
            Upgrade();
        }
        if (moneyCount < 90 && moneyCount >= 80)
        {
            txt.text = "Next Upgrade (90g): " + "\n" + "More speed";
        }
        if (moneyCount >= 90 && x == 8)
        {
            Upgrade();
        }
        if (moneyCount < 100 && moneyCount >= 90)
        {
            txt.text = "Next Upgrade (100g): " + "\n" + "More max HP";
        }
        if (moneyCount >= 100 && x == 9)
        {
            Upgrade();
        }
        if (moneyCount < 110 && moneyCount >= 100)
        {
            txt.text = "Next Upgrade (110g): " + "\n" + "50 round mag";
        }
        if (moneyCount >= 110 && x == 10)
        {
            Upgrade();
        }
        if (moneyCount < 120 && moneyCount >= 110)
        {
            txt.text = "Next Upgrade (120g): " + "\n" + "Grenades";
        }
        if (moneyCount >= 120 && x == 11)
        {
            Upgrade();
        }
        if (moneyCount < 130 && moneyCount >= 120)
        {
            txt.text = "Next Upgrade (130g): " + "\n" + "Faster grenade recharge";
        }
        if (moneyCount >= 130 && x == 12)
        {
            Upgrade();
        }
        if (moneyCount >= 130)
        {
            txt.text = "Damn, you finished the upgrades!, now survive :)";
        }
        if (a == 1)
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
        if (b == true) {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Enemy in enemies)
            {
                Enemy enemy = Enemy.GetComponent<Enemy>();
                if (enemy != null) {
                    enemy.lessHPBack2();
                }
            }
        }
        if (c == true)
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

   /* public void msUpgrade()
    {
        player.upgradeMS(2.5f);
    }
    public void dmgUpgrade()
    {
        gun.upgradeDMG(20);
    }
    public void hpUpgrade()
    {
        player.upgradeHP(50);
    }
    public void ammoUpgrade()
    {
        gun.ACUpgrade(6);
    }
    public void reloadUpgrade()
    {
        gun.reloadSpeedd(1);
    }
    public void autoUpgrade()
    {
        gun.Automatic(1);
        gun.ACUpgrade(19);
        pistol.SetActive(false);
        rifle.SetActive(true);
    }
    public void grenades()
    {
        gun.Bem();
    }
    public void grenadeUpgrade(){
        gun.gCounter();
    }
    public void Money(int money)
    {
        moneyCount += money;
    }*/
    void Upgrade()
    {
        if (moneyCount >= 10 && x == 0)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.upgradeMS(2.5f);
            x=1;
        }
        if (moneyCount >= 20 && x == 1)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.upgradeDMG(15);
            x=2;
        }
        if (moneyCount >= 30 && x == 2)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.ACUpgrade(6);
            x=3;
            spawner1.SetActive(true);
        }
        if (moneyCount >= 40 && x == 3)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.reloadSpeedd(1);
            x=4;
            spawner2.SetActive(true);
        }
        if (moneyCount >= 50 && x == 4)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.upgradeHP(150);
            x = 5;           
            spawner3.SetActive(true);
        }
        if (moneyCount >= 60 && x == 5)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.upgradeMS(2.5f);
            x = 6;
            bossSpawner.SetActive(true);            
        }
        if (moneyCount >= 70 && x == 6)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.upgradeDMG(25);
            x = 7;
            
        }
        if(moneyCount >= 80 && x == 7)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.Automatic(1);
            gun.ACUpgrade(19);
            pistol.SetActive(false);
            rifle.SetActive(true);
            x = 8;
            
        }
        if (moneyCount >= 90 && x == 8)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.upgradeMS(2.5f);
            x = 9;
            spawner4.SetActive(true);
            bossSpawner1.SetActive(true);
        }
        if (moneyCount >= 100 && x == 9)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            player.upgradeHP(200);
            x = 10;
            spawner5.SetActive(true);
        }
        if (moneyCount >= 110 && x == 10)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.ACUpgrade(19);
            a = 1;
            x = 11;
            spawner6.SetActive(true);
            spawner7.SetActive(true);
            spawner8.SetActive(true);
            bossSpawner2.SetActive(true);
        }
        if (moneyCount >= 120 && x == 11)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.Bem();
            x = 12;
        }
        if (moneyCount >= 130 && x == 12)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.gCounter();
            b = true;
            c = true;
            x = 13;
        }
    }
}
