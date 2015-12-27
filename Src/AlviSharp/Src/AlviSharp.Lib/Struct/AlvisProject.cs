using System;
using System.Xml.Serialization;

namespace AlviSharp.Lib
{

	[XmlRoot(ElementName = "alvisproject")]
	public class AlvisProject
	{
		[XmlElement("hierarchy")]
		public Hierarchy Hierarchy = new Hierarchy();
	
		[XmlElement("code")]
		public string Code = "";

		[XmlElement("page")]
		public Page Page = new Page();

	}
}

