using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public float EndTime;
    public float EndTime2;
    public Manager man;

    public void OnTriggerEnter(Collider col)
    {
        if (SceneManager.GetActiveScene().name == ("SinglePlayer"))
        {
            if (col.CompareTag("Team1"))
            {
                col.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -3), ForceMode.Impulse);
                for (int i = 1; i < 4; i++)
                {
                    col.transform.GetChild(i).gameObject.SetActive(false);
                }
                for (int i = 5; i < 8; i++)
                {
                    col.transform.GetChild(i).gameObject.SetActive(true);
                }
                Destroy(col.GetComponent<Boat1>());
                GetTime();
                StartCoroutine(End(4));
            }
        }
        else
        {
            if (col.CompareTag("Team1"))
            {
                col.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -3), ForceMode.Impulse);
                for (int i = 1; i < 4; i++)
                {
                    col.transform.GetChild(i).gameObject.SetActive(false);
                }
                for (int i = 5; i < 8; i++)
                {
                    col.transform.GetChild(i).gameObject.SetActive(true);
                }
                Destroy(col.GetComponent<Boat1>());
                GetTime();
                StartCoroutine(End(10));
            }

            else if (col.CompareTag("Team2"))
            {
                col.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -3), ForceMode.Impulse);
                for (int i = 1; i < 4; i++)
                {
                    col.transform.GetChild(i).gameObject.SetActive(false);
                }
                for (int i = 5; i < 8; i++)
                {
                    col.transform.GetChild(i).gameObject.SetActive(true);
                }
                Destroy(col.GetComponent<Boat2>());
                GetTime2();
                StartCoroutine(End(10));
            }
        }
    }
    public void GetTime()
    {
        EndTime = Time.timeSinceLevelLoad;
        man.time.gameObject.SetActive(false);
        man.finishTime.gameObject.SetActive(true);
        man.Finish.gameObject.SetActive(true);
        if (SceneManager.GetActiveScene().name == ("SinglePlayer"))
        {
            HighScore.HighScoreS(EndTime);
        }
        else
        {
            HighScore.HighScoreT(EndTime);
        }         
    }

    public void GetTime2()
    {
        EndTime2 = Time.timeSinceLevelLoad;
        man.time2.gameObject.SetActive(false);
        man.finishTime2.gameObject.SetActive(true);
        man.Finish2.gameObject.SetActive(true);
        HighScore.HighScoreT(EndTime2);
    }

    public IEnumerator End(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("MainMenu");
    }
}
