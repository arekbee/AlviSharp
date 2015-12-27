using System;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{

	public class Hierarchy
	{

		[XmlElement("node")]

		public HierarchyNode Node = new HierarchyNode();

	}
		
	
}
