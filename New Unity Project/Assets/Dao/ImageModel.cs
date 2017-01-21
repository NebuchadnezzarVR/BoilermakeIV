using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class ImageModel
	{
		public DateTime TimeTaken { get; set; }
		public string Username { get; set; }
		public string FullName { get; set; }
		public List<string> TaggedUsers { get; set; }
		public List<string> Likers { get; set; }
		public string ImageUrl { get; set; }
		public string Caption { get; set; }
		public int Comments { get; set; }
		public int Likes { get; set; }
	}
