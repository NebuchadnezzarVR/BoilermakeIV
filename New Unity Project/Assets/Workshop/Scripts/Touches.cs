using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touches : MonoBehaviour {
    public Mover move;
    // Use this for initialization
    void Start()
    {
        move = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(Mover)) as Mover;
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;
    }

    void HandleTouchHandler (object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            //
        }
        else if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
        {
            move.nextPic();
        }
        else if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Down)
        {
            move.prevPic();
        }
        else if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Right)
        {
            UnityEngine.VR.InputTracking.Recenter();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            move.nextPic();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            move.prevPic();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
