using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerMenuState : MonoBehaviour
{
    [Header("Audio")]
    public AudioEffectSO menuSwap;
    public AudioEffectSO menuClick;
    [Header("Text")]
    public Text TwoPlayer;
    public Text FourPlayer;
    public Text Controls;
    public Text Exit;
    public Text Controllers;
    public Text SwitchToC;
    public Text Keyboard;
    public Text SwitchToK;
    public GameObject controlPanel;
    public GameObject controlButtons;

    public GameObject player1readyS;
    public GameObject player2readyS;

    public GameObject player1readyT;
    public GameObject player2readyT;
    public GameObject player3readyT;
    public GameObject player4readyT;

    public float dpadH; 
    public float dpadV;
    public float Timer;

    public enum menuState
    {
        TwoPlayer,
        FourPlayer,
        Controls,
        Exit,
        Controllers,
        SwitchToControllers,
        ReadyS,
        ReadyT
    }

    public menuState selectedMenu;

    void Start()
    {

    }

    void Update()
    {
        dpadH = Input.GetAxis("DpadH");
        dpadV = Input.GetAxis("DpadV");
        bool p1a = Input.GetButton("P1A");
        bool p2a = Input.GetButton("P2A");
        bool p3a = Input.GetButton("P3A");
        bool p4a = Input.GetButton("P4A");
        bool p1b = Input.GetButton("P1B");
        bool p2b = Input.GetButton("P2B");
        bool p3b = Input.GetButton("P3B");
        bool p4b = Input.GetButton("P4B");

        #region TwoPlayer
        if (selectedMenu == menuState.TwoPlayer)
        {
            TwoPlayer.GetComponent<Outline>().enabled = true;
            FourPlayer.GetComponent<Outline>().enabled = false;
            if (TwoPlayer.GetComponent<MenuJiggle>().Switch == false)
            {
                TwoPlayer.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (dpadV == -1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.FourPlayer;
            }
            if (p1a == true || p2a == true && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuClick.Play();
                selectedMenu = menuState.ReadyS;
            }
            if (controlPanel.activeSelf == true)
            {
                if (dpadH == -1 && Timer < Time.timeSinceLevelLoad)
                {
                    Timer = Time.timeSinceLevelLoad + 0.2f;
                    TwoPlayer.GetComponent<Outline>().enabled = false;
                    FourPlayer.GetComponent<Outline>().enabled = false;
                    Exit.GetComponent<Outline>().enabled = false;
                    Controls.GetComponent<Outline>().enabled = false;
                    menuSwap.Play();
                    selectedMenu = menuState.Controllers;
                }
            }
        }
        #endregion

        #region FourPlayer
        else if (selectedMenu == menuState.FourPlayer)
        {
            TwoPlayer.GetComponent<Outline>().enabled = false;
            FourPlayer.GetComponent<Outline>().enabled = true;
            Controls.GetComponent<Outline>().enabled = false;
            if (FourPlayer.GetComponent<MenuJiggle>().Switch == false)
            {
                FourPlayer.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (dpadV == -1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.Controls;
            }
            if (dpadV == 1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.TwoPlayer;
            }
            if (p1a == true || p2a == true || p3a == true || p4a == true && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuClick.Play();
                selectedMenu = menuState.ReadyT;
            }
            if (controlPanel.activeSelf == true)
            {
                if (dpadH == -1 && Timer < Time.timeSinceLevelLoad)
                {
                    Timer = Time.timeSinceLevelLoad + 0.2f;
                    TwoPlayer.GetComponent<Outline>().enabled = false;
                    FourPlayer.GetComponent<Outline>().enabled = false;
                    Exit.GetComponent<Outline>().enabled = false;
                    Controls.GetComponent<Outline>().enabled = false;
                    menuSwap.Play();
                    selectedMenu = menuState.Controllers;
                }
            }
        }
        #endregion

        #region Controls
        else if (selectedMenu == menuState.Controls)
        {
            FourPlayer.GetComponent<Outline>().enabled = false;
            Exit.GetComponent<Outline>().enabled = false;
            Controllers.GetComponent<Outline>().enabled = false;
            Keyboard.GetComponent<Outline>().enabled = false;
            Controls.GetComponent<Outline>().enabled = true;
            if (Controls.GetComponent<MenuJiggle>().Switch == false)
            {
                Controls.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (dpadV == -1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.Exit;
            }
            if (dpadV == 1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.FourPlayer;
            }
            if (p1a == true && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuClick.Play();
                ActivateMenu();
            }
            if (controlPanel.activeSelf == true)
            {
                if (dpadH == -1 && Timer < Time.timeSinceLevelLoad)
                {
                    Timer = Time.timeSinceLevelLoad + 0.2f;
                    TwoPlayer.GetComponent<Outline>().enabled = false;
                    FourPlayer.GetComponent<Outline>().enabled = false;
                    Exit.GetComponent<Outline>().enabled = false;
                    Controls.GetComponent<Outline>().enabled = false;
                    menuSwap.Play();
                    selectedMenu = menuState.Controllers;
                }
            }
        }
        #endregion

        #region Exit
        else if (selectedMenu == menuState.Exit)
        {
            Controls.GetComponent<Outline>().enabled = false;
            Exit.GetComponent<Outline>().enabled = true;
            if (Exit.GetComponent<MenuJiggle>().Switch == false)
            {
                Exit.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (dpadV == 1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.Controls;
            }
            if (p1a == true && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuClick.Play();
                ActivateMenu();
            }
            if (controlPanel.activeSelf == true)
            {
                if (dpadH == -1 && Timer < Time.timeSinceLevelLoad)
                {
                    Timer = Time.timeSinceLevelLoad + 0.2f;
                    TwoPlayer.GetComponent<Outline>().enabled = false;
                    FourPlayer.GetComponent<Outline>().enabled = false;
                    Exit.GetComponent<Outline>().enabled = false;
                    Controls.GetComponent<Outline>().enabled = false;
                    menuSwap.Play();
                    selectedMenu = menuState.Controllers;
                }
            }
        }

        #endregion

        #region controllers
        else if (selectedMenu == menuState.Controllers)
        {
            TwoPlayer.GetComponent<Outline>().enabled = false;
            FourPlayer.GetComponent<Outline>().enabled = false;
            Controls.GetComponent<Outline>().enabled = false;
            Exit.GetComponent<Outline>().enabled = false;
            SwitchToC.GetComponent<Outline>().enabled = false;
            SwitchToK.GetComponent<Outline>().enabled = false;
            Controllers.GetComponent<Outline>().enabled = true;
            Keyboard.GetComponent<Outline>().enabled = true;
            if (Controllers.GetComponent<MenuJiggle>().Switch == false)
            {
                Controllers.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (Keyboard.GetComponent<MenuJiggle>().Switch == false)
            {
                Keyboard.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (dpadH == -1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.SwitchToControllers;
            }
            if (dpadH == 1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.Controls;
            }
            if (p1a == true && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuClick.Play();
                ActivateMenu();
            }
        }

        #endregion

        #region SwitchTo
        else if (selectedMenu == menuState.SwitchToControllers)
        {
            Keyboard.GetComponent<Outline>().enabled = false;
            Controllers.GetComponent<Outline>().enabled = false;
            SwitchToK.GetComponent<Outline>().enabled = true;
            SwitchToC.GetComponent<Outline>().enabled = true;
            if (SwitchToC.GetComponent<MenuJiggle>().Switch == false)
            {
                SwitchToC.GetComponent<MenuJiggle>().StartCoroutine("MenujiggleSwitch");
            }
            if (SwitchToK.GetComponent<MenuJiggle>().Switch == false)
            {
                SwitchToK.GetComponent<MenuJiggle>().StartCoroutine("MenujiggleSwitch");
            }
            if (dpadH == 1 && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuSwap.Play();
                selectedMenu = menuState.Controllers;
            }
            if (p1a == true && Timer < Time.timeSinceLevelLoad)
            {
                Timer = Time.timeSinceLevelLoad + 0.2f;
                menuClick.Play();
                ActivateMenu();
            }
        }
        #endregion

        else if (selectedMenu == menuState.ReadyS)
        {
            player1readyS.SetActive(true);
            if (p2a == true)
            {
                player2readyS.SetActive(true);
            }
            if (player1readyS.activeSelf == true && player2readyS.activeSelf == true)
            {
                ActivateMenu();
            }
            if (p1b == true)
            {
                player1readyS.SetActive(false);
                selectedMenu = menuState.TwoPlayer;
            }
        }
        else if (selectedMenu == menuState.ReadyT)
        {
            player1readyT.SetActive(true);
            if (p2a == true)
            {
                player2readyT.SetActive(true);
            }
            if (p3a == true)
            {
                player3readyT.SetActive(true);
            }
            if (p4a == true)
            {
                player4readyT.SetActive(true);
            }
            if (player1readyT.activeSelf == true && player2readyT.activeSelf == true && player3readyT.activeSelf == true && player4readyT.activeSelf == true)
            {
                ActivateMenu();
            }
            if (p1b == true)
            {
                player1readyT.SetActive(false);
                selectedMenu = menuState.FourPlayer;
            }
        }

        Debug.Log(selectedMenu);
        switch (selectedMenu)   //Switch between states 
        {
            case (menuState.TwoPlayer):
                break;
            case (menuState.FourPlayer):
                break;
            case (menuState.Controls):
                break;
            case (menuState.Exit):
                break;
        }
    }

    public void ActivateMenu()
    {
        if (selectedMenu == menuState.ReadyS)
        {
            SceneManager.LoadScene("SinglePlayer");
        }
        if (selectedMenu == menuState.ReadyT)
        {
            SceneManager.LoadScene("MultiPlayer");
        }
        if (selectedMenu == menuState.Controls)
        {
            if (controlPanel.activeSelf == false)
            {
                controlPanel.SetActive(true);
            }
            else
            {
                controlPanel.SetActive(false);
            }
        }
        if (selectedMenu == menuState.Exit)
        {
            Application.Quit();
        }
        if (selectedMenu == menuState.Controllers)
        {
            if (controlPanel.transform.GetChild(0).gameObject.activeSelf == true)
            {
                controlButtons.transform.GetChild(1).gameObject.SetActive(false);
                controlPanel.transform.GetChild(0).gameObject.SetActive(false);
                controlPanel.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                controlButtons.transform.GetChild(1).gameObject.SetActive(true);
                controlPanel.transform.GetChild(0).gameObject.SetActive(true);
                controlPanel.transform.GetChild(1).gameObject.SetActive(false);
                Controllers.GetComponent<MenuJiggle>().Switch = false;
                if (Controllers.GetComponent<MenuJiggle>().Switch == false)
                {
                    Controllers.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
                }
            }
        }
        if (selectedMenu == menuState.SwitchToControllers)
        {
            if (controlButtons.transform.GetChild(3).gameObject.activeSelf == true)
            {
                GetComponent<ControllerMenuState>().enabled = true;
                GetComponent<MenuState>().enabled = false;
                controlButtons.transform.GetChild(3).gameObject.SetActive(false);
                ControlsController.KeyboardON = false;
            }
            else
            {
                GetComponent<ControllerMenuState>().enabled = false;
                GetComponent<MenuState>().enabled = true;
                controlButtons.transform.GetChild(3).gameObject.SetActive(true);
                ControlsController.KeyboardON = true;
                SwitchToC.GetComponent<MenuJiggle>().Switch = false;
                if (SwitchToC.GetComponent<MenuJiggle>().Switch == false)
                {
                    SwitchToC.GetComponent<MenuJiggle>().StartCoroutine("MenujiggleSwitch");
                }
            }
        }
    }
}
