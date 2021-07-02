using DnetIndexedDb;
using Microsoft.JSInterop;

namespace TestOfflineBookReader.Client.IndexedDB
{
    public class ForecastDataIndexedDb : IndexedDbInterop
    {
        public ForecastDataIndexedDb(IJSRuntime jsRuntime, IndexedDbOptions<ForecastDataIndexedDb> options)
            : base(jsRuntime, options)
        {
        }
    }
}