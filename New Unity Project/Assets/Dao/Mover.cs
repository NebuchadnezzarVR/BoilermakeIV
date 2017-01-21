using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
    //                     
    //          INITIAL POSITIONS
    // 
    //               ,->[A]
    //active image  --->[A] [t]
    //list           '->[A] [t] <-,
    //                      [t] <---- All image list
    //                      [t] <
    //                      [t]
    //
    public PicPane mainPane;
    public GameObject infoPane;
    public List<ImageModel> allModels;
    public List<ImageModel> activeModels;

	// Use this for initialization
	void Start () {
        //to implement: get list of models
        mainPane = GameObject.FindWithTag("InfoPane").GetComponent(typeof(PicPane)) as PicPane;
        infoPane = GameObject.FindWithTag("MainPane");
        mainPane.setActive();
        mainPane.loadImage();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setInitalActiveModels(List<ImageModel> all)
    {
       

    }

    void populateActive()
    {
        //to be implemented

    }


}
