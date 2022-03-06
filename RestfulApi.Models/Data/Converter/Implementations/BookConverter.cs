using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.Converter.Contract;
using RestfulApi.Models.Data.VO;
using System.Collections.Generic;
using System.Linq;

namespace RestfulApi.Models.Data.Converter.Implementations
{
    public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
    {
        public Book Parse(BookVO origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new Book
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LaunchDate = origin.LaunchDate,
                    NumberOfPages = origin.NumberOfPages,
                    Price = origin.Price,
                    Title = origin.Title
                };
            }
        }

        public BookVO Parse(Book origin)
        {
            if (origin == null)
            {
                return null;
            }
            else
            {
                return new BookVO
                {
                    Id = origin.Id,
                    Author = origin.Author,
                    LaunchDate = origin.LaunchDate,
                    NumberOfPages = origin.NumberOfPages,
                    Price = origin.Price,
                    Title = origin.Title
                };
            }
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null)
            {
                return new List<Book>();
            }
            else
            {
                return origin
                    .Select(item => Parse(item))
                    .ToList();
            }
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null)
            {
                return new List<BookVO>();
            }
            else
            {
                return origin
                  .Select(item => Parse(item))
                  .ToList();
            }
        }
    }
}
