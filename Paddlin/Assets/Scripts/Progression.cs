using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{
    public GameObject Team;
    public Slider prog;

    void Start ()
    {
        prog.value = -51;
    }

	void Update ()
    {
        prog.value = Team.transform.position.z; 
    }
}
