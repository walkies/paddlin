using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rapids : MonoBehaviour
{
    public void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Team1") || col.CompareTag("Team2"))
        {
            col.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0.2f), ForceMode.Impulse);
        }
    }
}
