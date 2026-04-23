using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float radius = 1.5f;
    void Start()
    {
        StartCoroutine(wait(0.3f));
    }
    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach(Collider2D col in enemyHit)
        {
            Enemy enemy = col.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamageGrenade(100);
            }
        }
    }
    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
