using DnetIndexedDb;
using Microsoft.JSInterop;

namespace TestOfflineBookReader.Client.IndexedDB
{
    public class BookDataIndexedDb : IndexedDbInterop
    {
        public BookDataIndexedDb(IJSRuntime jsRuntime, IndexedDbOptions<BookDataIndexedDb> options)
            : base(jsRuntime, options)
        {
        }
    }
}