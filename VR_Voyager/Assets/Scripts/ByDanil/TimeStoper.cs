using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStoper : MonoBehaviour
{
    public SlowMotion SlowMotion;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        // Debug.Log(col.name);
        if (col.tag.Equals("bullet"))
        {
            SlowMotion.slowMotion();

        }
        

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("bullet"))
        {
            SlowMotion.Normalise();
        }
    }

}
