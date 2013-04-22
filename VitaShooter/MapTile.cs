using System;
using System.Collections.Generic;


namespace VitaShooter
{
	public class MapTile
	{
		public String type {get; set;}
		public float x {get; set;}
		public float y {get; set;}
		
		public MapTile ()
		{
		}
		
		public MapTile(String t)
		{
			type = t;
		}
	}
}

