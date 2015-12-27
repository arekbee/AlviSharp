using System;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{
	public class HierarchyNode

	{

		[XmlAttribute(AttributeName = "agent")]

		public string Agent;

		[XmlAttribute(AttributeName = "name")]

		public string Name = "System";

	}
		
	
}
