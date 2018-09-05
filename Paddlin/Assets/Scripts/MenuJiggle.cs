using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuJiggle : MonoBehaviour
{
    public bool Switch;

    public void Start()
    {
        if (gameObject.CompareTag("Title"))
        {
            StartCoroutine("Titlejiggle");
        }
    }

    public void Update()
    {

    }

    public IEnumerator Titlejiggle()
    {
        LeanTween.colorText(GetComponent<Text>().rectTransform, Color.green, 1);
        LeanTween.scale(gameObject, new Vector3(1.1f, 2.1f, 1.1f), 1);
        LeanTween.rotate(gameObject, new Vector3(0, 0, 4), 1);
        yield return new WaitForSeconds(1);
        LeanTween.colorText(GetComponent<Text>().rectTransform, Color.yellow, 1);
        LeanTween.scale(gameObject, new Vector3(1f, 2f, 1), 1);
        LeanTween.rotate(gameObject, new Vector3(0, 0, 0), 1);
        yield return new WaitForSeconds(1);
        StartCoroutine("Titlejiggle");
    }

    public IEnumerator Menujiggle()
    {
        Switch = true;
        LeanTween.scale(gameObject, new Vector3(0.7f, 0.6f, 1.1f), 1);
        yield return new WaitForSeconds(1);
        LeanTween.scale(gameObject, new Vector3(0.6f, 0.5f, 1), 1);
        yield return new WaitForSeconds(1);
        Switch = false;
    }
    public IEnumerator MenujiggleSwitch()
    {
        Switch = true;
        LeanTween.scale(gameObject, new Vector3(0.35f, 0.6f, 1f), 1);
        yield return new WaitForSeconds(1);
        LeanTween.scale(gameObject, new Vector3(0.3f, 0.5f, 1), 1);
        yield return new WaitForSeconds(1);
        Switch = false;
    }


}
