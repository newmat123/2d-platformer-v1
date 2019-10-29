using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{

    public GameObject startMenu;
    public GameObject text;

    void Start()
    {
        Time.timeScale = 0;
        text.SetActive(false);
        startMenu.SetActive(true);
    }

    public void startGame1()
    {
        startMenu.SetActive(false);
        text.SetActive(true);
        Time.timeScale = 1;
    }
}
