using System;

namespace TestOfflineBookReader.Shared
{
    public class Book
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }

        public string Name { get; set; }

        public int Size { get; set; }
    }
}