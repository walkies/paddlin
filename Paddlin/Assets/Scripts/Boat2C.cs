using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat2C : MonoBehaviour
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

    private float forwardsTimer;
    private float forwardsTimer2;

    public int P1FC;
    public int P2FC;
    public int P1FC2;
    public int P2FC2;

    void FixedUpdate()
    {
        P1FC++;
        P2FC++;
        P1FC2++;
        P2FC2++;

        bool p3x = Input.GetButton("P3X");
        bool p3a = Input.GetButton("P3A");
        bool p3b = Input.GetButton("P3B");
        bool p4x = Input.GetButton("P4X");
        bool p4a = Input.GetButton("P4A");
        bool p4b = Input.GetButton("P4B");

        if (GetComponent<Rigidbody>().velocity.magnitude > 5.6f)
        {
            GetComponent<Rigidbody>().velocity *= 990f / 1000f;
        }

        if (p3a == true || p4a == true)
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        p1OTimer = Time.timeSinceLevelLoad;
        p2OTimer = Time.timeSinceLevelLoad;

        #region JointMovement
        if (p3x == true && p4x == true && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
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
        if (p3b == true && p4b == true && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
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

        if (Input.GetKeyDown("joystick 3 button 2") && forwardsTimer < Time.timeSinceLevelLoad)
        {
            P1FC = 0;
            if (p3L.activeSelf == true)
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }

        if (Input.GetKeyDown("joystick 4 button 1") && forwardsTimer2 < Time.timeSinceLevelLoad)
        {
            P2FC = 0;
            if (p4R.activeSelf == true)
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }

        if (Input.GetKeyDown("joystick 3 button 1") && forwardsTimer < Time.timeSinceLevelLoad)
        {
            P1FC2 = 0;
            if (p3R.activeSelf == true)
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }
        if (Input.GetKeyDown("joystick 4 button 2") && forwardsTimer2 < Time.timeSinceLevelLoad)
        {
            P2FC2 = 0;
            if (p4L.activeSelf == true)
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }
        #region baseMovement
        if (p3x == true && p1Timer < Time.timeSinceLevelLoad)
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
        if (p4x == true && p2Timer < Time.timeSinceLevelLoad)
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

        if (p3b == true && p1Timer < Time.timeSinceLevelLoad)
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

        if (p4b == true && p2Timer < Time.timeSinceLevelLoad)
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
    }
    #endregion

    public void ForwardsAssit()
        {
            if (P1FC == 0 && P2FC <= 5 || P2FC == 0 && P1FC <= 5 || P1FC2 == 0 && P2FC2 <= 5 || P2FC2 == 0 && P1FC2 <= 5)
            {
                StartCoroutine("MoveForwards");
            }
            if (P1FC == 0 && P2FC <= 20 || P2FC == 0 && P1FC <= 20 || P1FC2 == 0 && P2FC2 <= 20 || P2FC2 == 0 && P1FC2 <= 20)
            {
                StartCoroutine("MoveForwardsWeak");
            }
        }


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

