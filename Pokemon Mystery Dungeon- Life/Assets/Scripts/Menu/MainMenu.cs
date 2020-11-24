using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetInt("save", 0);
        switch(PlayerPrefs.GetInt("save")) {
            case 1:
                GameObject.Find("MainMenu").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("MainMenu").transform.GetChild(0).gameObject.SetActive(false);
                break;
            default:
                GameObject.Find("MainMenu").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("MainMenu").transform.GetChild(1).gameObject.SetActive(false);
                break;
        }
    }
    public void PlayGame () {
        SceneManager.LoadScene("Overworld");
        PlayerPrefs.SetInt("overworldID", 0);
    }

    public void QuitGame () {
        Debug.Log("Quit");
        Application.Quit();
    }

    
}
