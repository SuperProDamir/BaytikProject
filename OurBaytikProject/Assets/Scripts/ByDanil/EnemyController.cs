using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    private shotManage shotManage;
    public GameObject obj;
    public GameObject prefabs;
    public Transform point;
    public float time;
    public float shootTime;
    public float force;
    void Start()
    {
        StartCoroutine(instObj());
    }

    
    void Update()
    {
        transform.LookAt(target);
        if (Vector3.Distance(obj.transform.position, transform.position) < 4)
        {
            
        }
    }
    IEnumerator instObj()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootTime);
            Shot();
        }
    }
    

    public void Shot()
    {
        //GameObject bullet = Instantiate(prefabs, transform.position + Vector3.forward, transform.rotation);
        GameObject bullet = Instantiate(prefabs, point.position, point.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(bullet, time);
    }

}
