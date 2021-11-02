using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicDiary.Migrations
{
    public partial class ElectronicDiaryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID_Group = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID_Group);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID_Subject = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID_Subject);
                });

            migrationBuilder.CreateTable(
                name: "Teacher_Groups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_Teacher = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Group = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher_Groups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    ID_Role = table.Column<int>(type: "INTEGER", nullable: false),
                    RolsID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Rols_RolsID",
                        column: x => x.RolsID,
                        principalTable: "Rols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupsTeacher_Groups",
                columns: table => new
                {
                    GroupsID_Group = table.Column<int>(type: "INTEGER", nullable: false),
                    Teacher_GroupsID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupsTeacher_Groups", x => new { x.GroupsID_Group, x.Teacher_GroupsID });
                    table.ForeignKey(
                        name: "FK_GroupsTeacher_Groups_Groups_GroupsID_Group",
                        column: x => x.GroupsID_Group,
                        principalTable: "Groups",
                        principalColumn: "ID_Group",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupsTeacher_Groups_Teacher_Groups_Teacher_GroupsID",
                        column: x => x.Teacher_GroupsID,
                        principalTable: "Teacher_Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    E_mail = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<decimal>(type: "TEXT", nullable: true),
                    ID_Group = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_User = table.Column<int>(type: "INTEGER", nullable: false),
                    Course = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupsID_Group = table.Column<int>(type: "INTEGER", nullable: true),
                    UsersID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Groups_GroupsID_Group",
                        column: x => x.GroupsID_Group,
                        principalTable: "Groups",
                        principalColumn: "ID_Group",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    E_mail = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<decimal>(type: "TEXT", nullable: true),
                    ID_User = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_UsersID",
                        column: x => x.UsersID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_Subject = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Teacher = table.Column<int>(type: "INTEGER", nullable: false),
                    Assessment_comments = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ID_Group = table.Column<int>(type: "INTEGER", nullable: false),
                    GroupsID_Group = table.Column<int>(type: "INTEGER", nullable: true),
                    SubjectsID_Subject = table.Column<int>(type: "INTEGER", nullable: true),
                    TeachersID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classes_Groups_GroupsID_Group",
                        column: x => x.GroupsID_Group,
                        principalTable: "Groups",
                        principalColumn: "ID_Group",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Subjects_SubjectsID_Subject",
                        column: x => x.SubjectsID_Subject,
                        principalTable: "Subjects",
                        principalColumn: "ID_Subject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_TeachersID",
                        column: x => x.TeachersID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ID_Subject = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Student = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Group = table.Column<int>(type: "INTEGER", nullable: false),
                    ID_Teacher = table.Column<int>(type: "INTEGER", nullable: false),
                    Grade = table.Column<int>(type: "INTEGER", nullable: true),
                    Assessment_comment = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GroupsID_Group = table.Column<int>(type: "INTEGER", nullable: true),
                    StudentID = table.Column<int>(type: "INTEGER", nullable: true),
                    SubjectsID_Subject = table.Column<int>(type: "INTEGER", nullable: true),
                    TeachersID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grades_Groups_GroupsID_Group",
                        column: x => x.GroupsID_Group,
                        principalTable: "Groups",
                        principalColumn: "ID_Group",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Student",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Subjects_SubjectsID_Subject",
                        column: x => x.SubjectsID_Subject,
                        principalTable: "Subjects",
                        principalColumn: "ID_Subject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Teachers_TeachersID",
                        column: x => x.TeachersID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teacher_GroupsTeachers",
                columns: table => new
                {
                    Teacher_GroupsID = table.Column<int>(type: "INTEGER", nullable: false),
                    TeachersID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher_GroupsTeachers", x => new { x.Teacher_GroupsID, x.TeachersID });
                    table.ForeignKey(
                        name: "FK_Teacher_GroupsTeachers_Teacher_Groups_Teacher_GroupsID",
                        column: x => x.Teacher_GroupsID,
                        principalTable: "Teacher_Groups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teacher_GroupsTeachers_Teachers_TeachersID",
                        column: x => x.TeachersID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_GroupsID_Group",
                table: "Classes",
                column: "GroupsID_Group");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_SubjectsID_Subject",
                table: "Classes",
                column: "SubjectsID_Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeachersID",
                table: "Classes",
                column: "TeachersID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_GroupsID_Group",
                table: "Grades",
                column: "GroupsID_Group");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentID",
                table: "Grades",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SubjectsID_Subject",
                table: "Grades",
                column: "SubjectsID_Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeachersID",
                table: "Grades",
                column: "TeachersID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsTeacher_Groups_Teacher_GroupsID",
                table: "GroupsTeacher_Groups",
                column: "Teacher_GroupsID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_GroupsID_Group",
                table: "Student",
                column: "GroupsID_Group");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UsersID",
                table: "Student",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_GroupsTeachers_TeachersID",
                table: "Teacher_GroupsTeachers",
                column: "TeachersID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UsersID",
                table: "Teachers",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolsID",
                table: "Users",
                column: "RolsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "GroupsTeacher_Groups");

            migrationBuilder.DropTable(
                name: "Teacher_GroupsTeachers");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teacher_Groups");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rols");
        }
    }
}
