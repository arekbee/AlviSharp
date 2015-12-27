using NUnit.Framework;
using System;
using AlviSharp.Serializer;
using System.IO;
using AlvisSharp.Validator;
using AlviSharp.Lib;

namespace AlviSharp.Validator.ITests
{




	public class ExampleDataFeedTests :DataFeedTests
	{
		public override string FileLocation {
			get {
				return @"Examples/example.alvis";
			}
		}


	}
}

