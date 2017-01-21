using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MyText txt = GameObject.FindWithTag("SpecialCanvas").GetComponentInChildren(typeof(MyText)) as MyText;
        txt.setUsername("mrshawnabu");
        txt.setCaption("Fucking hate this");
        txt.setLikes(5);
        string[] arr = { "Jordan", "MyDick", "YourDick" };
        txt.likePeople(arr);
        txt.setComments(3);
        txt.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
