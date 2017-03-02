using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static IT2media.Extensions.Object.NUnit.Test;

namespace IT2media.Extensions.Object.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleClass instance = new SampleClass();

				instance.Dump();

				var file = instance.DumpToFileAsync("sampleClass.json", "MyDirectory/SubDir").Result;

				string fileContent = System.IO.File.ReadAllText(file.Path);
        }
    }
}
