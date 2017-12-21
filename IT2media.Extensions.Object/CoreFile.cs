using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using PCLStorage;
using FileAccess = PCLStorage.FileAccess;

namespace IT2media.Extensions.Object
{
    public static partial class ObjectExtensions
    {
        public class CoreFile : IFile
        {
            public CoreFile(string fileName)
            {
                var fi = new FileInfo(fileName);

                Path = fi.FullName;
                Name = fi.Name;
            }

            public Task<Stream> OpenAsync(FileAccess fileAccess, CancellationToken cancellationToken = new CancellationToken())
            {
                if (fileAccess == FileAccess.Read)
                {
                    using (Stream fs = File.OpenRead(Path))
                    {
                        return Task.FromResult(fs);
                    }
                }

                using (Stream fs = File.OpenWrite(Path))
                {
                    return Task.FromResult(fs);
                }
            }

            public Task DeleteAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                return Task.Run(() => File.Delete(Path), cancellationToken);
            }

            public Task RenameAsync(string newName, NameCollisionOption collisionOption = NameCollisionOption.FailIfExists,
                CancellationToken cancellationToken = new CancellationToken())
            {
                return Task.Run(() =>
                {
                    var currentPath = new FileInfo(Path);

                    var newPath = System.IO.Path.Combine(currentPath.DirectoryName, newName);

                    File.Move(Path, newPath);
                }, cancellationToken);
            }

            public Task MoveAsync(string newPath, NameCollisionOption collisionOption = NameCollisionOption.ReplaceExisting,
                CancellationToken cancellationToken = new CancellationToken())
            {
                return Task.Run(() => File.Move(Path, newPath), cancellationToken);
            }

            public string Name { get; }
            public string Path { get; }
        }
    }
}
