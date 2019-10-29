using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteSpike : MonoBehaviour
{
    
    void Update()
    {
        
        if(this.gameObject.transform.position.y < -20)
        {
            Destroy(this.gameObject);
        }

    }
}
