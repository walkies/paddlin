using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMeOff : MonoBehaviour
{

	void Start ()
    {
        StartCoroutine("NightNight");
	}

    public IEnumerator NightNight()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }

}
