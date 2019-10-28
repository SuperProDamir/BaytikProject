using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    
    public float SlowMoValue;
    public int NormalTime = 1;
    
    
    public void slowMotion()
    {
        Time.timeScale = SlowMoValue;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void Normalise()
    {
        Time.timeScale = NormalTime;

    }
}
