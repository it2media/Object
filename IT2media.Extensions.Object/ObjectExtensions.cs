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
        /// Dumps the specified object to Debug
        /// </summary>
        /// <returns>The object or a copy of the reference type.</returns>
        /// <param name="obj">Object.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T Dump<T>(this T obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                Debug.WriteLine(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return obj;
        }

        /// <summary>
        /// Dumps to a UTF8 encoded file.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static IFile DumpToFile<T>(this T obj, string filename = null, string directory = null)
        {
            return obj.DumpToFileAsync(filename, directory).Result;
        }

        /// <summary>
        /// Dumps to a UTF8 encoded file.
        /// </summary>
        /// <returns>The object or a copy of the reference type.</returns>
        /// <param name="obj"></param>
        /// <param name="filename"></param>
        /// <param name="directory"></param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static async Task<IFile> DumpToFileAsync<T>(this T obj, string filename = null, string directory = null)
        {
            try
            {
                if (filename == null)
                {
                    filename = DateTime.Now.Ticks + ".json";
                }

                var json = JsonConvert.SerializeObject(obj, Formatting.Indented);

                var storage = FileSystem.Current.LocalStorage;

                IFolder folder;

                if (directory != null)
                {
                    folder = await storage.CreateFolderAsync(directory, CreationCollisionOption.OpenIfExists);
                }
                else
                {
                    folder = storage;
                }

                var file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

                await file.WriteAllTextAsync(json);

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
