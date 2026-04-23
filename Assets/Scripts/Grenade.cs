using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private Vector2 targetPos;
    public GameObject explosion;

    private float speed = 5;
    void Start()
    {
        targetPos = GameObject.Find("Dir").transform.position;        
    }

    
    void Update()
    {
        if(speed > 0)
        {
            speed -= 0.02f;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
        else if (speed < 0)
        {
            speed = 0;
            StartCoroutine(Explode(1));
        }
    }
    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.gameObject.tag == "Enemy" || target.gameObject.tag == "Boss" || target.gameObject.tag == "Wall")
        {
         StartCoroutine(Explode(0));
        }
    }
}
