using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour
{

    public GameObject startMenu;

    void Start()
    {
        Time.timeScale = 0;
        startMenu.SetActive(true);
    }

    public void startGame1()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
