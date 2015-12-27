using System;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{

	public abstract class XY

	{

		[XmlAttribute(AttributeName = "x")]

		public float X;

		[XmlAttribute(AttributeName = "y")]

		public float Y;

		[XmlAttribute(AttributeName = "color")]

		public string Color = ConsoleColor.White.ToString();

		[XmlAttribute(AttributeName = "name")]

		public string Name = "";

	}

	
}
