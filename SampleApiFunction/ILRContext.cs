using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Sample.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ilrapifunction
{
    public class SampleDBContext : DbContext
    {

        public SampleDBContext(DbContextOptions<SampleDBContext> options)
    : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
