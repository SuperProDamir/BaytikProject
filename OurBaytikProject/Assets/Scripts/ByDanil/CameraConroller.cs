using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 offset;
    public float sensitive = 5f;
    private float rotX = 0;
    private float rotY = 0;
    private Quaternion originalRot;
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRot = transform.localRotation;
    }

    
    void Update()
    {
        transform.position = player.transform.position + offset;
        
        rotX += Input.GetAxis("Mouse X") * sensitive;
        rotY += Input.GetAxis("Mouse Y") * sensitive;
        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);
        transform.localRotation = originalRot * xQuaternion * yQuaternion;
    }
}
