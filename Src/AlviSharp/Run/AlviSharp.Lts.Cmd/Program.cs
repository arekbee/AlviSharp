using System;
using System.IO;

namespace AlviSharp.Lts.Cmd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string filePath = "example.alviscode";

			var content = File.ReadAllText(filePath);


			LtsGenerator lts = new LtsGenerator ();
			lts.Generate (content);

		}
	}
}
