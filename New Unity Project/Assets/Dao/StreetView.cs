/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetView : MonoBehaviour {

    string inputUrl;
    string imgUrl;
	// Use this for initialization
	void Start () {
		
	}
	
    public IEnumerator setWorld(string url)
    {
<<<<<<< HEAD
        // https://maps.googleapis.com/maps/api/streetview?size=400x400&location=40.720032,-73.988354
       //      &fov = 90 & heading = 235 & pitch = 10
       //      & key = YOUR_API_KEY 
=======
         https://maps.googleapis.com/maps/api/streetview?size=400x400&location=40.720032,-73.988354
             &fov = 90 & heading = 235 & pitch = 10
             & key = YOUR_API_KEY
>>>>>>> e8b0f1f8bd3714ad673c52d3cb82a93c0dcf34d1
        WWW www = new WWW(url);
        yield return www;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;

    }
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< HEAD
}
*/
=======
}*/
>>>>>>> e8b0f1f8bd3714ad673c52d3cb82a93c0dcf34d1
