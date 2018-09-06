using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Manager : MonoBehaviour
{
    public Text time;
    public Text HS;
    public Text time2;
    public Text HS2;
    public Text finishTime;
    public Text Finish;
    public Text finishTime2;
    public Text Finish2;
    public Finish fin;
    public GameObject team1;
    public GameObject team2;

    public void Awake()
    {
        if (ControlsController.KeyboardON == true)
        {
            team1.GetComponent<Boat1>().enabled = true;
            team1.GetComponent<Boat1C>().enabled = false;
            if (SceneManager.GetActiveScene().name == ("MultiPlayer"))
            {
                team2.GetComponent<Boat2>().enabled = true;
                team2.GetComponent<Boat2C>().enabled = false;
            }
        }
        else
        {
            team1.GetComponent<Boat1>().enabled = false;
            team1.GetComponent<Boat1C>().enabled = true;
            if (SceneManager.GetActiveScene().name == ("MultiPlayer"))
            {
                team2.GetComponent<Boat2>().enabled = false;
                team2.GetComponent<Boat2C>().enabled = true;
            }
        }
    }

    public void Update()
    {
        time.text = ("" + Time.timeSinceLevelLoad.ToString("F1"));
        finishTime.text = ("" + (fin.EndTime.ToString("F1") + "s"));
        if (SceneManager.GetActiveScene().name == ("SinglePlayer"))
        {
            HS.text = ("" + PlayerPrefs.GetFloat("HSS").ToString("F1"));
        }
        else
        {
            finishTime2.text = ("" + (fin.EndTime.ToString("F1") + "s"));
            time2.text = ("" + Time.timeSinceLevelLoad.ToString("F1"));
            HS.text = ("" + PlayerPrefs.GetFloat("HST").ToString("F1"));
            HS2.text = ("" + PlayerPrefs.GetFloat("HST").ToString("F1"));
        }
    }
}
