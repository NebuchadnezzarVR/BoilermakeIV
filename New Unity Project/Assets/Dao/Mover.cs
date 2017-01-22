﻿using System.Collections;
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
        int n = r.Next() % allModels.Count;
        Debug.Log("Pic ID: "+n);
        mainPane.setImageModel(allModels[n]);

        setInitalActiveModels();

        for(int i = NUMACTIVEPANES; i > 0; i--)
        {
            activePanes.Add(new PicPane());
            activePanes[activePanes.Count-1].setImageModel(activeModels[activePanes.Count-1]);
            activePanes[activePanes.Count - 1].moveToPos(activePanes.Count - 1);
            Instantiate(activePanes[activePanes.Count - 1]);
            Debug.Log("added " + i);
        }

        infoPane = GameObject.FindWithTag("InfoPane");
        mainPane.loadImage();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void setInitalActiveModels()
    {
        Debug.Log("allModels Count: "+allModels.Count+ " stuff: "+ NUMACTIVEPANES/2);
        activeTop = allModels.Count+(NUMACTIVEPANES/2);
        activeBott = allModels.Count - (NUMACTIVEPANES/2);
        for (int i = 0; i < NUMACTIVEPANES; i++)
        {
            Debug.Log(activeBott + " x " + activeTop+" xx "+i);
            Debug.Log("Sums: "+i + (allModels.Count - (NUMACTIVEPANES / 2)));
            if (i+(allModels.Count-(NUMACTIVEPANES/2)) < allModels.Count)
            {
                activeModels[activeModels.Count - i] = allModels[allModels.Count - i];
                Debug.Log("added to active list");
            }
            
        }
        
    }

    void populateActive()
    {
        //infoPane = GameObject.FindGameObjectWithTag("InfoPane").GetComponent(typeof(InfoPane)) as InfoPane;
        //infoPane.setImageModel(activeModels[activeModels.Count/2]);

    }
    public void nextPic()
    {

    }
    public void prevPic()
    {

    }
    public void newPic()
    {
        mainPane = GameObject.FindGameObjectWithTag("MainPane").GetComponent(typeof(PicPane)) as PicPane;
        System.Random r = new System.Random();
        mainPane.setImageModel(allModels[r.Next() % allModels.Count]);
    }
}
