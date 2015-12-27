using System;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{

	public class Connection

	{

		[XmlAttribute(AttributeName = "direction")]

		public string Direction = "target";

		[XmlAttribute(AttributeName = "source")]

		public int Source;

		[XmlAttribute(AttributeName = "target")]

		public int Target;

		[XmlAttribute(AttributeName = "style")]

		public string Style = "straight";

		public override string ToString()

		{

			return Source + " -->" + Target;

		}

	}

	
}
