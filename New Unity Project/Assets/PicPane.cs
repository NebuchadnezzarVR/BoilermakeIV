using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PicPane : MonoBehaviour {

// Add this script to a GameObject. The Start() function fetches an
// image from the documentation site.  It is then applied as the
// texture on the GameObject.

    public string url = "https://docs.unity3d.com/uploads/Main/ShadowIntro.png"; //Will be depreciated as soon as ImageMode is implemented
    public ImageModel myModel;

    //Currently incative. Will implement when movement becomes a possibility


    void Start() {
        
    }

    IEnumerator loadImage()
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;


    }
    // Update is called once per frame
    void Update () {
		
	}
    void setImageModel(ImageModel i)
    {
        myModel = i;
        loadImage();
          
    }
}
