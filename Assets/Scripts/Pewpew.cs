using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pewpew : MonoBehaviour
{
    public Rigidbody2D circle;
    public GameObject player;  
    public Rigidbody2D square;
    public SpriteRenderer gun;
    Quaternion abc;

    void Update()
    {
        //ked je circle nad 90', tak sa flipne zbran
        if(circle.rotation>=90f && circle.rotation<=180f || circle.rotation<=-90f && circle.rotation >= -180f)
        {
            gun.flipY = true;    
        }
        else
        {

            gun.flipY=false;
    
        }
        Vector3 pos = player.transform.position;
        circle.transform.position = pos;
        transform.position = square.transform.position;
        

    }
    
}
