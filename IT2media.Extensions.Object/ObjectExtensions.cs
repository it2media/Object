using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace IT2media.Extensions.Object
{
	public class Test : IEnumerable
	{
		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}

	public static class ObjectExtensions
	{
		public static T Dump<T>(this T o)
		{
			try
			{
				string json = JsonConvert.SerializeObject(o, Formatting.Indented);
				Debug.WriteLine(json);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			return o;
		}

		public static string Dump2(this object o)
		{
			string s = o.ToString();

			Type t = o.GetType();

			var propInfos = t.GetRuntimeProperties();

			try
			{
				foreach (var propInfo in propInfos)
				{
					var m = propInfo.DeclaringType.GetTypeInfo().DeclaredMethods;

					var x = (from y in m where y.Name == "GetEnumerator" select y);
					if (x.Any())
					{
						continue;
					}

					Debug.WriteLine(propInfo.Name + ":" + propInfo.GetValue(o));
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}

			if (o as IEnumerable != null)
			{
				foreach (var sub in o as IEnumerable)
				{
					Debug.WriteLine(sub);
				}
			}
			else
			{
				Debug.WriteLine(s);
			}

			return s;
		}
	}
}
