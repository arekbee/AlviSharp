using System;
using System.IO;

namespace AlviSharp.Serializer.Cmd
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			//Convert to JSON
			string path = args [0];

			var text = File.ReadAllText (path);

			XmlAlvisSerializer xmlAlivis = new XmlAlvisSerializer ();
			var alvisproject = xmlAlivis.Deserialize (text);
			JsonAlvisSerializer jsonAlvis = new JsonAlvisSerializer ();
			var json = jsonAlvis.Serialize (alvisproject);
			Console.WriteLine (json);

		}
	}
}
