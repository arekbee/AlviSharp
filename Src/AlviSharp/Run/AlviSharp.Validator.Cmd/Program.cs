using System;
using AlviSharp.Serializer;
using AlvisSharp.Validator;
using System.IO;
using System.Collections.Generic;

namespace AlviSharp.Validator.Cmd
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string path = args [0];
			if (!string.IsNullOrWhiteSpace (path) && File.Exists (path)) {
				var text = File.OpenText(path).ReadToEnd();

				XmlAlvisSerializer serializer= new XmlAlvisSerializer();

				var projectObj = serializer.Deserialize(text);


				var validators = new List<IAlvisValidator> {

					new AtLeastOneActiveAgentAlvisValidator(),

					new AgentAlvisValidator(),

					new ConnectionAlvisValidator(),

					new CodeAlvisValidator() };

				bool notvalid = false;
				foreach (var validator in validators)
				{
					string errorMessage = validator.Validate(projectObj);
					if (!String.IsNullOrWhiteSpace(errorMessage))
					{
						Console.WriteLine(errorMessage);
						notvalid = true;
					}
				}



				if (notvalid) {
					Console.WriteLine ("VALIDATION ERRORS");
				} else {
					Console.WriteLine ("No validation errors");
				}
			
			} else {
				Console.WriteLine ("Wrong path to file");
				Console.ReadKey ();
			}
		}
	}
}
