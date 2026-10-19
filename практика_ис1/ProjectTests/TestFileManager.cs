using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using практика_ис1;

namespace ProjectTests
{
    public class TestFileManager: IDisposable
    {
        private readonly FileManager _fileManager = new FileManager();
        private readonly string _path;

        public TestFileManager()
        {
            _path = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        }

        [Fact]
        public void WriteLinesToFile_ThenReadLinesFromFile_ReturnsSameLines()
        {
            var lines = new List<string> { "Point 1 2 red", "Point 3 4 blue" };

            _fileManager.WriteLinesToFile(_path, lines);
            string[] read = _fileManager.ReadLinesFromFile(_path);

            Assert.Equal(lines, read);
        }

        [Fact]
        public void ReadLinesFromFile_NonExistentFile_ThrowsFileNotFoundException()
        {
            string missing = Path.Combine(Path.GetTempPath(), "no_" + Guid.NewGuid() + ".txt");
            Assert.Throws<FileNotFoundException>(() => _fileManager.ReadLinesFromFile(missing));
        }

        public void Dispose()
        {
            if (File.Exists(_path))
                File.Delete(_path);
        }
    }
}
