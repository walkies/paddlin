using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat2 : MonoBehaviour
{
    public GameObject p3L;
    public GameObject p3R;
    public GameObject p4L;
    public GameObject p4R;

    private float p1Timer;
    private float p1OTimer;
    private float p2Timer;
    private float p2OTimer;
    private float spinTimer;


    void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.magnitude > 6.6f)
        {
            GetComponent<Rigidbody>().velocity *= 990f / 1000f;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        p1OTimer = Time.timeSinceLevelLoad;
        p2OTimer = Time.timeSinceLevelLoad;

        #region baseMovement
        if (Input.GetKeyDown(KeyCode.LeftArrow) && p1Timer < Time.timeSinceLevelLoad)
        {
            if (p3L.activeSelf == true)
            {
                PaddleLeft(p3L);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnLeft");
            }
            else
            {
                p3R.SetActive(false);
                p3L.SetActive(true);
                PaddleLeft(p3L);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p4L.activeSelf == true)
            {
                PaddleLeft(p4L);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnLeft");
            }
            else
            {
                p4R.SetActive(false);
                p4L.SetActive(true);
                PaddleLeft(p4L);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnLeft");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && p1Timer < Time.timeSinceLevelLoad)
        {
            if (p3R.activeSelf == true)
            {
                PaddleRight(p3R);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnRight");
            }
            else
            {
                p3L.SetActive(false);
                p3R.SetActive(true);
                PaddleRight(p3R);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnRight");
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad6) && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p4R.activeSelf == true)
            {
                PaddleRight(p4R);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnRight");
            }
            else
            {
                p4L.SetActive(false);
                p4R.SetActive(true);
                PaddleRight(p4R);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnRight");
            }
        }
        #endregion

        #region JointMovement
        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Keypad4) && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p3L.activeSelf == true && (p4L.activeSelf == true))
            {
                PaddleLeft(p3L);
                PaddleLeft(p4L);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnLeft");
            }
            else
            {
                p3R.SetActive(false);
                p3L.SetActive(true);
                p4R.SetActive(false);
                p4L.SetActive(true);
                PaddleLeft(p3L);
                PaddleLeft(p4L);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Keypad6) && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p3R.activeSelf == true && (p4R.activeSelf == true))
            {
                PaddleRight(p3R);
                PaddleRight(p4R);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnRight");
            }
            else
            {
                p3L.SetActive(false);
                p3R.SetActive(true);
                p4L.SetActive(false);
                p4R.SetActive(true);
                PaddleRight(p3R);
                PaddleRight(p4R);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnRight");
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.Keypad6))
        {
            if (p3L.activeSelf == true && (p4R.activeSelf == true))
            {
                StartCoroutine("MoveForwards");
            }
            else
            {
                p3R.SetActive(false);
                p3L.SetActive(true);
                p4L.SetActive(false);
                p4R.SetActive(true);
                StartCoroutine("MoveForwards");
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (p3R.activeSelf == true && (p4L.activeSelf == true))
            {
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("MoveForwards");
            }
            else
            {
                p3L.SetActive(false);
                p3R.SetActive(true);
                p4R.SetActive(false);
                p4L.SetActive(true);
                StartCoroutine("MoveForwards");
            }
        }
    }
    #endregion

    public void PaddleLeft(GameObject paddler)
    {
        StartCoroutine(Timer(paddler));
        LeanTween.rotate(paddler, new Vector3(-2, -201, -7), 0.5f).setEaseOutQuad();
    }

    public void PaddleRight(GameObject paddler)
    {
        StartCoroutine(Timer(paddler));
        LeanTween.rotate(paddler, new Vector3(2, 201, 7), 0.5f).setEaseOutQuad();
    }

    public void PaddleReset(GameObject paddler)
    {
        LeanTween.rotate(paddler, new Vector3(0, 180, 0), 0.5f).setEaseOutQuad();
    }


    public IEnumerator TurnLeft()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, -1f, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 1f, 0), ForceMode.Impulse);
    }

    public IEnumerator AdvancedTurnLeft()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, -2f, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 2f, 0), ForceMode.Impulse);
    }

    public IEnumerator TurnRight()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 1, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, -1, 0), ForceMode.Impulse);
    }

    public IEnumerator AdvancedTurnRight()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, 2, 0), ForceMode.Impulse);
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddTorque(new Vector3(0, -2, 0), ForceMode.Impulse);
    }

    public IEnumerator MoveForwards()
    {
        Debug.Log("working");
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -4.2f), ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Timer(GameObject paddler)
    {
        yield return new WaitForSeconds(1f);
        PaddleReset(paddler);
    }

}

