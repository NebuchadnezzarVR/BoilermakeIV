using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touches : MonoBehaviour {
   // public Mover move;
   private int test = 0;
    // Use this for initialization
    void Start()
    {
        OVRTouchpad.Create();
        OVRTouchpad.TouchHandler += HandleTouchHandler;

       // move = GameObject.FindGameObjectWithTag("MainCamera").GetComponent(typeof(Mover)) as Mover;
    }

    void HandleTouchHandler (object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
        }
        else if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Down)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
