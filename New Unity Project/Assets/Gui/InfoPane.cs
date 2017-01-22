using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public static class NullZip
{
	public static string nz(this string str, string value)
	{
		if (str == null)
			return value;
		return str;
	}


}

public class InfoPane : MonoBehaviour
{
	private ImageModel _imageModel;

	public ImageModel ImageModel
	{
		get { return _imageModel; }
		set
		{
			if (_imageModel == null || _imageModel != value)
			{
				_imageModel = value;
				GetComponent<Text>().text = getText();
			}
		}
	}


	private string getText()
	{
			var s = string.Format("{0} ({1})\n\n", ImageModel.Username.nz("No username"), ImageModel.FullName.nz("No Name"));
			s += string.Format("{0}\n", ImageModel.Caption.nz("no caption"));
			s += string.Format("<3 {0}, # {1} Comments\n\n", ImageModel.Likes, ImageModel.Comments);
			if (ImageModel.Likers != null && ImageModel.Likers.Count > 0)
				s += "Liked By:\n" + string.Join(", ", ImageModel.Likers.ToArray());
			else
				s += "No Likes Yet!";
			
			return s;
		
	}

	// Use this for initialization
	void Start()
	{
		ImageModel = new ImageModel()
		{
			Likes = 0,
			Comments = 1,
		};
		
	}

	// Update is called once per frame
	void Update()
	{

	}
}