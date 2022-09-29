namespace AsyncTesting.NUnit;

public class Tests
{  
    [Test]
    public void Green_Sync_Vanilla()
    {
        Assert.True(true);
    }
    
    [Test]
    public async Task Green_Async_Vanilla()
    {
        await Task.Yield();
        Assert.True(true);
    }
    
    [Test]
    public async ValueTask Green_AsyncValue_Vanilla()
    {
        await Task.Yield();
        Assert.True(true);
    }
    
    [Test]
    public void Red_Sync_Vanilla()
    {
        Assert.True(false);
    }
    
    [Test]
    public async Task Red_Async_Vanilla()
    {
        await Task.Yield();
        Assert.True(false);
    }
    
    [Test]
    public async ValueTask Red_AsyncValue_Vanilla()
    {
        await Task.Yield();
        Assert.True(false);
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

    [Test]
    public void Green_Sync_Disposable()
    {
        using var _ = new SyncDisposable();
        Assert.True(true);
    }

    [Test]
    public async Task Green_Async_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(true);
    }

    [Test]
    public async ValueTask Green_AsyncValue_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(true);
    }

    [Test]
    public void Red_Sync_Disposable()
    {
        using var _ = new SyncDisposable();
        Assert.True(false);
    }

    [Test]
    public async Task Red_Async_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(false);
    }

    [Test]
    public async ValueTask Red_AsyncValue_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(false);
    }
}