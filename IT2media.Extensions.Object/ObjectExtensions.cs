using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace IT2media.Extensions.Object
{
	public static class ObjectExtensions
	{
		public static T Dump<T>(this T obj)
		{
			try
			{
				string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
				Debug.WriteLine(json);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

			return obj;
		}
	}
}
