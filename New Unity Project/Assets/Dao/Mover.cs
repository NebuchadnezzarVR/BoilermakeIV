using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.Dao;
//using System.Diagnostics;

public class Mover : MonoBehaviour {
    //                     
    //          INITIAL POSITIONS
    // 
    //               /->[A]
    //active image ---->[A] [t]
    //list           \->[A] [t] <-\
    //                      [t] <---- All image list
    //                      [t] <-/
    //                      [t]
    //

    public PicPane mainPane;
    public GameObject infoPane;
    public List<ImageModel> allModels;
    public List<ImageModel> activeModels;
    public List<PicPane> activePanes;
    const int NUMACTIVEPANES = 7;
    int activeTop;
    int activeBott;
	// Use this for initialization
	void Start () {
        //to implement: get list of models

        allModels = ImageModelDao.Instance.GetImageModels();

        
        mainPane = GameObject.FindGameObjectWithTag("MainPane").GetComponent(typeof(PicPane)) as PicPane;
        Debug.Assert(mainPane != null, "mainpane failed, bitch");

        System.Random r = new System.Random();
        mainPane.setImageModel(allModels[r.Next() % allModels.Count]);

        allModels.Sort((x, y) => x.TimeTaken.CompareTo(y.TimeTaken));

        setInitalActiveModels();

        for(int i = NUMACTIVEPANES; i > 0; i--)
        {
            activePanes.Add(new PicPane());
            //activePanes[i].
        }

        infoPane = GameObject.FindWithTag("InfoPane");
        mainPane.loadImage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setInitalActiveModels()
    {
        int activeTop = allModels.Count+(NUMACTIVEPANES/2);
        int activeBottom = allModels.Count - (NUMACTIVEPANES / 2);
        for (int i = 0; i < NUMACTIVEPANES; i++)
        {
            if((activeTop-i) < allModels.Count)
            {

                activeModels[activeModels.Count - i] = allModels[allModels.Count - i];



            }
            
        }
        
    }

    void populateActive()
    {
        //to be implemented

    }


}
