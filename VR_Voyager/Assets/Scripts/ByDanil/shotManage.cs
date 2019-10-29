using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotManage : MonoBehaviour
{
    [SerializeField] private GameObject prefabs;
   
    public void Shot() {
        GameObject bullet = Instantiate(prefabs, transform.position, transform.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 100f, ForceMode.Impulse);
        Destroy(bullet, 1.5f);
    }
}
