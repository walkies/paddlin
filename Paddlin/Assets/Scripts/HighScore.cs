using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScore
{

    public static void HighScoreS(float time)
    {
        if (time < PlayerPrefs.GetFloat("HSS"))
        {
            PlayerPrefs.SetFloat("HSS", time);
        }
    }

    public static void HighScoreT(float time)
    {
        if (time < PlayerPrefs.GetFloat("HST"))
        {
            PlayerPrefs.SetFloat("HST", time);
        }
    }
}
