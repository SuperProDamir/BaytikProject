using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabController : MonoBehaviour
{
    private Ray ray;
    private RaycastHit _hit;
    private Camera cam;
    private Transform arm;

    // Start is called before the first frame update
    private void Start()
    {
        cam = Camera.main;
        arm = transform.GetChild(0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            GrabObject();
        }
        if (Input.GetMouseButtonUp(0))
        {
            DropObject();
        }
    }

    private void OnDrawGizmos()
    {
        if (Input.GetMouseButton(0))
        {
            Gizmos.DrawRay(ray);
        }
    }

    private void GrabObject()
    {      
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out _hit))
        {
            Debug.Log(_hit.collider.name);
            if (_hit.collider.tag == "Grab")
            {
                Transform item = _hit.collider.transform;
                item.SetParent(arm);
                item.localPosition = Vector3.zero;
            }
        }
    }

    private void DropObject()
    {
        if (arm.childCount > 0)
        {
            arm.GetChild(0).SetParent(null);
        }
    }
}
