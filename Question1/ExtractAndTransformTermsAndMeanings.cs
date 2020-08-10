using System.IO;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Question1
{
    public class ExtractAndTransformTermsAndMeanings    
    {
        private readonly ITestOutputHelper _output;

        public ExtractAndTransformTermsAndMeanings(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void ExtractData()
        {
            var outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = @".\Data.txt";

            var fullPath = Path.Combine(outputDir, filePath);
            if (!doesFileExist(fullPath)) throw new FileNotFoundException($"File not found: {fullPath}");

            using (StreamReader reader = new StreamReader(fullPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var strings = line.Split('–');
                    //  I have assumed that each word separate from another part by - and can be possible only one - on the whole line
                    var word = strings[0];
                    // Each meaning separate from another by ',' and no ',' inside the meaning itself
                    var meanings = strings[1].Split(',');

                    _output.WriteLine(word.Trim());
                    foreach (var m in meanings)
                    {
                        _output.WriteLine(m.Trim());
                    }
                }
            }
        }

        // Was part of the question: ""
        private bool doesFileExist(string path)
        {
            return File.Exists(path);
        }
    }
}
