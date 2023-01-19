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
                    Description = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
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
                    Email = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", maxLength: 5, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 250, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
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
                    { "065c66cd-1c14-4c6a-87aa-d03e768027ac", null, null, "Student", "STUDENT" },
                    { "3383e82d-1809-4990-a29a-2caef97e7d56", null, null, "Admin", "ADMIN" },
                    { "709ba7a3-877f-42ac-b926-be0fe9338dfd", null, null, "Teacher", "TEACHER" },
                    { "77b145e6-90f8-4254-b420-7598b079d5d0", null, null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "Location", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33a2a1c3-ba58-4881-92c1-9185c4e901e7", 0, "a7eb45c8-f2f0-4f72-9d64-92ae81945fcd", "teacher@gmail.com", true, "Defne", "Kadın", "Teacher", "Ankara", false, null, "TEACHER@GMAIL.COM", "TEACHER", "AQAAAAIAAYagAAAAEO+5mNCmnozjgt/GxgVPgLL8ef6tOHjXkZndFLgMCAsoUD4fvjRk/pviZznifaRg6w==", "4444444455", false, "33068a8f-2861-478d-b028-a5c09c7e8da1", false, "teacher" },
                    { "5b75301c-6dd3-47b8-92dd-8290e877ac8a", 0, "054095c7-4dc4-4c04-8da7-92850a93542e", "student@gmail.com", true, "Yusuf", "Erkek", "Student", "Ankara", false, null, "STUDENT@GMAIL.COM", "STUDENT", "AQAAAAIAAYagAAAAEIxEY7wFOQVYQeAAvA97pVuhbnDeRK4mVtYsGZn143RlGtOrngTfIcKsPRy3QUeKsg==", "5554444444", false, "cfdfb290-5695-4351-94bf-e21cc5f55c5e", false, "student" },
                    { "eb46bb5a-e294-4b38-8dca-a203c7c2686d", 0, "01bc1cbe-9181-4869-8ea4-4f09f47af947", "admin@gmail.com", true, "Deniz", "Kadın", "Admin", "İstanbul", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAIAAYagAAAAEFZXM/ti16pTw7IPMrjfrR9GsLwBbJtRxByHnSRzBQMeOH/pYT/LVFzuueII3HcmGg==", "5555555555", false, "c1b108e6-a717-4544-9acb-a3c1fd9e6d81", false, "admin" },
                    { "f56c5be6-af7c-4638-a9f0-8bc8daf276be", 0, "b675579d-495d-4d22-87ec-f0ae70bba3c5", "user@gmail.com", true, "Kemal", "Erkek", "User", "Ankara", false, null, "USER@GMAIL.COM", "USER", "AQAAAAIAAYagAAAAEHvQSw6phnVfVFPrcd7y/Y1EPh2s8viTxe8qxa3yKRYpomkg+ENXc34o1d/ZoyHoag==", "4444444444", false, "314bfede-04b3-4352-ac81-2856c4085f7c", false, "user" }
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
                columns: new[] { "Id", "Age", "DateAdded", "Description", "Email", "FirstName", "Gender", "ImageUrl", "IsDeleted", "LastName", "Location", "Phone", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", "selimdurmus@ogrenci.com", "Selim", "erkek", "1.png", false, "Durmuş", "Üsküdar/İstanbul", "0547 888 1520", "selimdurmus", null },
                    { 2, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Hazırlık Öğrencisi", "defnegormus@ogrenci.com", "Defne", "kız", "2.png", false, "Görmüş", "Çankaya/Ankara", "0547 888 1527", "defnegormus", null },
                    { 3, 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", "hazalkara@ogrenci.com", "Hazal", "kız", "3.png", false, "Kara", "Çukurova/Adana", "0547 555 1520", "hazalkara", null },
                    { 4, 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", "gozdeceken@ogrenci.com", "Gözde", "kız", "4.png", false, "Çeken", "Bahçelievler/İstanbul", "0535 888 1520", "gozdeceken", null },
                    { 5, 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", "huseyinkazanmış@ogrenci.com", "Hüseyin", "erkek", "5.png", false, "Kazanmış", "Küçükçekmece/İstanbul", "0547 878 1520", "huseyinkazanmıs", null },
                    { 6, 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", "bilaltelli@ogrenci.com", "Bilal", "erkek", "6.png", false, "Telli", "Bornova/İzmir", "0547 888 1820", "bilaltelli", null },
                    { 7, 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lise Öğrencisi", "yunusdeniz@ogrenci.com", "Yunus", "erkek", "7.png", false, "Deniz", "İzmit/Kocaeli", "0547 456 1520", "denizyunus", null },
                    { 8, 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Hazırlık Öğrencisi", "cemrekıran@ogrenci.com", "Cemre", "kadın", "8.png", false, "Kıran", "Üsküdar/İstanbul", "0488 888 1520", "cemrekıran", null },
                    { 9, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", "yusufgüzel@ogrenci.com", "Yusuf", "erkek", "9.png", false, "Güzel", "Yüreğir/Adana", "0547 222 1520", "yusufguzel", null },
                    { 10, 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", "harunbulut@ogrenci.com", "Harun", "erkek", "10.png", false, "Bulut", "İskenderun/Hatay", "0547 888 1827", "harunbulut", null },
                    { 11, 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Üniversite Öğrencisi", "yıldızmutlu@ogrenci.com", "Yıldız", "kız", "11.png", false, "Mutlu", "Pendik/İstanbul", "0547 888 2282", "yıldızmutlu", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Age", "CertifiedTrainer", "DateAdded", "Description", "Email", "FirstName", "Gender", "HourlyPrice", "ImageUrl", "IsDeleted", "IsFacetoFace", "LastName", "Location", "Phone", "UniverstyGraduatedFrom", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, 27, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Engish lessons are given.", "jackbrand@ozelders.com", "Jack", "erkek", 800, "20.png", false, false, "Brand", "Toronto/Canada", "0543 755 8282", "Cambridge University", "jackbrand", null },
                    { 2, 27, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fizik dersi verilir.", "sevgiozer@ozelders.com", "Sevgi", "kadın", 400, "21.png", false, true, "Özer", "Avcılar/İstanbul", "0543 855 8282", "İstanbul Üniversitesi", "sevgiozer", null },
                    { 3, 35, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matematik dersi verilir.", "denizkuru@ozelders.com", "Deniz", "kadın", 600, "22.png", false, true, "Kuru", "Avcılar/İstanbul", "0543 455 8282", "Fırat Üniversitesi", "denizkuru", null },
                    { 4, 30, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kimya dersi verilir.", "fıratgoren@ozelders.com", "Fırat", "erkek", 650, "23.png", false, true, "Gören", "Çankaya/Ankara", "0543 755 4545", "Marmara Üniversitesi", "fıratgören", null },
                    { 5, 40, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C# dersi verilir.", "kemaleren@ozelders.com", "Kemal", "erkek", 400, "24.png", false, true, "Eren", "Bornova/İzmir", "0535 755 8282", "Fırat Üniversitesi", "kemaleren", null },
                    { 6, 25, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Edebiyat dersi verilir.", "melissusan@ozelders.com", "Melis", "kadın", 600, "25.png", false, true, "Susan", "Sefaköy/İstanbul", "0548 755 8282", "İstanbul Üniversitesi", "melissusan", null },
                    { 7, 34, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Almanca dersi verilir.", "defnebilen@ozelders.com", "Defne", "kadın", 500, "26.png", false, false, "Bilen", "Buca/İzmir", "0543 755 7235", "Dokuz Eylül Üniversitesi", "defnebilen", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "77b145e6-90f8-4254-b420-7598b079d5d0", "33a2a1c3-ba58-4881-92c1-9185c4e901e7" },
                    { "77b145e6-90f8-4254-b420-7598b079d5d0", "5b75301c-6dd3-47b8-92dd-8290e877ac8a" },
                    { "3383e82d-1809-4990-a29a-2caef97e7d56", "eb46bb5a-e294-4b38-8dca-a203c7c2686d" },
                    { "77b145e6-90f8-4254-b420-7598b079d5d0", "f56c5be6-af7c-4638-a9f0-8bc8daf276be" }
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
