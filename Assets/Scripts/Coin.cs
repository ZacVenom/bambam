using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.tag == "Player" || hitInfo.gameObject.tag == "Bullet")
        {
            //addMoney();
            Destroy(gameObject);
        }
    }
    /*void addMoney()
    {       
        Counter counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();
        counter.Money(1);
        GameController upgrades = GameObject.FindGameObjectWithTag("Upgrade").GetComponent<GameController>();
        upgrades.Money(1);
    }*/
}
