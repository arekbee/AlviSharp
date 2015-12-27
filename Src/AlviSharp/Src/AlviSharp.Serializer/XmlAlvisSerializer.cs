using System;
using AlviSharp.Lib;
using System.IO;

namespace AlviSharp.Serializer
{

	public class XmlAlvisSerializer :AlvisSerializer

	{

		public System.Xml.Serialization.XmlSerializer xmlSerializer

		= new System.Xml.Serialization.XmlSerializer(AlvisProjectType);

		public override string Serialize(AlvisProject ap)

		{

			using(StringWriter writer= new StringWriter())

			{

				xmlSerializer.Serialize(writer, ap);

				return writer.ToString();

			}

		}

		public override AlvisProject Deserialize(string serializable)

		{

			Object obj;

			using (StringReader reder = new StringReader(serializable))

			{

				obj = xmlSerializer.Deserialize(reder);

			}

			return obj as AlvisProject;

		}

	}
	
}
