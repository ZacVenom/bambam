using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //variables
    public float speed = 20f;
    public Rigidbody2D rb;
    public ParticleSystem hit;
    public int damage;
    private bool x = false;
    public int sniper = 0;
    void Start()
    {
        //rychlost bullet
        rb.linearVelocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //znici sa aj game object aj bullet
        //Vector3 asd = gameObject.transform.position;
        if(hitInfo.gameObject.tag == "Bullet")
        {
            return;
        }
        if (hitInfo.gameObject.tag == "Player")
        {
            return;
        }

        if (x == false){
            if (sniper == 1)
            {
                Instantiate(hit, transform.position, transform.rotation);

                Enemy enemy = hitInfo.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            else
            {
                x = true;
                Destroy(gameObject);
                Instantiate(hit, transform.position, transform.rotation);

                Enemy enemy = hitInfo.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                //Destroy(gameObject);
            }
        }
        
     }
        
    public void DMG(int damagee)
    {
        damage = damagee;
    }
    public void SniperYes()
    {
        sniper = 1;
    }
    
}
