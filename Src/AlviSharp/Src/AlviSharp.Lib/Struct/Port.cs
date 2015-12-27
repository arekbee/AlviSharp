using System;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{

	public class Port : XY

	{

		[XmlAttribute(AttributeName = "id")]

		public int Id = new Random().Next(Int32.MaxValue);

	}
		
	
}
