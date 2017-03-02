using NUnit.Framework;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IT2media.Extensions.Object.NUnit
{
	[TestFixture()]
	public class Test
	{
		public class SampleClass
		{
			public string StringProperty
			{
				get;
				set;
			}

			public int IntProperty
			{
				get;
				set;
			}
		} 

		[Test()]
		public async Task TestCase()
		{
			try
			{
				List<string> list = new List<string>();

				list.Add("item1");
				list.Add("item2");

				list.Dump();

				SampleClass instance = new SampleClass();

				instance.Dump();

				var file = await instance.DumpToFileAsync("sampleClass.json");

				string fileContent = System.IO.File.ReadAllText(file.Path);

				Assert.IsTrue(!string.IsNullOrWhiteSpace(fileContent));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}
	}
}
