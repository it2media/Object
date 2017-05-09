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
        public void DumpToFileAsyncTest()
        {
            var list = new List<string> {"item1", "item2"};

            list.Dump();

            var instance = new SampleClass();

            instance.Dump();

            var file = instance.DumpToFileAsync("sampleClass.json").Result;

            var fileContent = System.IO.File.ReadAllText(file.Path);

            Console.WriteLine($"Dumped file async: {file.Path}");

            Assert.True(!string.IsNullOrWhiteSpace(fileContent));
        }

        [Fact]
        public void DumpToFileTest()
        {
            var instance = new SampleClass();

            var file = instance.DumpToFile();

            var fileContent = System.IO.File.ReadAllText(file.Path);

            Console.WriteLine($"Dumped file: {file.Path}");

            Assert.True(!string.IsNullOrWhiteSpace(fileContent));
        }
    }
}
