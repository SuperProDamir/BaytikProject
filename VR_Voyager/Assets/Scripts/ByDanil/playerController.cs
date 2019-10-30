using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;

public class playerController : MonoBehaviour {

    public SlowMotion SlowMotion;
    [SerializeField]
    private GameObject prefabs;

    [SerializeField]
    private Transform point;

    public bool havePistol = false;

    [SerializeField]
    private float reloadTime = 1.1f;
    [SerializeField]
    Animator animator;

    public GameObject pistolPrefab;
    [SerializeField]
    private GameObject pistol;

    [SerializeField]
    private float currentReloadTime = 1.1f;

    [SerializeField]
    private Transform controller;

    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    private void Start()
    {
        // animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (havePistol)
        {
            if (animator.GetBool("isShot") == true)
            {
                animator.SetBool("isShot", false);
            }
            if (currentReloadTime >= reloadTime)
            {
                if (WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad) ||
                    WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Trigger))
                {            
                    Debug.Log("!!!Shooting");
                    if (animator.GetBool("isShot") == true)
                    {
                        animator.SetBool("isShot", false);
                    }
                    Shot();
                }
            }
            if (currentReloadTime < reloadTime)
            {
                currentReloadTime += Time.fixedUnscaledDeltaTime;
                
            }
        }
    }

    public void PickPistol()
    {
        if (controller == null)
        {
            controller = GameObject.Find("Generic_MC_R(Clone)").transform;
        }
        havePistol = true;
        pistol = Instantiate(pistolPrefab, controller);
        animator = pistol.GetComponent<Animator>();
        point = pistol.transform.GetChild(0);
    }

    public void Shot()
    {
        GameObject bullet = Instantiate(prefabs, point.position, point.rotation);
        animator.SetBool("isShot", true);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(point.forward * 100f, ForceMode.Impulse);
        Destroy(bullet, 1.5f);
        //animator.SetBool("isShot", false);
        currentReloadTime = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("bullet"))
        {
            SlowMotion.Normalise();
            SceneManager.LoadScene(1);
        }
    }
}
