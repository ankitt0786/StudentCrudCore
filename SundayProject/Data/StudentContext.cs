using Microsoft.EntityFrameworkCore;
using SundayProject.Models;
using System;

namespace SundayProject.Data
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
            { }

        public DbSet<Student> StudentsTable { get; set; }
    }
}
