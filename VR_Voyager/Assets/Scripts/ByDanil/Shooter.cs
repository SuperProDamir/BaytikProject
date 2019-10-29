using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private shotManage shotManage;
    void Start()
    {
        shotManage = GetComponent<shotManage>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shotManage.Shot();
        }
    }
}
