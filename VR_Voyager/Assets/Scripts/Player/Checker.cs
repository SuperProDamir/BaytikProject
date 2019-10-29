using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using System;

public class Checker : MonoBehaviour
{
    [SerializeField]
    GameObject lockerObject;

     Animator doorPivot;

    PlayerSets player;

    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    public bool haveKeys = false;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerSets>();
        doorPivot = GameObject.Find("DoorPivot").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (//(WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Trigger) ||
            //WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Digital_Trigger) ||
            Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("2");
        }
    }

    public void PassKey(string s)
    {
        string[] n = s.Split('_');
        int column = Convert.ToInt32(n[0]);
        int row = Convert.ToInt32(n[1]);
        player.password[column - 1] = row;
    }

    public void LockerPressed()
    {
        Debug.Log("Button was pressed");
        if (haveKeys)
        {
            lockerObject.SetActive(true);
            lockerObject.transform.LookAt(transform);
            lockerObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    public void OpenDoor()
    {
        if (player.password.Equals(player.correctPassword))
        {
            doorPivot.SetBool("isOpen", true);
        }
        else 
        {
            player.password = new int[3] { 0, 0, 0};
        }
    }

    public void TeleporterPressed()
    {
        transform.position += Vector3.forward;
        StartCoroutine(teleport());
    }

    IEnumerator teleport()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}
