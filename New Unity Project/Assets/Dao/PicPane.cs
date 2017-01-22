using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PicPane : MonoBehaviour {

    // Add this script to a GameObject. The Start() function fetches an
    // image from the documentation site.  It is then applied as the
    // texture on the GameObject.
    Dictionary<int,Vector3> possLocations = new Dictionary<int, Vector3>();
    Dictionary<int, int> possAng = new Dictionary<int, int>();
    public string url = "http://scontent-ort2-1.cdninstagram.com/t51.2885-15/e35/13414336_641685176008067_1785445179_n.jpg?ig_cache_key=MTI2ODMyNTgwNDQxMzM1Mjc2OA%3D%3D.2&se=7"; //Will be depreciated as soon as ImageMode is implemented
    public ImageModel myModel;


    public Transform target;
    public float speed = 5;
    int currindex = -1;


    IEnumerator Start() {
        if (possLocations.Count <= 0)
        {
            possLocations.Add(0, new Vector3(-1, ((float)-2.5), -1));
            possAng.Add(0, 90);
            possLocations.Add(1, new Vector3(-1, ((float)-2), ((float).5)));
            possAng.Add(1, 65);
            possLocations.Add(2, new Vector3(-1, ((float)-1), ((float)1.5)));
            possAng.Add(2, 40);
            possLocations.Add(3, new Vector3(-1, ((float)-.25), 2));
            possAng.Add(3, 20);

            possLocations.Add(4, new Vector3(-1, ((float)1.5), 2));
            possAng.Add(4, 0);

            possLocations.Add(5, new Vector3(-1, ((float)2.75), 2));
            possAng.Add(5, -20);
            possLocations.Add(6, new Vector3(-1, ((float)4), ((float)1.5)));
            possAng.Add(6, -40);
            possLocations.Add(7, new Vector3(-1, ((float)5), ((float).5)));
            possAng.Add(7, -65);
            possLocations.Add(8, new Vector3(-1, ((float)5.5), -1));
            possAng.Add(8, -90);
        }
        target = this.transform;
        return this.loadImage();
    }

    public IEnumerator loadImage()
    {
        var objectWidth = 750;
        var objectHeight = 1000;

        Debug.Log("here first you bastard");
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);
        var width = tex.width;
        var height = tex.height;
        
       /* if (width > 750)
        {
            double scale = 750.0 / width;
            height = (int)(scale * height);
            tex.Resize(width, height);
            tex.Apply();
        }
        if( height > 1000)
        {
            double scale = 750.0 / height;
            width = (int)(scale * width);
            tex.Resize(width, height);
            tex.Apply();
        }*/
        Debug.Log("Width: " + width + " Height: " + height);
        BoxCollider collider = GetComponent<BoxCollider>();
        float baseValue = 650.0f;
        float aspectRatio = width / (float)height;
        float w;
        float h;
        if(aspectRatio > 1)
        {
            w = 1;
            h = 1 / aspectRatio;
        }
        else
        {
            h = aspectRatio;
            w = 1;
        }

        if (collider != null)
        {
            collider.size = new Vector3(w, h, .1f);
        }
        //transform.position = new Vector3((1-obj.transform.localScale.x)/2+Xi, (1-obj.transform.localScale.y) / 2 + Yi, Zi);

        GetComponent<Renderer>().material.mainTexture = tex;
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
    public void setImageModel(ImageModel i)
    {
        if(i == null)
        {
            return;
        }
        myModel = i;
        url = i.ImageUrl;
        loadImage();
          
    }
    public void moveUp()
    {
        currindex++;
        target.position = possLocations[currindex];
        target.eulerAngles = new Vector3(possAng[currindex], 0, 180);
        if((currindex == possLocations.Count) || (currindex == 0))
        {
            Destroy(gameObject);
        }
    }
    public void moveDown()
    {
        currindex--;
        target.position = possLocations[currindex];
        target.eulerAngles = new Vector3(possAng[currindex], 0, 180);
        if ((currindex == possLocations.Count) || (currindex == 0))
        {
            Destroy(gameObject);
        }
    }
    public void moveToPos(int i)
    {
        Debug.Log("moving to pos: " + i);
        if (possLocations.Count <= 0)
            Start();

        target.position = possLocations[i];
        target.eulerAngles = new Vector3(possAng[i],0,180);
        currindex = i;
    }
    public void setActive()
    {
        GameObject infoPane = GameObject.FindWithTag("InfoPane");
        //Set all stuff here
    }
}
