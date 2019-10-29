using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WVR_Log;
using wvr;
using UnityEngine.SceneManagement;

public class RestartGameScript : MonoBehaviour
{
    Checker player;
    private GameObject m_RightController;
    public bool isControllerFocus;
    [SerializeField]
    private Transform controller;


    WaveVR_Controller.EDeviceType curFocusControllerType = WaveVR_Controller.EDeviceType.Dominant;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Checker>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isControllerFocus)
        {
            if (WaveVR_Controller.Input(curFocusControllerType).GetPressDown(WVR_InputId.WVR_InputId_Alias1_Back))
            {
                RestartGame();
            }
            if (WaveVR_Controller.Input(curFocusControllerType).GetPressUp(WVR_InputId.WVR_InputId_Alias1_Touchpad))
            {
                //PutObject();
            }
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

}