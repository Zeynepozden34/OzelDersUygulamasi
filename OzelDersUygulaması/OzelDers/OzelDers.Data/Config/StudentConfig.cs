using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OzelDers.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzelDers.Data.Config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(s => s.LastName)
             .IsRequired()
             .HasMaxLength(75);

            builder.Property(s => s.UserName);
            builder.Property(s => s.Email);
            builder.Property<bool>(s => s.EmailConfirmed);

            builder.Property(s => s.Description)
                
                .HasMaxLength(13);

            builder.Property<int>(s => s.Age);
                

            builder.Property(s => s.Gender)
                
                .HasMaxLength(5);

            builder.Property(s=>s.ImageUrl)
                
                .HasMaxLength(250);

            builder.Property(s => s.Location)
               
                .HasMaxLength(200);

            builder.Property(s => s.Url)
              
               .HasMaxLength(200);

            builder.ToTable("Students");

            builder.HasData(
                new Student { Id = 1, FirstName = "Selim", LastName = "Durmuş", Description = "Lise Öğrencisi", Age = 17, Gender = "erkek", ImageUrl = "1.png", Location = "Üsküdar/İstanbul", Url="selimdurmus" },

                new Student { Id = 2, FirstName = "Defne", LastName = "Görmüş", Description = "Üniversite Hazırlık Öğrencisi", Age = 18, Gender = "kız", ImageUrl = "2.png", Location = "Çankaya/Ankara", Url= "defnegormus" },

                new Student { Id = 3, FirstName = "Hazal", LastName = "Kara", Description = "Üniversite Öğrencisi", Age = 21, Gender = "kız", ImageUrl = "3.png", Location = "Çukurova/Adana", Url = "hazalkara" },

                new Student { Id = 4, FirstName = "Gözde", LastName = "Çeken", Description = "Üniversite Öğrencisi", Age = 23, Gender = "kız", ImageUrl = "4.png", Location = "Bahçelievler/İstanbul" , Url = "gozdeceken" },

                new Student { Id = 5, FirstName = "Hüseyin", LastName = "Kazanmış",  Description = "Lise Öğrencisi", Age = 17, Gender = "erkek", ImageUrl = "5.png", Location = "Küçükçekmece/İstanbul" , Url = "huseyinkazanmıs" },

                new Student { Id = 6, FirstName = "Bilal", LastName = "Telli", Description = "Lise Öğrencisi", Age = 16, Gender = "erkek", ImageUrl = "6.png", Location = "Bornova/İzmir" , Url = "bilaltelli" },

                new Student { Id = 7, FirstName = "Yunus", LastName = "Deniz",  Description = "Lise Öğrencisi", Age = 15, Gender = "erkek", ImageUrl = "7.png", Location = "İzmit/Kocaeli", Url="denizyunus"  },

                new Student { Id = 8, FirstName = "Cemre", LastName = "Kıran",  Description = "Üniversite Hazırlık Öğrencisi", Age = 18, Gender = "kadın", ImageUrl = "8.png", Location = "Üsküdar/İstanbul", Url="cemrekıran" },

                new Student { Id = 9, FirstName = "Yusuf", LastName = "Güzel", Description = "Üniversite Öğrencisi", Age = 19, Gender = "erkek", ImageUrl = "9.png", Location = "Yüreğir/Adana" , Url = "yusufguzel" },

                new Student { Id = 10, FirstName = "Harun", LastName = "Bulut",  Description = "Üniversite Öğrencisi", Age = 19, Gender = "erkek", ImageUrl = "10.png", Location = "İskenderun/Hatay" , Url = "harunbulut" },

                new Student { Id = 11, FirstName = "Yıldız", LastName = "Mutlu", Description = "Üniversite Öğrencisi", Age = 20, Gender = "kız", ImageUrl = "11.png", Location = "Pendik/İstanbul" , Url = "yıldızmutlu" }


                );
        }
    }
}
