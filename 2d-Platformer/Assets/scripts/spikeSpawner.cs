using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeSpawner : MonoBehaviour
{

    public GameObject Rock;

    private float timer;
    private float timeTo;

    void Start()
    {
        timer = 0;
        timeTo = Random.Range(1, 10);
    }

    void Update()
    {

        timer += Time.deltaTime;

        if(timer > timeTo)
        {

            Vector3 pos = new Vector3 (0, 120, 35.74822f);
            pos.x = Random.Range(-30, 30);

            Instantiate(Rock, pos, Quaternion.identity);

            timer = 0;
            timeTo = Random.Range(0.3f, 3f);
        }
    }
}
