using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject player;
    public GameObject camerapos;
    void Update()
    {
        //Pozícia kamery je v sync s pozíciou hráča
        Vector3 pos = player.transform.position;
        pos.z = -10;
        camerapos.transform.position = pos;
    }
}
