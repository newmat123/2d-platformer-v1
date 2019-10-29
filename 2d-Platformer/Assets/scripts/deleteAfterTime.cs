using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAfterTime : MonoBehaviour
{
  
    private float timer;


    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 3)
        {
            Destroy(this.gameObject);
        }
    }
}
