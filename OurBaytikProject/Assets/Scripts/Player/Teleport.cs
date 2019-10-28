using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WaveVR_Log;
using wvr;
public class Teleport: MonoBehaviour,
IPointerEnterHandler,
IPointerExitHandler
{
    private const string LOG_TAG = "WaveVR_HelloVR";
    // WVR_DeviceType curFocusControllerType = WVR_DeviceType.WVR_DeviceType_HMD;
    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;
    public  bool isControllerFocus_R;

    [SerializeField]
    private Transform player;

    public Color colorOnEnter;
    public Color colorOnExit;

    private void Start()
    {
        colorOnExit = GetComponent<MeshRenderer>().material.color;
    }

    void Update()
    {
        if (isControllerFocus_R)
        {
            if (WaveVR_Controller.Input(curFocusControllerType).GetPressUp(WVR_InputId.WVR_InputId_Alias1_Touchpad) ||
                WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Digital_Trigger)||
                WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Trigger))
            {
                player.position = transform.position;
            }
        }
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        GetComponent<MeshRenderer> ().material.SetColor ("_Color", colorOnEnter);
        curFocusControllerType = eventData.enterEventCamera.gameObject.GetComponent<WaveVR_PoseTrackerManager>().Type;
        isControllerFocus_R = true;
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        isControllerFocus_R = false;
        GetComponent<MeshRenderer> ().material.SetColor ("_Color", colorOnExit);
     }
}