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
        allModels = ImageModelDao.Instance.GetImageModels();

        mainPane = GameObject.FindGameObjectWithTag("MainPane").GetComponent(typeof(PicPane)) as PicPane;
        Debug.Assert(mainPane != null, "mainpane failed, bitch");
    }

    void HandleTouchHandler (object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.SingleTap)
        {
            System.Random r = new System.Random();
            mainPane.setImageModel(allModels[r.Next() % allModels.Count]);


            infoPane = GameObject.FindWithTag("InfoPane");
            mainPane.loadImage();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
