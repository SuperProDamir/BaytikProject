using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPosition : MonoBehaviour
{
    [SerializeField]
    Transform controller;
    string trName = "BeamR";

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            controller = GameObject.Find(trName).transform;
            if (controller != null)
            {
                transform.SetParent(controller);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
            }
        }
        catch
        {
            StartCoroutine(makeChildCoroutine());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator makeChildCoroutine()
    {
        while (controller == null)
        {
            yield return new WaitForSeconds(1f);

            makeChild();
        }
    }

    void makeChild()
    {
        controller = GameObject.Find(trName).transform;
        if (controller != null)
        {
            transform.SetParent(controller);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            Debug.Log("Controller is null!!!");
        }
    }
}
