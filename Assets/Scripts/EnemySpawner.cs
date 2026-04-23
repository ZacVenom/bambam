using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;
    int x = 0;
    public float y = 4;
    public float z = 6;
    bool playerNear = false;
    bool nextSpawn = false;
    public Transform target;
    void Start()
    {
        Instantiate(Enemy,transform.position,transform.rotation);
    }
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        float distance = Vector2.Distance(target.transform.position, transform.position);
        if (distance >= 7.5)
        {
            WaitPre();
            playerNear = false;
        }
        else
        {
            playerNear = true;
        }
        if (playerNear == false && nextSpawn == true)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            nextSpawn = false;
        }

    }
    void WaitPre()
    {
        if (x == 0)
        {
            StartCoroutine(Spawn());
            x = x + 1;
        }
    }
    IEnumerator Spawn()
    {
        float a = Random.Range(y,z);
        yield return new WaitForSeconds(a);
        if (playerNear == true) {
            nextSpawn = true;
        }       
        if (playerNear == false)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
        }
        x = x - 1;
    }
}
