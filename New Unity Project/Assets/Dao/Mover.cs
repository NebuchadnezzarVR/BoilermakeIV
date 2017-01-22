using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public List<ImageModel> activeModels = new List<ImageModel>();
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
        populateActive(allModels[n]);
        
        setInitalActiveModels();

        for(int i = NUMACTIVEPANES; i > 0; i--)
        {
            activePanes.Add(gameObject.AddComponent(typeof(PicPane)) as PicPane);
            activePanes[activePanes.Count-1].setImageModel(activeModels[activePanes.Count-1]);
            activePanes[activePanes.Count - 1].moveToPos(activePanes.Count - 1- i);
            Instantiate(activePanes[activePanes.Count - 1]);
            Debug.Log("added " + i);
        }

 
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
            //Debug.Log(activeBott + " x " + activeTop+" xx "+i);
            //Debug.Log("Sums: " + i + (allModels.Count - (NUMACTIVEPANES / 2)));
            if (i+(allModels.Count-(NUMACTIVEPANES/2)) < allModels.Count)
            {
                //Debug.Log(allModels[i + (allModels.Count - (NUMACTIVEPANES / 2))].ToString());
                activeModels.Add(allModels[i + (allModels.Count - (NUMACTIVEPANES / 2))]);
                //Debug.Log("added to active list");
            }
            
        }
        
    }

    public Text Text;

    void populateActive(ImageModel m)
    {
        var x = Text.GetComponent<InfoPane>();
        x.ImageModel = m;

    }
    public void nextPic()
    {

    }
    public void prevPic()
    {

    }
    public void newPic()
    {
        Debug.Log("newPic() was called");
        mainPane = GameObject.FindGameObjectWithTag("MainPane").GetComponent(typeof(PicPane)) as PicPane;
        GameObject.FindGameObjectWithTag("InfoPane").GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        System.Random r = new System.Random();
        mainPane.setImageModel(allModels[r.Next() % allModels.Count]);
    }
}
