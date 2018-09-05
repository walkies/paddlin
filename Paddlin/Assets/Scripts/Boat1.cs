using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat1 : MonoBehaviour
{
    public GameObject p1L;
    public GameObject p1R;
    public GameObject p2L;
    public GameObject p2R;

    private float p1Timer;
    private float p1OTimer;
    private float p2Timer;
    private float p2OTimer;
    private float spinTimer;


    void FixedUpdate()
    {
        if(GetComponent<Rigidbody>().velocity.magnitude > 5.6f)
        {
            GetComponent<Rigidbody>().velocity *= 990f / 1000f;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.K))
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        p1OTimer = Time.timeSinceLevelLoad;
        p2OTimer = Time.timeSinceLevelLoad;

        #region baseMovement
        if (Input.GetKeyDown(KeyCode.A) && p1Timer < Time.timeSinceLevelLoad)
        {
            if (p1L.activeSelf == true)
            {
                PaddleLeft(p1L);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnLeft");
            }
            else
            {
                p1R.SetActive(false);
                p1L.SetActive(true);
                PaddleLeft(p1L);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.J) && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p2L.activeSelf == true)
            {
                PaddleLeft(p2L);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnLeft");
            }
            else
            {
                p2R.SetActive(false);
                p2L.SetActive(true);
                PaddleLeft(p2L);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnLeft");
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && p1Timer < Time.timeSinceLevelLoad)
        {
            if (p1R.activeSelf == true)
            {
                PaddleRight(p1R);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnRight");
            }
            else
            {
                p1L.SetActive(false);
                p1R.SetActive(true);
                PaddleRight(p1R);
                p1Timer = p1OTimer + 1;
                StartCoroutine("TurnRight");
            }
        }

        if (Input.GetKeyDown(KeyCode.L) && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p2R.activeSelf == true)
            {
                PaddleRight(p2R);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnRight");
            }
            else
            {
                p2L.SetActive(false);
                p2R.SetActive(true);
                PaddleRight(p2R);
                p2Timer = p2OTimer + 1;
                StartCoroutine("TurnRight");
            }
        }
        #endregion

        #region JointMovement
        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.J) && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p1L.activeSelf == true && (p2L.activeSelf == true))
            {
                PaddleLeft(p1L);
                PaddleLeft(p2L);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnLeft");
            }
            else
            {
                p1R.SetActive(false);
                p1L.SetActive(true);
                p2R.SetActive(false);
                p2L.SetActive(true);
                PaddleLeft(p1L);
                PaddleLeft(p2L);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnLeft");
            }
        }
        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.L) && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
        {
            if (p1R.activeSelf == true && (p2R.activeSelf == true))
            {
                PaddleRight(p1R);
                PaddleRight(p2R);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnRight");
            }
            else
            {
                p1L.SetActive(false);
                p1R.SetActive(true);
                p2L.SetActive(false);
                p2R.SetActive(true);
                PaddleRight(p1R);
                PaddleRight(p2R);
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("AdvancedTurnRight");
            }
        }

        if (Input.GetKeyDown(KeyCode.A) && Input.GetKeyDown(KeyCode.L))
        {
            if (p1L.activeSelf == true && (p2R.activeSelf == true))
            {
                StartCoroutine("MoveForwards");
            }
            else
            {
                p1R.SetActive(false);
                p1L.SetActive(true);
                p2L.SetActive(false);
                p2R.SetActive(true);
                StartCoroutine("MoveForwards");
            }
        }

        if (Input.GetKeyDown(KeyCode.D) && Input.GetKeyDown(KeyCode.J))
        {
            if (p1R.activeSelf == true && (p2L.activeSelf == true))
            {
                p1Timer = Time.timeSinceLevelLoad + 1;
                p2Timer = Time.timeSinceLevelLoad + 1;
                StartCoroutine("MoveForwards");
            }
            else
            {
                p1L.SetActive(false);
                p1R.SetActive(true);
                p2R.SetActive(false);
                p2L.SetActive(true);
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
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -3.2f), ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
    }

    public IEnumerator Timer(GameObject paddler)
    {
        yield return new WaitForSeconds(1f);
        PaddleReset(paddler);
    }

}
