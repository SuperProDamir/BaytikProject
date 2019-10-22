using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float mouseSensetivity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Horizontal") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Vertical") * mouseSensetivity * Time.deltaTime;
    }
}
