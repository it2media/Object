﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Diagnostics;

namespace IT2media.Extensions.Object.NUnit
{
	[TestFixture()]
	public class Test
	{
		public class MyPropertyTestClass
		{
			public string MyProperty
			{
				get;
				set;
			} = "MyPropertyTest2";

			public int MyProperty2
			{
				get;
				set;
			} = 4711;
		} 

		[Test()]
		public async void TestCase()
		{
			try
			{
				List<string> list = new List<string>();

				list.Add("test1");
				list.Add("test2");

				list.Dump();

				MyPropertyTestClass testClass = new MyPropertyTestClass();

				testClass.Dump();

				var file = testClass.DumpToFile("testClass.json");

				string x = System.IO.File.ReadAllText(file.Path);

				Assert.IsTrue(!string.IsNullOrWhiteSpace(x));
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}
	}
}
