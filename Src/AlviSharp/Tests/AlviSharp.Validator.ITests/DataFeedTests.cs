using NUnit.Framework;
using System;
using AlviSharp.Serializer;
using System.IO;
using AlvisSharp.Validator;
using AlviSharp.Lib;

namespace AlviSharp.Validator.ITests
{

	[TestFixture ()]
	public abstract class DataFeedTests
	{
		public AllIAlvisValidator validator = new AllIAlvisValidator ();

		public abstract string  FileLocation {get;}

		public AlvisProject GetAlvisProject()
		{
			var text = File.OpenText(FileLocation).ReadToEnd();

			XmlAlvisSerializer serializer= new XmlAlvisSerializer();

			return serializer.Deserialize(text);
		}

		[Test ()]
		public void It_should_be_valid_for_all_validators ()
		{
			Assert.IsNullOrEmpty(validator.Validate (GetAlvisProject()));
		}
	}
	
}
