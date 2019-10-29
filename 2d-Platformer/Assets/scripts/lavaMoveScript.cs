using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavaMoveScript : MonoBehaviour
{

    public Rigidbody2D RB;

    public float timeToStart;
    public float timer;
    public float lavaSpeed;

    void Start()
    {
        timeToStart = 3f;
        timer = 0f;
    }

    void Update()
    {
        
        if(timer > timeToStart)
        {
            RB.velocity = new Vector2(0, lavaSpeed);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
