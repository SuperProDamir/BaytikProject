using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    Transform target;
    private shotManage shotManage;
    public GameObject prefabs;
    public Transform point;
    public float time;
    public float shootTime;
    public float force;
    private Vector3 botSpeed = Vector3.back;
    private bool lol = true;
    bool x = false;
    public float distance;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("ppp").transform;
    }

    
    void Update()
    {
        if (lol)
        {
            transform.LookAt(target);
            transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
            transform.Translate(botSpeed * Time.deltaTime * -6f);
        }
        else
        {
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            lol = false;
            startSooting();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("playerBullet"))
        {
            gameObject.SetActive(false);
        }
    }
    private void startSooting()
    {

        if (x == false)
        {
            StartCoroutine(instObj());
            x = true;
            
        }
    }
    IEnumerator instObj()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(shootTime);
            Shot();
        }
    }
    

    public void Shot()
    {
        //GameObject bullet = Instantiate(prefabs, transform.position + Vector3.forward, transform.rotation);
        GameObject bullet = Instantiate(prefabs, point.position, new Quaternion(point.rotation.x, point.rotation.y, point.rotation.z, point.rotation.w));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(point.forward * force, ForceMode.Impulse);
        Destroy(bullet, time);
    }

}
