using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WVR_Log;
using wvr;

public class StartUnlocking : MonoBehaviour,
IPointerUpHandler,
IPointerEnterHandler,
IPointerExitHandler,
IPointerDownHandler,
IBeginDragHandler,
IDragHandler,
IEndDragHandler,
IDropHandler,
IPointerHoverHandler
{
    //private Ray ray;
    //private RaycastHit _hit;
    PlayerSets player;
    private GameObject m_RightController;
    public bool isControllerFocus;
    public Color color;

    [SerializeField]
    private bool isRed;
    [SerializeField]
    private bool isFinish = true;

    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSets>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isControllerFocus)
        {
            if (isRed == false)
            {
                if (WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Touchpad))
                {
                    Unlocking();
                    if (isFinish)
                    {
                        OpenDoor();
                    }
                }
            }
            else if (player.isUnlocking)
            {
                Cancel();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenDoor();
        }
    }

    private void OnDrawGizmos()
    {
        if (Input.GetMouseButton(0))
        {
            // Gizmos.DrawRay(ray);
        }
    }

    private void Unlocking()
    {
        player.isUnlocking = true;
        Debug.Log("Unlocking...");
    }

    private void Cancel()
    {
        player.isUnlocking = false;
        Debug.Log("Is Canceling");
    }

    public void OpenDoor()
    {
        Debug.Log("Door was opened");
        GameObject door = GameObject.Find("DoorPivot");
        door.GetComponent<Animator>().SetBool("isOpen", true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        WaveVR_Controller.EDeviceType type = eventData.enterEventCamera.gameObject.GetComponent<WaveVR_PoseTrackerManager>().Type;
        GameObject target = eventData.enterEventCamera.gameObject;
        if (target.GetComponent<WaveVR_PoseTrackerManager>())
        {
            if (type == WaveVR_Controller.EDeviceType.Dominant)
            {
                m_RightController = target;
                isControllerFocus = true;
            }

            // Right-Hand mode
            if (!WaveVR_Controller.IsLeftHanded)
            {
                if (isControllerFocus)
                {
                    //GetComponent<MeshRenderer>().material.SetColor("_Color", color);
                }
            }
            curFocusControllerType = type;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        RaycastHit hit;
        if (m_RightController && isControllerFocus)
        { //R_Controller Leave
            Vector3 fwd_R = m_RightController.transform.TransformDirection(Vector3.forward);
            if (!Physics.Raycast(m_RightController.transform.position, fwd_R, out hit))
            {

                isControllerFocus = false;
            }
        }

        curFocusControllerType = WaveVR_Controller.EDeviceType.Head;

        //GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("OnDrop");
    }

    public void OnPointerHover(PointerEventData eventData)
    {
        // Debug.Log("OnPointerHover: "+eventData.enterEventCamera.gameObject);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}