using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PCLStorage;

namespace IT2media.Extensions.Object
{
	public static class ObjectExtensions
	{
		/// <summary>
		/// Dump the specified obj to Debug
		/// </summary>
		/// <returns>The object or a copy of the reference type.</returns>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
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

		/// <summary>
		/// Dumps to a UTF8 ecnoded file.
		/// </summary>
		/// <returns>The object or a copy of the reference type.</returns>
		/// <param name="obj">Object.</param>
		/// <param name="path">Path.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static IFile DumpToFile<T>(this T obj, string path)
		{
			IFile file;

			try
			{
				string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

				file = FileSystem.Current.LocalStorage.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting).Result;

				file.WriteAllTextAsync(json).Wait();

				return file;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
				throw;
			}
		}
	}
}
