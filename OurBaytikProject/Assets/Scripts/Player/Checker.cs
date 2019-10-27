using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;

public class Checker : MonoBehaviour
{
    [SerializeField]
    GameObject lockerObject;
    [SerializeField]
    Transform lockerImage;

    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    public bool haveKeys = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Trigger) ||
            WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Digital_Trigger) ||
            Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("2");
        }
    }

    public void LockerPressed()
    {
        Debug.Log("Button was pressed");
        if (lockerObject.activeSelf == false && Vector3.Distance(lockerImage.position, transform.position) <= 1.2 && haveKeys)
        {
            lockerObject.SetActive(true);
            lockerObject.transform.LookAt(transform);
            lockerObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Trigger"))
        {
            SceneManager.LoadScene("2");
        }
    }
}
