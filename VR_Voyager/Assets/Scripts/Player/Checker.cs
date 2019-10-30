using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using wvr;
using System;
using System.Linq;

public class Checker : MonoBehaviour
{
    [SerializeField]
    GameObject lockerObject;

     Animator doorPivot;

    PlayerSets player;

    [SerializeField]
    GameObject lockerCanvas;
    [SerializeField]
    GameObject teleportedCanvas;

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
        if (haveKeys)
        {
            Debug.Log("Button Pressed");
            lockerObject.SetActive(true);
            // lockerObject.transform.LookAt(transform);
            // lockerObject.transform.Rotate(new Vector3(0, 180, 0));
            lockerCanvas.SetActive(false);

        }
    }

    public void OpenDoor()
    {
        if (Enumerable.SequenceEqual(player.password, player.correctPassword))
        {
            Debug.Log("Opened");
            doorPivot.SetBool("isOpen", true);
            lockerObject.SetActive(false);
        }
        else 
        {
            player.password = new int[3] { 0, 0, 0};
        }
    }

    public void TeleporterPressed()
    {
        transform.position += new Vector3(0, 0, 1.5f);
        teleportedCanvas.SetActive(false);
        StartCoroutine(teleport());
    }

    IEnumerator teleport()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(1);
    }
}
