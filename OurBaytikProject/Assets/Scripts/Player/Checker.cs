using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    [SerializeField]
    GameObject lockerObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LockerPressed()
    {
        Debug.Log("Button was pressed");
        if (lockerObject.activeSelf == false)
            lockerObject.SetActive(true);
    }

    public void OpenDoor()
    {
        Debug.Log("Door was opened");
    }
}
