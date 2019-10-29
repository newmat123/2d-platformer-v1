using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DødVedFald : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "lava" || collision.gameObject.tag == "rock")
        {

            FindObjectOfType<cameraFollower>().removeFromList(this.gameObject.name);
            Destroy(this.gameObject);

        }
    }
}
