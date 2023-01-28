using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OzelDers.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 5, nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UniverstyGraduatedFrom = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    HourlyPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    IsFacetoFace = table.Column<bool>(type: "INTEGER", nullable: false),
                    CertifiedTrainer = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 5, nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentAndTeachers",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentAndTeachers", x => new { x.StudentId, x.TeacherId });
                    table.ForeignKey(
                        name: "FK_StudentAndTeachers_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentAndTeachers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherAndBranches",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false),
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherAndBranches", x => new { x.TeacherId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_TeacherAndBranches_Branchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherAndBranches_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b5fe4a2-5e02-4641-a671-5001260b0419", null, null, "User", "USER" },
                    { "8689f964-57da-4fe3-a0ee-562625e5366c", null, null, "Teacher", "TEACHER" },
                    { "bc054144-d606-47f8-a543-5b0d4b3a94dc", null, null, "Student", "STUDENT" },
                    { "ee25e13f-5eb8-4d39-9310-c92c669a1f4f", null, null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5624bc97-0363-4c5a-b9c8-307308768960", 0, "3e31efb5-30fe-4c63-958b-624f1c2b9acd", "teacher@gmail.com", true, "Defne", "Kadın", "Teacher", "Ankara", false, null, "TEACHER@GMAIL.COM", "TEACHER", "AQAAAAIAAYagAAAAEIGOe+hZebcHkAEWXB/igBqrNViw7HSJrBIcZU0XsUD6bPGxImvGoBDutxwJ14gq/g==", "4444444455", false, "87db6b2f-164b-427a-aeeb-f64e5bdade65", false, "teacher" },
                    { "93107d37-7509-417c-92e4-e5aa42a7a524", 0, "9f607bf9-2bc9-4fdc-82e8-9283ead32013", "user@gmail.com", true, "Kemal", "Erkek", "User", "Ankara", false, null, "USER@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAELQvwnz2v32FTEC5HuTgAaLWRS7N0McbV+oh8iwu2sG4HT3v4Y5ZhaUohkxkzqoY/w==", "4444444444", false, "a936c1a3-1e16-4249-8a3d-a3333a6a6369", false, "user" },
                    { "a9015798-5482-495f-b550-03078d416859", 0, "63d0913a-9bc6-4dfd-acf2-f2f82a51be0a", "admin@gmail.com", true, "Deniz", "Kadın", "Admin", "İstanbul", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEL4jDVqKV0twaky9czKgobgGOzJ7+NV710qAmBZRRk6HAM59NZS9D55ztCKng4/x1g==", "5555555555", false, "675b19cb-cadf-46b7-903b-2e3741c9a4aa", false, "admin" },
                    { "c88ad64a-8c16-4e26-a062-1511d0af7ab8", 0, "7a379521-05e9-4d56-a700-5f4c05b3f840", "student@gmail.com", true, "Yusuf", "Erkek", "Student", "Ankara", false, null, "STUDENT@GMAIL.COM", "STUDENT", "AQAAAAIAAYagAAAAEBt8XfLqC2K3nvECeDRWqYEv9OKJlVbFf4taxA61cffl/RIQk7YMnr/7HNc+Wc8BlA==", "5554444444", false, "3d860de1-9ee9-417e-ad3d-64ef1f48eada", false, "student" }
                });

            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Matematik", "matematik" },
                    { 2, "Fizik", "fizik" },
                    { 3, "Kimya", "kimya" },
                    { 4, "Tarih", "tarih" },
                    { 5, "İngilizce", "ingilizce" },
                    { 6, "Edebiyat", "edebiyat" },
                    { 7, "Biyoloji", "biyoloji" },
                    { 8, "Almanca", "almanca" },
                    { 9, "C#", "c#" },
                    { 10, "Felsefe", "felsefe" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "DateAdded", "Description", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageUrl", "IsDeleted", "LastName", "Location", "Url", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", null, false, "Selim", "erkek", "1.png", false, "Durmuş", "Üsküdar/İstanbul", "selimdurmus", null, null },
                    { 2, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Hazırlık Öğrencisi", null, false, "Defne", "kız", "2.png", false, "Görmüş", "Çankaya/Ankara", "defnegormus", null, null },
                    { 3, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", null, false, "Hazal", "kız", "3.png", false, "Kara", "Çukurova/Adana", "hazalkara", null, null },
                    { 4, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", null, false, "Gözde", "kız", "4.png", false, "Çeken", "Bahçelievler/İstanbul", "gozdeceken", null, null },
                    { 5, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", null, false, "Hüseyin", "erkek", "5.png", false, "Kazanmış", "Küçükçekmece/İstanbul", "huseyinkazanmıs", null, null },
                    { 6, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", null, false, "Bilal", "erkek", "6.png", false, "Telli", "Bornova/İzmir", "bilaltelli", null, null },
                    { 7, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", null, false, "Yunus", "erkek", "7.png", false, "Deniz", "İzmit/Kocaeli", "denizyunus", null, null },
                    { 8, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Hazırlık Öğrencisi", null, false, "Cemre", "kadın", "8.png", false, "Kıran", "Üsküdar/İstanbul", "cemrekıran", null, null },
                    { 9, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", null, false, "Yusuf", "erkek", "9.png", false, "Güzel", "Yüreğir/Adana", "yusufguzel", null, null },
                    { 10, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", null, false, "Harun", "erkek", "10.png", false, "Bulut", "İskenderun/Hatay", "harunbulut", null, null },
                    { 11, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", null, false, "Yıldız", "kız", "11.png", false, "Mutlu", "Pendik/İstanbul", "yıldızmutlu", null, null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "CertifiedTrainer", "DateAdded", "Description", "Email", "EmailConfirmed", "FirstName", "Gender", "HourlyPrice", "ImageUrl", "IsDeleted", "IsFacetoFace", "LastName", "Location", "UniverstyGraduatedFrom", "Url", "UserId", "UserName" },
                values: new object[,]
                {
                    { 1, 27, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engish lessons are given.", null, false, "Jack", "erkek", 800, "20.png", false, false, "Brand", "Toronto/Canada", "Cambridge University", "jackbrand", null, null },
                    { 2, 27, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fizik dersi verilir.", null, false, "Sevgi", "kadın", 400, "21.png", false, true, "Özer", "Avcılar/İstanbul", "İstanbul Üniversitesi", "sevgiozer", null, null },
                    { 3, 35, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matematik dersi verilir.", null, false, "Deniz", "kadın", 600, "22.png", false, true, "Kuru", "Avcılar/İstanbul", "Fırat Üniversitesi", "denizkuru", null, null },
                    { 4, 30, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kimya dersi verilir.", null, false, "Fırat", "erkek", 650, "23.png", false, true, "Gören", "Çankaya/Ankara", "Marmara Üniversitesi", "fıratgören", null, null },
                    { 5, 40, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# dersi verilir.", null, false, "Kemal", "erkek", 400, "24.png", false, true, "Eren", "Bornova/İzmir", "Fırat Üniversitesi", "kemaleren", null, null },
                    { 6, 25, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edebiyat dersi verilir.", null, false, "Melis", "kadın", 600, "25.png", false, true, "Susan", "Sefaköy/İstanbul", "İstanbul Üniversitesi", "melissusan", null, null },
                    { 7, 34, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Almanca dersi verilir.", null, false, "Defne", "kadın", 500, "26.png", false, false, "Bilen", "Buca/İzmir", "Dokuz Eylül Üniversitesi", "defnebilen", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6b5fe4a2-5e02-4641-a671-5001260b0419", "5624bc97-0363-4c5a-b9c8-307308768960" },
                    { "6b5fe4a2-5e02-4641-a671-5001260b0419", "93107d37-7509-417c-92e4-e5aa42a7a524" },
                    { "ee25e13f-5eb8-4d39-9310-c92c669a1f4f", "a9015798-5482-495f-b550-03078d416859" },
                    { "6b5fe4a2-5e02-4641-a671-5001260b0419", "c88ad64a-8c16-4e26-a062-1511d0af7ab8" }
                });

            migrationBuilder.InsertData(
                table: "StudentAndTeachers",
                columns: new[] { "StudentId", "TeacherId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 4 },
                    { 6, 5 },
                    { 7, 6 },
                    { 8, 1 },
                    { 9, 3 }
                });

            migrationBuilder.InsertData(
                table: "TeacherAndBranches",
                columns: new[] { "BranchId", "TeacherId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 2, 2 },
                    { 8, 2 },
                    { 1, 3 },
                    { 3, 4 },
                    { 9, 5 },
                    { 6, 6 },
                    { 8, 7 },
                    { 10, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentAndTeachers_TeacherId",
                table: "StudentAndTeachers",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAndBranches_BranchId",
                table: "TeacherAndBranches",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_UserId",
                table: "Teachers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "StudentAndTeachers");

            migrationBuilder.DropTable(
                name: "TeacherAndBranches");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Branchs");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
