﻿using Microsoft.EntityFrameworkCore;
using RestfulApi.Models.Core.Entities;
using RestfulApi.Models.Data.VO;

namespace RestfulApi.Repository.Persistence
{
    public class RestfulApiDbContext : DbContext
    {
        public RestfulApiDbContext(DbContextOptions<RestfulApiDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
