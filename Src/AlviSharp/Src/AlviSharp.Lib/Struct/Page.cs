using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{

	public class Page

	{

		[XmlElement("agent")]

		public List<Agent> Agents;

		[XmlElement("connection")]

		public List<Connection> Connections;

		[XmlAttribute("name")]

		public string Name ="";

	}
	
}
