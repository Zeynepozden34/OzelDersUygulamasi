using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Config
{
    public class TeacherConfig : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
             builder.HasKey(t => t.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.UniverstyGraduatedFrom)           
           .HasMaxLength(100);

            builder.Property<int>(t => t.HourlyPrice);


            builder.Property<bool>(t => t.IsFacetoFace);


            builder.Property<bool>(t => t.CertifiedTrainer);
               

            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(t => t.LastName)
             .IsRequired()
             .HasMaxLength(75);

            builder.Property(t => t.UserName);

            builder.Property(t => t.Email);
            builder.Property<bool>(t => t.EmailConfirmed);




            builder.Property(t => t.Description);


            builder.Property<int>(t => t.Age);
                

            builder.Property(t => t.Gender)                
                .HasMaxLength(5);

            builder.Property(t => t.ImageUrl)
                .HasMaxLength(250);

            builder.Property(t => t.Location)
                .HasMaxLength(200);

            builder.Property(t => t.Url)
                
                .HasMaxLength(200);
            

            builder.ToTable("Teachers");

            builder.HasData(
                new Teacher
                {
                    Id = 1,
                    UniverstyGraduatedFrom = "Cambridge University",
                    HourlyPrice = 800,
                    IsFacetoFace = false,
                    CertifiedTrainer = true,
                    FirstName = "Jack",
                    LastName = "Brand",
                    Description = "Engish lessons are given.",
                    Age = 27,
                    Gender = "erkek",
                    ImageUrl = "20.png",
                    Location = "Toronto/Canada",
                    Url="jackbrand"
                    
                },
                new Teacher
                {
                    Id = 2,
                    UniverstyGraduatedFrom = "İstanbul Üniversitesi",
                    HourlyPrice = 400,
                    IsFacetoFace = true,
                    CertifiedTrainer = true,
                    FirstName = "Sevgi",
                    LastName = "Özer",
                    Description = "Fizik dersi verilir.",
                    Age = 27,
                    Gender = "kadın",
                    ImageUrl = "21.png",
                    Location = "Avcılar/İstanbul",
                    Url="sevgiozer"
                },

                new Teacher
                {
                    Id = 3,
                    UniverstyGraduatedFrom = "Fırat Üniversitesi",
                    HourlyPrice = 600,
                    IsFacetoFace = true,
                    CertifiedTrainer = true,
                    FirstName = "Deniz",
                    LastName = "Kuru",
                    Description = "Matematik dersi verilir.",
                    Age = 35,
                    Gender = "kadın",
                    ImageUrl = "22.png",
                    Location = "Avcılar/İstanbul",
                    Url="denizkuru"
                },

                new Teacher
                {
                    Id = 4,
                    UniverstyGraduatedFrom = "Marmara Üniversitesi",
                    HourlyPrice = 650,
                    IsFacetoFace = true,
                    CertifiedTrainer = true,
                    FirstName = "Fırat",
                    LastName = "Gören",
                    Description = "Kimya dersi verilir.",
                    Age = 30,
                    Gender = "erkek",
                    ImageUrl = "23.png",
                    Location = "Çankaya/Ankara",
                    Url="fıratgören"
                },

                new Teacher
                {
                    Id = 5,
                    UniverstyGraduatedFrom = "Fırat Üniversitesi",
                    HourlyPrice = 400,
                    IsFacetoFace = true,
                    CertifiedTrainer = false,
                    FirstName = "Kemal",
                    LastName = "Eren",
                    Description = "C# dersi verilir.",
                    Age = 40,
                    Gender = "erkek",
                    ImageUrl = "24.png",
                    Location = "Bornova/İzmir",
                    Url="kemaleren"
                },

                new Teacher
                {
                    Id = 6,
                    UniverstyGraduatedFrom = "İstanbul Üniversitesi",
                    HourlyPrice = 600,
                    IsFacetoFace = true,
                    CertifiedTrainer = true,
                    FirstName = "Melis",
                    LastName = "Susan",
                    Description = "Edebiyat dersi verilir.",
                    Age = 25,
                    Gender = "kadın",
                    ImageUrl = "25.png",
                    Location = "Sefaköy/İstanbul",
                    Url="melissusan"
                },
                new Teacher
                {
                    Id = 7,
                    UniverstyGraduatedFrom = "Dokuz Eylül Üniversitesi",
                    HourlyPrice = 500,
                    IsFacetoFace = false,
                    CertifiedTrainer = true,
                    FirstName = "Defne",
                    LastName = "Bilen",
                    Description = "Almanca dersi verilir.",
                    Age = 34,
                    Gender = "kadın",
                    ImageUrl = "26.png",
                    Location = "Buca/İzmir",
                    Url="defnebilen"
                }
                );
        }
    }
}
