using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaMoveScript : MonoBehaviour
{

    public Rigidbody2D RB;

    private float timeToStart;
    private float timer;

    void Start()
    {
        timeToStart = 3f;
        timer = 0f;
    }

    void Update()
    {
        
        if(timer > timeToStart)
        {
            RB.velocity = new Vector2(0, 3);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
