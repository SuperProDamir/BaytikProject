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
    //[SerializeField]
    //Transform lockerImage;
    public GameObject[] disable;

    PlayerSets player;


    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    public bool haveKeys = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSets>();
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
        if (lockerObject.activeSelf == false  && haveKeys)
        {
            lockerObject.SetActive(true);
            lockerObject.transform.LookAt(transform);
            lockerObject.transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    public void ExitPressed()
    {
        transform.position = new Vector3(-0.6f, 1f, 3f);
        StartCoroutine(teleport());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Trigger"))
        {
            SceneManager.LoadScene("2");
        }
    }

    IEnumerator teleport()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(1);
    }

    public void OpenDoor()
    {
        if (Enumerable.SequenceEqual(player.password, player.nicePassword))
        {
            Debug.Log("Door was opened");
            GameObject door = GameObject.Find("DoorPivot");
            door.GetComponent<Animator>().SetBool("isOpen", true);
            foreach (GameObject a in disable)
            {
                a.SetActive(false);
            }
        }
        else
        {
            Debug.Log("***Wrong password, try again!!! " + player.password.ToString());
            for (int i = 0; i < 3; i++)
            {
                player.password[i] = 0;
            }
            
        }
    }

    public void PassKey(string n)
    {
        string[] splited = n.Split('_');
        int column = Convert.ToInt32(splited[0]);
        int row = Convert.ToInt32(splited[1]);
        Debug.Log("***" + row);
        player.password[column - 1] = row;
    }
}
