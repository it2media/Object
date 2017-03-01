using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

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
		public static string Dump(this object o)
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
