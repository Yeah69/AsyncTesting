namespace AsyncTesting;

public class Tests
{
    [Fact]
    public void Green_Sync_Vanilla()
    {
        Assert.True(true);
    }
    
    [Fact]
    public async Task Green_Async_Vanilla()
    {
        await Task.Yield();
        Assert.True(true);
    }
    
    [Fact]
    public async ValueTask Green_AsyncValue_Vanilla()
    {
        await Task.Yield();
        Assert.True(true);
    }
    
    [Fact]
    public void Red_Sync_Vanilla()
    {
        Assert.True(false);
    }
    
    [Fact]
    public async Task Red_Async_Vanilla()
    {
        await Task.Yield();
        Assert.True(false);
    }
    
    [Fact]
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

    [Fact]
    public void Green_Sync_Disposable()
    {
        using var _ = new SyncDisposable();
        Assert.True(true);
    }

    [Fact]
    public async Task Green_Async_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(true);
    }

    [Fact]
    public async ValueTask Green_AsyncValue_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(true);
    }

    [Fact]
    public void Red_Sync_Disposable()
    {
        using var _ = new SyncDisposable();
        Assert.True(false);
    }

    [Fact]
    public async Task Red_Async_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(false);
    }

    [Fact]
    public async ValueTask Red_AsyncValue_Disposable()
    {
        await using var _ = new AsyncDisposable();
        await Task.Yield();
        Assert.True(false);
    }
}