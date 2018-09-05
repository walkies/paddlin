using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuState : MonoBehaviour
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

    public enum menuState
    {
        TwoPlayer,
        FourPlayer,
        Controls,
        Exit,
        Controllers,
        SwitchToControllers
    }

    public menuState selectedMenu;

    void Update()
    {
        #region TwoPlayer
        if (selectedMenu == menuState.TwoPlayer)
        {
            TwoPlayer.GetComponent<Outline>().enabled = true;
            FourPlayer.GetComponent<Outline>().enabled = false;
            if (TwoPlayer.GetComponent<MenuJiggle>().Switch == false)
            {
                TwoPlayer.GetComponent<MenuJiggle>().StartCoroutine("Menujiggle");
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.FourPlayer;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                menuClick.Play();
                ActivateMenu();
            }
            if (controlPanel.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
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
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.Controls;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.TwoPlayer;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                menuClick.Play();
                ActivateMenu();
            }
            if (controlPanel.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
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
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.Exit;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.FourPlayer;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                menuClick.Play();
                ActivateMenu();
            }
            if (controlPanel.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
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
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.Controls;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                menuClick.Play();
                ActivateMenu();
            }
            if (controlPanel.activeSelf == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
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
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.SwitchToControllers;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.Controls;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
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
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                menuSwap.Play();
                selectedMenu = menuState.Controllers;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                menuClick.Play();
                ActivateMenu();
            }
        }
        #endregion

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
        if (selectedMenu == menuState.TwoPlayer)
        {
            SceneManager.LoadScene("SinglePlayer");
        }
        if (selectedMenu == menuState.FourPlayer)
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
