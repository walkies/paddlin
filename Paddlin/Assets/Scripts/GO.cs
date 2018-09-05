using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GO : MonoBehaviour
{

	void Start ()
    {
        LeanTween.scale(gameObject, new Vector3(1.4f, 1.4f, 1.4f), 0.8f);
	}

}
