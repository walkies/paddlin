using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sweeper : MonoBehaviour
{
    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Team1") || col.CompareTag("Team2"))
        {
            col.GetComponent<Rigidbody>().velocity *= 990f / 1000f;

        }
    }
}
