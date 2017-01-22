using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Dao;
//using System.Diagnostics;

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
    const int ACTIVEPANES = 7;
    int activeTop;
    int activeBott;
	// Use this for initialization
	void Start () {
        //to implement: get list of models
        allModels = ImageModelDao.Instnace.GetImageModels();
       
        mainPane = GameObject.FindGameObjectWithTag("MainPane").GetComponent(typeof(PicPane)) as PicPane;
        Debug.Assert(mainPane != null, "mainpane failed, bitch");
        infoPane = GameObject.FindWithTag("InfoPane");
        //mainPane.loadImage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setInitalActiveModels(List<ImageModel> all)
    {
        int activeTop = allModels.Count+(ACTIVEPANES/2);
        int activeBottom = allModels.Count - (ACTIVEPANES / 2);
        
    }

    void populateActive()
    {
        //to be implemented

    }


}
