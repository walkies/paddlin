using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat1C : MonoBehaviour
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

    private float forwardsTimer;
    private float forwardsTimer2;

    public int P1FC;
    public int P2FC;
    public int P1FC2;
    public int P2FC2;

    public void FixedUpdate()
    {
        P1FC++;
        P2FC++;
        P1FC2++;
        P2FC2++;

        bool p1x = Input.GetButton("P1X");
        bool p1a = Input.GetButton("P1A");
        bool p1b = Input.GetButton("P1B");
        bool p2x = Input.GetButton("P2X");
        bool p2a = Input.GetButton("P2A");
        bool p2b = Input.GetButton("P2B");

        if (GetComponent<Rigidbody>().velocity.magnitude > 6.6f)
        {
            GetComponent<Rigidbody>().velocity *= 990f / 1000f;
        }

        if (p1a == true || p2a == true)
        {
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

        p1OTimer = Time.timeSinceLevelLoad;
        p2OTimer = Time.timeSinceLevelLoad;

        #region JointMovement
        if (p1a == true && p2a == true && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
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
        if (p1b == true && p2b == true && p1Timer < Time.timeSinceLevelLoad && p2Timer < Time.timeSinceLevelLoad)
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

        if (Input.GetKeyDown("joystick 1 button 2") && forwardsTimer < Time.timeSinceLevelLoad)
        {
            P1FC = 0;
            if (p1L.activeSelf == true)
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }

        if (Input.GetKeyDown("joystick 2 button 1") && forwardsTimer2 < Time.timeSinceLevelLoad)
        {
            P2FC = 0;
            if (p2R.activeSelf == true)
            {
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }

        if (Input.GetKeyDown("joystick 1 button 1") && forwardsTimer < Time.timeSinceLevelLoad)
        {
            P1FC2 = 0;
            if (p1R.activeSelf == true)
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }
        if (Input.GetKeyDown("joystick 2 button 2") && forwardsTimer2 < Time.timeSinceLevelLoad)
        {
            P2FC2 = 0;
            if (p2L.activeSelf == true)
            {
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
            else
            {
                forwardsTimer2 = Time.timeSinceLevelLoad + 0.5f;
                ForwardsAssit();
            }
        }
        #region baseMovement
        if (p1x == true && p1Timer < Time.timeSinceLevelLoad)
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
        if (p2x == true && p2Timer < Time.timeSinceLevelLoad)
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

        if (p1b == true && p1Timer < Time.timeSinceLevelLoad)
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

        if (p2b == true && p2Timer < Time.timeSinceLevelLoad)
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
    }
    #endregion

    public void ForwardsAssit()
    {
        if(P1FC == 0 && P2FC <=5 || P2FC == 0 && P1FC <= 5 || P1FC2 == 0 && P2FC2 <= 5 || P2FC2 == 0 && P1FC2 <= 5)
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

    public IEnumerator MoveForwardsWeak()
    {
        Debug.Log("working");
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -2.2f), ForceMode.Impulse);
        yield return new WaitForSeconds(1f);
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
