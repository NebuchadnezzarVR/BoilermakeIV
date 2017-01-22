using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
using System;
 
 
 public class PicPaneOrg : MonoBehaviour
{
 
 // Add this script to a GameObject. The Start() function fetches an
 // image from the documentation site.  It is then applied as the
 // texture on the GameObject.
 
     public string url = "http://scontent-ort2-1.cdninstagram.com/t51.2885-15/e35/13414336_641685176008067_1785445179_n.jpg?ig_cache_key=MTI2ODMyNTgwNDQxMzM1Mjc2OA%3D%3D.2&se=7";
     
     IEnumerator Start()
    {
        
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(url);
        yield return www;
        www.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;
        Debug.Log("here");

    }
 
 	
 	// Update is called once per frame
 	void Update()
    {
        
          }
 }