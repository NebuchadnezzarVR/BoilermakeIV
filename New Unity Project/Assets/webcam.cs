using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webcam : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WebCamTexture webcamTexture = new WebCamTexture();
        Renderer renderer = GetComponent<Renderer>();
        webcamTexture.Play();
        renderer.material.mainTexture = webcamTexture;
       // gameObject.GetComponent<SpriteRenderer>().material.mainTexture = webcamTexture;
    }
}
	
	/*// Update is called once per frame
	void Update () {
		
	} */
