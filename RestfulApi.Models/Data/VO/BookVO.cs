using System;

namespace RestfulApi.Models.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime LaunchDate { get; set; }

        public int NumberOfPages { get; set; }

        public decimal Price { get; set; }
    }
}
