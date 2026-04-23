using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{
    void Update()
    {
        if (Time.timeScale != 0)
        {
            //ani sam neviem co to je, ale funguje to
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 direc = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
            transform.right = direc;
        }
    }
}
