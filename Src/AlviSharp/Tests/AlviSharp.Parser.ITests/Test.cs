using NUnit.Framework;
using System;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Collections;
using System.Linq;

namespace AlviSharp.Parser.ITests
{
	[TestFixture("pl-PL")]
	//[TestFixture("tr-TR")]
	public class FileTests
	{
		private static readonly string TestPath =TestUtilities.SearchUpDirectoryName(System.IO.Path.Combine("TestData","AlvisCode"));
		private const string FileExtension = ".alviscode";
		public FileTests(string culture)
		{
			CultureInfo ci = new CultureInfo(culture);
			Thread.CurrentThread.CurrentUICulture = ci;
			Thread.CurrentThread.CurrentCulture = ci;
		}


		[Test]
		public void It_should_have_atleast_one_file()
		{
			Assert.IsTrue(Directory.GetFiles(TestPath).Any(x => x.EndsWith(FileExtension)));
		}

		[TestCaseSource("TestCaseSource_Filename")]
		public void It_should_Parse_file(string filePath)
		{
			Console.WriteLine(filePath);
			var content = File.ReadAllText(filePath);
			Assert.IsNotEmpty(content);
			StringAssert.Contains("agent", content.ToLower());
			var parsed = AlviSharp.Parser.Program.ParseAlvis(content);
			Assert.IsNotNull(parsed);
		}
		public static System.Collections.IEnumerable TestCaseSource_Filename
		{
			get
			{
				return Directory.GetFiles(TestPath).Where(x => x.EndsWith(FileExtension)).Select(x => new TestCaseData(x));
			}
		}
	}






	public class TestUtilities
	{
		public static string SearchUpDirectoryName(string path)
		{
			string pathToSearch = path;
			for (int i = 0; i < 10; i++)
			{
				if (Directory.Exists(pathToSearch) && Directory.GetFiles(pathToSearch).Any())
				{
					return Path.GetFullPath(pathToSearch);
				}
				else
				{
					pathToSearch = Path.Combine("..", pathToSearch);
				}
			}
			return null;
		}
		public static bool ContainsIC(string str, string pattern)
		{
			return str != null && str.IndexOf(pattern, StringComparison.InvariantCultureIgnoreCase) >= 0;
		}
	}
}

