using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSwitch : MonoBehaviour
{
    public static bool ConsoleBoostBool, Console, ConsoleGodModeBool;
    public GameObject VodkaCheck, GodmodeCheck, ConsoleShow;
    public float start;

    public void FixedUpdate()
    {
        if (Input.GetKeyDown("c") || Input.touchCount == 5)
        {
            ConsoleShow.SetActive(true);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void RestartLvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ConsoleBoost()
    {
        ConsoleBoostBool = VodkaCheck.GetComponent<Toggle>().isOn;
    }

    public void ConsoleGodMode()
    {
        ConsoleGodModeBool = GodmodeCheck.GetComponent<Toggle>().isOn;
    }
}
