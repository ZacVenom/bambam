using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Transform target;
    public int damage = 25;
    public int CD = 3;
    int x = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;
    public int hpBack = 25;
    public GameObject coin;
    private bool explosion = false;
    int a = 0;
    bool b = false;
    bool c = false;
    int d = 0;
    int e = 0;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
        slider.value = maxHealth;
    }
    void Update()
    {
        slider.maxValue = maxHealth;
        float distance = Vector2.Distance(target.transform.position, transform.position);
        if (maxHealth == 1000)
        {
            if (distance >= 4)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                WaitPre();
            }
        }
        else
        {
            if (distance >= 2.2)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else
            {
                WaitPre();
            }
        }

    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;
        slider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void TakeDamageGrenade(int damage)
    {
        if (!explosion)
        {
            explosion = true;
            currentHealth -= damage;
            slider.value = currentHealth;
            if (currentHealth <= 0)
            {
                Die();
            }
            StartCoroutine(CoolDown());
        }
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(0.2f);
        explosion = false;
    }
    void Die()
    {
        Destroy(gameObject);
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.addHP(hpBack);
        Instantiate(coin, transform.position, transform.rotation);
        if (maxHealth == 1000)
        {
            Instantiate(coin, transform.position, transform.rotation);
            Instantiate(coin, transform.position, transform.rotation);
            Instantiate(coin, transform.position, transform.rotation);
            Instantiate(coin, transform.position, transform.rotation);           
        }
    }

    void WaitPre()
    {
        if (x == 0)
        {
            StartCoroutine(Wait());
            x = x + 1;
        }
    }
    IEnumerator Wait() {
        DoDamage();
        yield return new WaitForSeconds(2);   
        x = x - 1;
    }
    void DoDamage()
    {
        Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamagePlayer(damage);
        }
    }
    public void MoreMS(int morems)
    {
        if (a == 0)
        {
            speed = speed + 4f;
            a = 1;           
        }
    }
    public void MoreMS2(float morems)
    {
        if (e == 0)
        {
            speed = speed + morems;
            e = 1;
        }
    }
    public void lessHPBack1()
    {
        if (b == false)
        {
            b = true;
            d += 1;
            lessHP();
        }
    }
    public void lessHPBack2()
    {
        if (c == false)
        {
            c = true;
            d += 1;
            lessHP();
        }
    }
    void lessHP()
    {
        if (d == 2)
        {
            hpBack = 15;
        }
    }


}
