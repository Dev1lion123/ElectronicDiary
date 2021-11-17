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
    public class DbStudents : DbContext
    {
        public DbStudents()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ED_DataBase.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id=1, Login="Student-121", Password="qwerty123", RoleId=2 },
                    new User { Id=2, Login="Teacher1", Password="1234", RoleId=1 },
                    new User { Id=3, Login="Teacher2", Password="1234", RoleId=1 },
                    new User { Id=4, Login="Teacher3", Password="1234", RoleId=1 },
                    new User { Id=5, Login="Teacher4", Password="1234", RoleId=1 },
                    new User { Id=6, Login="Teacher5", Password="1234", RoleId=1 },
                    new User { Id=7, Login="Teacher6", Password="1234", RoleId=1 },
                });
            modelBuilder.Entity<Group>().HasData(
                new Group[]
                {
                    new Group { Id=1, Title="1ИСИП-121" }
                });
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id=1, Title="Преподаватель" },
                    new Role { Id=2, Title="Студент" }
                });
            modelBuilder.Entity<Student>().HasData(
                new Student[]
                {
                    new Student { Id=1, Lastname="Петров", Firstname="Петр", Patronymic="Петрович", E_mail="petr@mail.ru", Phone="", GroupId=1, UserId=1, Course=1}
                });
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher[]
                {
                    new Teacher { Id=1, Lastname="Азовцева", Firstname="Вера", Patronymic="Владимировна", E_mail="", Phone="", UserId=2 },
                    new Teacher { Id=2, Lastname="Аксенова", Firstname="Татьяна", Patronymic="Геннадьевна", E_mail="", Phone="", UserId=3 },
                    new Teacher { Id=3, Lastname="Акопов", Firstname="Владимир", Patronymic="Фелисович", E_mail="", Phone="", UserId=4 },
                    new Teacher { Id=4, Lastname="Василенков", Firstname="Павел", Patronymic="Сергеевич", E_mail="", Phone="", UserId=5 },
                    new Teacher { Id=5, Lastname="Володин", Firstname="Сергей", Patronymic="Михайлович", E_mail="", Phone="", UserId=6 },
                    new Teacher { Id=6, Lastname="Записной", Firstname="Дмитрий", Patronymic="Викторович", E_mail="", Phone="", UserId=7 },
                });
            modelBuilder.Entity<Subject>().HasData(
                new Subject[]
                {
                    new Subject { Id=1, Title="Русский язык" },
                    new Subject { Id=2, Title="Математика" },
                    new Subject { Id=3, Title="ТРПО" },
                    new Subject { Id=4, Title="Физкультура" },
                    new Subject { Id=5, Title="Введение в ОС"},
                    new Subject { Id=6, Title="Английский язык"},
                });
            modelBuilder.Entity<TeacherGroup>().HasData(
                new TeacherGroup[]
                {
                    new TeacherGroup { Id=1, TeacherId=1, GroupId=1 },
                    new TeacherGroup { Id=2, TeacherId=2, GroupId=1 },
                    new TeacherGroup { Id=3, TeacherId=3, GroupId=1 },
                    new TeacherGroup { Id=4, TeacherId=4, GroupId=1 },
                    new TeacherGroup { Id=5, TeacherId=5, GroupId=1 },
                    new TeacherGroup { Id=6, TeacherId=6, GroupId=1 },               
                });
            modelBuilder.Entity<ClassEntity>().HasData(
                new ClassEntity[]
                {
                    new ClassEntity { Id=1, SubjectId=1, TeacherId=1, GroupId=1, AssessmentComment="", Date=DateTime.Parse("15.11.2021")},
                    new ClassEntity { Id=2, SubjectId=2, TeacherId=3, GroupId=1, AssessmentComment="", Date=DateTime.Parse("15.11.2021")},
                    new ClassEntity { Id=3, SubjectId=3, TeacherId=2, GroupId=1, AssessmentComment="", Date=DateTime.Parse("16.11.2021")},
                    new ClassEntity { Id=4, SubjectId=4, TeacherId=4, GroupId=1, AssessmentComment="", Date=DateTime.Parse("16.11.2021")},
                    new ClassEntity { Id=5, SubjectId=5, TeacherId=5, GroupId=1, AssessmentComment="", Date=DateTime.Parse("17.11.2021")},
                    new ClassEntity { Id=6, SubjectId=1, TeacherId=1, GroupId=1, AssessmentComment="", Date=DateTime.Parse("17.11.2021")},
                    new ClassEntity { Id=7, SubjectId=6, TeacherId=6, GroupId=1, AssessmentComment="", Date=DateTime.Parse("18.11.2021")},
                    new ClassEntity { Id=8, SubjectId=3, TeacherId=2, GroupId=1, AssessmentComment="", Date=DateTime.Parse("19.11.2021")},
                    new ClassEntity { Id=9, SubjectId=4, TeacherId=4, GroupId=1, AssessmentComment="", Date=DateTime.Parse("19.11.2021")}
                });
        }
               
        public DbSet<ClassEntity> Classes { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherGroup> TeacherGroups { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }


    }
}
