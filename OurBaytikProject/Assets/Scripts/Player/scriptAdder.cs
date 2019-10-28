using System;
using System.Collections;
using System.Collections.Generic;
//using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class scriptAdder : MonoBehaviour
{
    Camera cam;
    bool a = true;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(cam.enabled == false && a)
        {
            a = false;
            int n = transform.childCount - 1;
            for (int i = 0; i < n; i++)
            {
                GameObject child = transform.GetChild(i).gameObject;
                Component comp = transform.GetComponent<PostProcessLayer>();
                Component ppl = CopyComponent(comp, child);
            }
        }*/
    }

    Component CopyComponent(Component original, GameObject destination)
    {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        // Copied fields can be restricted with BindingFlags
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields)
        {
            field.SetValue(copy, field.GetValue(original));
        }
        return copy;
    }


}
