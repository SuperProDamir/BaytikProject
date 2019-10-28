using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    [SerializeField] private float speed;
    private shotManage shotManage;
    public float sensitive = 5f;
    private float rotX = 0;
    //private float rotY = 0;
    public GameObject player;
    private Quaternion originalRot;
    public int health;
    private int maxHealth = 100;
    [SerializeField] private RectTransform healthBar;    
    void Start () {
        shotManage = GetComponent<shotManage>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb)
        {
            rb.freezeRotation = true;
        }
        originalRot = transform.localRotation;
	}
   // private float horizontal;
	void Update (){
        //horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward*Time.deltaTime*speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        if (Input.GetMouseButtonDown(0))
        {
            shotManage.Shot();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            rb.AddForce(transform.up * 10f, ForceMode.Impulse);
        }
        

        rotX += Input.GetAxis("Mouse X") * sensitive;
        //rotY += Input.GetAxis("Mouse Y") * sensitive;
        Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
        //Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);
        transform.localRotation = originalRot * xQuaternion; //* yQuaternion;


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("enemy"))
        {
            gameObject.SetActive(false);
        }
        if (collision.collider.tag.Equals("bullet"))
        {
            health = health - 10;
            
            healthBar.localScale = new Vector2(health / maxHealth, 1f);
        }
        if (health <= 0)
        {
            Debug.Log("you died");
        }
    }
    [SerializeField] private float bulletSpeed;
    private void shootManeger()
    {
        GetComponent<shotManage>();
    }
}
