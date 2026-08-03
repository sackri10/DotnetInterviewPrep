namespace RuntimeAndMemory;

/// <summary>
/// Interview topic: IDisposable pattern, using statement, unmanaged resources.
/// </summary>
public class FileResource : IDisposable
{
    private readonly string _path;
    private bool _disposed;

    public FileResource(string path) => _path = path;

    public void Write(string content)
    {
        ObjectDisposedException.ThrowIf(_disposed, this);
        File.AppendAllText(_path, content);
    }

    public void Dispose()
    {
        if (_disposed) return;
        // Release unmanaged resources here
        _disposed = true;
        GC.SuppressFinalize(this); // no need for finalizer if disposed properly
    }
}

public static class DisposablePattern
{
    public static void UseWithUsingStatement(string path)
    {
        using var resource = new FileResource(path);
        resource.Write("Hello");
    } // Dispose called automatically
}
