using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ElectronicDiary.Entities;
using Microsoft.EntityFrameworkCore;

namespace ElectronicDiary.Entities
{
    public class DB_Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ED_DataBase.db");
        }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Grades> Grades { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Rols> Rols { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Teacher_Groups> Teacher_Groups { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
