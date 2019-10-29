using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSight : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    
    void Start()
    {
        target = GameObject.Find("head").transform;
    }

    
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime * 10f);
    }
}
