using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touches : MonoBehaviour {
    public PicPane mainPane;
    public GameObject infoPane;
    public List<ImageModel> allModels;

    // Use this for initialization
    void Start()
    {
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;
    }

    void HandleTouchHandler (object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
