namespace AsyncTesting.MSTest;

[TestClass]
public class Tests
{
    [TestMethod]
    public void Green_Sync_Vanilla()
    {
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public async Task Green_Async_Vanilla()
    {
        await Task.Yield();
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public async ValueTask Green_AsyncValue_Vanilla()
    {
        await Task.Yield();
        Assert.IsTrue(true);
    }
    
    [TestMethod]
    public void Red_Sync_Vanilla()
    {
        Assert.IsTrue(false);
    }
    
    [TestMethod]
    public async Task Red_Async_Vanilla()
    {
        await Task.Yield();
        Assert.IsTrue(false);
    }
    
    [TestMethod]
    public async ValueTask Red_AsyncValue_Vanilla()
    {
        await Task.Yield();
        Assert.IsTrue(false);
    }
    
    private class SyncDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
    
    private class AsyncDisposable : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Yield();
        }
    }

    [TestMethod]
    public void Green_Sync_Disposable()
    {
        using var _ = new SyncDisposable();
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async Task Green_Async_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.IsTrue(true);
    }

    [TestMethod]
    public async ValueTask Green_AsyncValue_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void Red_Sync_Disposable()
    {
        using var _ = new SyncDisposable();
        Assert.IsTrue(false);
    }

    [TestMethod]
    public async Task Red_Async_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.IsTrue(false);
    }

    [TestMethod]
    public async ValueTask Red_AsyncValue_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.IsTrue(false);
    }
}