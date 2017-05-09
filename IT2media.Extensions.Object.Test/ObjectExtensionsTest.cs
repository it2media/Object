using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace IT2media.Extensions.Object.Test
{
    public class ObjectExtensionsTest
    {
        [Fact]
        public void DumpToFileTest()
        {
            List<string> list = new List<string>();

            list.Add("item1");
            list.Add("item2");

            list.Dump();

            SampleClass instance = new SampleClass();

            instance.Dump();

            var file = instance.DumpToFileAsync("sampleClass.json").Result;

            string fileContent = System.IO.File.ReadAllText(file.Path);

            Console.WriteLine(file.Path);

            Assert.True(!string.IsNullOrWhiteSpace(fileContent));
        }
    }
}
