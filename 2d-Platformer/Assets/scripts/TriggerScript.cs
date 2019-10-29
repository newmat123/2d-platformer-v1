using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{


    public GameObject[] winHolder; //det er det gameobject der holder alt ui der skal wærer når man vinder


    public void BackBottun()//funktionen som skal køre når man klikker på knappen
    {
        for(int i = 0; i < winHolder.Length; i++)
        {
            winHolder[i].SetActive(false);//sætter win tilbage til false
        }
        
        Time.timeScale = 1; //starter tiden igen 
        
    }

    private void OnTriggerEnter2D(Collider2D collision) //kører når man rammer en trigger
    {
        if (collision.gameObject.tag == "trigger") // tjækker om triggeren er den rigtige
        {
            if(this.gameObject.tag == "player1")
            {
                winHolder[1].SetActive(true); //aktivere win ui
                Time.timeScale = 0; //pauser tiden eller spilet.
            }
            else if(this.gameObject.tag == "player2")
            {
                winHolder[0].SetActive(true); //aktivere win ui
                Time.timeScale = 0; //pauser tiden eller spilet.
            }
        }
    }
}
