using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace AlviSharp.Lib
{

	public class Agent : XY

	{

		[XmlAttribute(AttributeName = "active")]

		public bool Active;

		[XmlAttribute(AttributeName = "height")]

		public float Height = 100.0F;

		[XmlAttribute(AttributeName = "width")]

		public float Width = 140.0F;

		[XmlAttribute(AttributeName = "index")]

		public int Index = 1;

		[XmlAttribute(AttributeName = "running")]

		public bool Running = true;

		[XmlElement("port")]

		public List<Port> Ports = new List<Port>();

		public string PortNames
		{
			get
			{

				return Ports.Select(x => x.Name).OrderBy(x => x).Aggregate((s,a)=>a + ","+ s);

			}

		}

		public override string ToString()

		{

			return Name + " { " + PortNames + " }";

		}

	}
		
	
}
