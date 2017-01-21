using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyText : MonoBehaviour {
    Text txt;
    string username = "";
    int numLikes = 0;
    int numComments = 0;
    string caption = "";
    string[] likes = { "", "", "" };

    // Use this for initialization
    public void Start()
    {
        txt.text = "";
    }

    public void setUsername(string user)
    {
        username = user;
    }

    public void setLikes(int l)
    {
        numLikes = l;
    }

    public void likeIt(string s)
    {
        numLikes++;
        likes[2] = likes[1];
        likes[1] = likes[0];
        likes[0] = s;
    }

    public void setComments(int c)
    {
        numComments = c;
    }

    public void setCaption(string s)
    {
        caption = s;
    }

    public void likePeople(string[] arr)
    {
        for (int i = 0; i < 3; i++)
        {
            likes[i] = arr[i];
        }
    }

    // Update is called once per frame
    public void Update()
    {
        txt.text = "" + username + "\n" + caption + "\n" + "Likes: " + numLikes + "\t Comments: " + numComments + "\n" + likes[0] + likes[1] + likes[2];
    }
}
