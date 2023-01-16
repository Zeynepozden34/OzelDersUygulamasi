﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OzelDers.Data.Concrete.EfCore.Contexts;

#nullable disable

namespace OzelDers.Data.Migrations
{
    [DbContext(typeof(OzelDersContext))]
    [Migration("20230116151844_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Branchs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Matematik",
                            Url = "matematik"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Fizik",
                            Url = "fizik"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kimya",
                            Url = "kimya"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tarih",
                            Url = "tarih"
                        },
                        new
                        {
                            Id = 5,
                            Name = "İngilizce",
                            Url = "ingilizce"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Edebiyat",
                            Url = "edebiyat"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Biyoloji",
                            Url = "biyoloji"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Almanca",
                            Url = "almanca"
                        },
                        new
                        {
                            Id = 9,
                            Name = "C#",
                            Url = "c#"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Felsefe",
                            Url = "felsefe"
                        });
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Identity.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Identity.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 17,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lise Öğrencisi",
                            Email = "selimdurmus@ogrenci.com",
                            FirstName = "Selim",
                            Gender = "erkek",
                            ImageUrl = "1.png",
                            IsDeleted = false,
                            LastName = "Durmuş",
                            Location = "Üsküdar/İstanbul",
                            Phone = "0547 888 1520",
                            Url = "selimdurmus"
                        },
                        new
                        {
                            Id = 2,
                            Age = 18,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Hazırlık Öğrencisi",
                            Email = "defnegormus@ogrenci.com",
                            FirstName = "Defne",
                            Gender = "kız",
                            ImageUrl = "2.png",
                            IsDeleted = false,
                            LastName = "Görmüş",
                            Location = "Çankaya/Ankara",
                            Phone = "0547 888 1527",
                            Url = "defnegormus"
                        },
                        new
                        {
                            Id = 3,
                            Age = 21,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Öğrencisi",
                            Email = "hazalkara@ogrenci.com",
                            FirstName = "Hazal",
                            Gender = "kız",
                            ImageUrl = "3.png",
                            IsDeleted = false,
                            LastName = "Kara",
                            Location = "Çukurova/Adana",
                            Phone = "0547 555 1520",
                            Url = "hazalkara"
                        },
                        new
                        {
                            Id = 4,
                            Age = 23,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Öğrencisi",
                            Email = "gozdeceken@ogrenci.com",
                            FirstName = "Gözde",
                            Gender = "kız",
                            ImageUrl = "4.png",
                            IsDeleted = false,
                            LastName = "Çeken",
                            Location = "Bahçelievler/İstanbul",
                            Phone = "0535 888 1520",
                            Url = "gozdeceken"
                        },
                        new
                        {
                            Id = 5,
                            Age = 17,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lise Öğrencisi",
                            Email = "huseyinkazanmış@ogrenci.com",
                            FirstName = "Hüseyin",
                            Gender = "erkek",
                            ImageUrl = "5.png",
                            IsDeleted = false,
                            LastName = "Kazanmış",
                            Location = "Küçükçekmece/İstanbul",
                            Phone = "0547 878 1520",
                            Url = "huseyinkazanmıs"
                        },
                        new
                        {
                            Id = 6,
                            Age = 16,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lise Öğrencisi",
                            Email = "bilaltelli@ogrenci.com",
                            FirstName = "Bilal",
                            Gender = "erkek",
                            ImageUrl = "6.png",
                            IsDeleted = false,
                            LastName = "Telli",
                            Location = "Bornova/İzmir",
                            Phone = "0547 888 1820",
                            Url = "bilaltelli"
                        },
                        new
                        {
                            Id = 7,
                            Age = 15,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Lise Öğrencisi",
                            Email = "yunusdeniz@ogrenci.com",
                            FirstName = "Yunus",
                            Gender = "erkek",
                            ImageUrl = "7.png",
                            IsDeleted = false,
                            LastName = "Deniz",
                            Location = "İzmit/Kocaeli",
                            Phone = "0547 456 1520",
                            Url = "denizyunus"
                        },
                        new
                        {
                            Id = 8,
                            Age = 18,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Hazırlık Öğrencisi",
                            Email = "cemrekıran@ogrenci.com",
                            FirstName = "Cemre",
                            Gender = "kadın",
                            ImageUrl = "8.png",
                            IsDeleted = false,
                            LastName = "Kıran",
                            Location = "Üsküdar/İstanbul",
                            Phone = "0488 888 1520",
                            Url = "cemrekıran"
                        },
                        new
                        {
                            Id = 9,
                            Age = 19,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Öğrencisi",
                            Email = "yusufgüzel@ogrenci.com",
                            FirstName = "Yusuf",
                            Gender = "erkek",
                            ImageUrl = "9.png",
                            IsDeleted = false,
                            LastName = "Güzel",
                            Location = "Yüreğir/Adana",
                            Phone = "0547 222 1520",
                            Url = "yusufguzel"
                        },
                        new
                        {
                            Id = 10,
                            Age = 19,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Öğrencisi",
                            Email = "harunbulut@ogrenci.com",
                            FirstName = "Harun",
                            Gender = "erkek",
                            ImageUrl = "10.png",
                            IsDeleted = false,
                            LastName = "Bulut",
                            Location = "İskenderun/Hatay",
                            Phone = "0547 888 1827",
                            Url = "harunbulut"
                        },
                        new
                        {
                            Id = 11,
                            Age = 20,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Üniversite Öğrencisi",
                            Email = "yıldızmutlu@ogrenci.com",
                            FirstName = "Yıldız",
                            Gender = "kız",
                            ImageUrl = "11.png",
                            IsDeleted = false,
                            LastName = "Mutlu",
                            Location = "Pendik/İstanbul",
                            Phone = "0547 888 2282",
                            Url = "yıldızmutlu"
                        });
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.StudentAndTeacher", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StudentId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("StudentAndTeachers");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            TeacherId = 1
                        },
                        new
                        {
                            StudentId = 2,
                            TeacherId = 2
                        },
                        new
                        {
                            StudentId = 3,
                            TeacherId = 2
                        },
                        new
                        {
                            StudentId = 4,
                            TeacherId = 3
                        },
                        new
                        {
                            StudentId = 5,
                            TeacherId = 4
                        },
                        new
                        {
                            StudentId = 6,
                            TeacherId = 5
                        },
                        new
                        {
                            StudentId = 7,
                            TeacherId = 6
                        },
                        new
                        {
                            StudentId = 8,
                            TeacherId = 1
                        },
                        new
                        {
                            StudentId = 9,
                            TeacherId = 3
                        });
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("CertifiedTrainer")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("TEXT");

                    b.Property<int>("HourlyPrice")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFacetoFace")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UniverstyGraduatedFrom")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 27,
                            CertifiedTrainer = true,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Engish lessons are given.",
                            Email = "jackbrand@ozelders.com",
                            FirstName = "Jack",
                            Gender = "erkek",
                            HourlyPrice = 800,
                            ImageUrl = "20.png",
                            IsDeleted = false,
                            IsFacetoFace = false,
                            LastName = "Brand",
                            Location = "Toronto/Canada",
                            Phone = "0543 755 8282",
                            UniverstyGraduatedFrom = "Cambridge University",
                            Url = "jackbrand"
                        },
                        new
                        {
                            Id = 2,
                            Age = 27,
                            CertifiedTrainer = true,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fizik dersi verilir.",
                            Email = "sevgiozer@ozelders.com",
                            FirstName = "Sevgi",
                            Gender = "kadın",
                            HourlyPrice = 400,
                            ImageUrl = "21.png",
                            IsDeleted = false,
                            IsFacetoFace = true,
                            LastName = "Özer",
                            Location = "Avcılar/İstanbul",
                            Phone = "0543 855 8282",
                            UniverstyGraduatedFrom = "İstanbul Üniversitesi",
                            Url = "sevgiozer"
                        },
                        new
                        {
                            Id = 3,
                            Age = 35,
                            CertifiedTrainer = true,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Matematik dersi verilir.",
                            Email = "denizkuru@ozelders.com",
                            FirstName = "Deniz",
                            Gender = "kadın",
                            HourlyPrice = 600,
                            ImageUrl = "22.png",
                            IsDeleted = false,
                            IsFacetoFace = true,
                            LastName = "Kuru",
                            Location = "Avcılar/İstanbul",
                            Phone = "0543 455 8282",
                            UniverstyGraduatedFrom = "Fırat Üniversitesi",
                            Url = "denizkuru"
                        },
                        new
                        {
                            Id = 4,
                            Age = 30,
                            CertifiedTrainer = true,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Kimya dersi verilir.",
                            Email = "fıratgoren@ozelders.com",
                            FirstName = "Fırat",
                            Gender = "erkek",
                            HourlyPrice = 650,
                            ImageUrl = "23.png",
                            IsDeleted = false,
                            IsFacetoFace = true,
                            LastName = "Gören",
                            Location = "Çankaya/Ankara",
                            Phone = "0543 755 4545",
                            UniverstyGraduatedFrom = "Marmara Üniversitesi",
                            Url = "fıratgören"
                        },
                        new
                        {
                            Id = 5,
                            Age = 40,
                            CertifiedTrainer = false,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "C# dersi verilir.",
                            Email = "kemaleren@ozelders.com",
                            FirstName = "Kemal",
                            Gender = "erkek",
                            HourlyPrice = 400,
                            ImageUrl = "24.png",
                            IsDeleted = false,
                            IsFacetoFace = true,
                            LastName = "Eren",
                            Location = "Bornova/İzmir",
                            Phone = "0535 755 8282",
                            UniverstyGraduatedFrom = "Fırat Üniversitesi",
                            Url = "kemaleren"
                        },
                        new
                        {
                            Id = 6,
                            Age = 25,
                            CertifiedTrainer = true,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Edebiyat dersi verilir.",
                            Email = "melissusan@ozelders.com",
                            FirstName = "Melis",
                            Gender = "kadın",
                            HourlyPrice = 600,
                            ImageUrl = "25.png",
                            IsDeleted = false,
                            IsFacetoFace = true,
                            LastName = "Susan",
                            Location = "Sefaköy/İstanbul",
                            Phone = "0548 755 8282",
                            UniverstyGraduatedFrom = "İstanbul Üniversitesi",
                            Url = "melissusan"
                        },
                        new
                        {
                            Id = 7,
                            Age = 34,
                            CertifiedTrainer = true,
                            DateAdded = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Almanca dersi verilir.",
                            Email = "defnebilen@ozelders.com",
                            FirstName = "Defne",
                            Gender = "kadın",
                            HourlyPrice = 500,
                            ImageUrl = "26.png",
                            IsDeleted = false,
                            IsFacetoFace = false,
                            LastName = "Bilen",
                            Location = "Buca/İzmir",
                            Phone = "0543 755 7235",
                            UniverstyGraduatedFrom = "Dokuz Eylül Üniversitesi",
                            Url = "defnebilen"
                        });
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.TeacherAndBranch", b =>
                {
                    b.Property<int>("TeacherId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BranchId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeacherId", "BranchId");

                    b.HasIndex("BranchId");

                    b.ToTable("TeacherAndBranches");

                    b.HasData(
                        new
                        {
                            TeacherId = 1,
                            BranchId = 5
                        },
                        new
                        {
                            TeacherId = 2,
                            BranchId = 2
                        },
                        new
                        {
                            TeacherId = 3,
                            BranchId = 1
                        },
                        new
                        {
                            TeacherId = 4,
                            BranchId = 3
                        },
                        new
                        {
                            TeacherId = 5,
                            BranchId = 9
                        },
                        new
                        {
                            TeacherId = 6,
                            BranchId = 6
                        },
                        new
                        {
                            TeacherId = 7,
                            BranchId = 8
                        },
                        new
                        {
                            TeacherId = 7,
                            BranchId = 10
                        },
                        new
                        {
                            TeacherId = 2,
                            BranchId = 8
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OzelDers.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Student", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.StudentAndTeacher", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Student", "Student")
                        .WithMany("StudentAndTeachers")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OzelDers.Entity.Concrete.Teacher", "Teacher")
                        .WithMany("StudentAndTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Teacher", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Identity.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.TeacherAndBranch", b =>
                {
                    b.HasOne("OzelDers.Entity.Concrete.Branch", "Branch")
                        .WithMany("TeacherAndBranchs")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OzelDers.Entity.Concrete.Teacher", "Teacher")
                        .WithMany("TeacherAndBranches")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Branch", b =>
                {
                    b.Navigation("TeacherAndBranchs");
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Student", b =>
                {
                    b.Navigation("StudentAndTeachers");
                });

            modelBuilder.Entity("OzelDers.Entity.Concrete.Teacher", b =>
                {
                    b.Navigation("StudentAndTeachers");

                    b.Navigation("TeacherAndBranches");
                });
#pragma warning restore 612, 618
        }
    }
}
