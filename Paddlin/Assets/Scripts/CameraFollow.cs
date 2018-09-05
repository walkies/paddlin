using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject player;
    public float cameraHeight;

    void Update()
    {
        Vector3 pos = player.transform.position;
        pos.z = pos.z - 5; 
        pos.y += cameraHeight;
        transform.position = pos;
    }
}
