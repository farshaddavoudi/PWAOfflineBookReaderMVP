using System;

namespace TestOfflineBookReader.Shared
{
    public class BookFile
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public byte[] Data { get; set; }
    }
}