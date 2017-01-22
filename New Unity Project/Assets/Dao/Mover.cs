using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.Dao;
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
    public List<string> allModels;
    public List<ImageModel> activeModels;
    const int ACTIVEPANES = 7;
    int activeTop;
    int activeBott;
	// Use this for initialization
	void Start () {
        //to implement: get list of models
        allModels = ImageModelDao.getUrls();
        
        mainPane = GameObject.FindGameObjectWithTag("MainPane").GetComponent(typeof(PicPane)) as PicPane;
        Debug.Assert(mainPane != null, "mainpane failed, bitch");

        System.Random r = new System.Random();
        mainPane.setImageModel(new ImageModel() { ImageUrl = allModels[r.Next() % allModels.Count] });


        infoPane = GameObject.FindWithTag("InfoPane");
        mainPane.loadImage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setInitalActiveModels(List<ImageModel> all)
    {
        int activeTop = allModels.Count+(ACTIVEPANES/2);
        int activeBottom = allModels.Count - (ACTIVEPANES / 2);
        for (int i = 0; i < ACTIVEPANES; i++)
        {
            if((activeTop-i) < allModels.Count)
            {
                activeModels[activeModels.Count - i] = new ImageModel()
                {
                    ImageUrl
                    = allModels[allModels.Count - i]
                };

            }
            //activeModels[allModels.Count-i].
        }
        
    }

    void populateActive()
    {
        //to be implemented

    }


}
