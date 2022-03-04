using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();

                if (!context.Genres.Any())
                {
                    Console.WriteLine("Genres added to database");

                    context.Genres.AddRange(
                    new Genre
                    {
                        Id = 1,
                        Name = "Horror",
                    },
                    new Genre
                    {
                        Id = 2,
                        Name = "Programming",
                    },
                    new Genre
                    {
                        Id = 3,
                        Name = "Sci-Fi",
                    },
                    new Genre
                    {
                        Id = 4,
                        Name = "Novel",
                    }
                    );
                }

                if (!context.Books.Any())
                {
                    Console.WriteLine("Books added to database");

                    context.Books.AddRange(
                    new Book
                    {
                        Name = "C# 8.0 Programowanie",
                        AuthorName = "I. Griffiths",
                        GenreId = 2,
                        NumberInStock = 3,
                    },
                    new Book
                    {
                        Name = "Pan Tadeusz",
                        AuthorName = "A. Mickiewicz",
                        GenreId = 4,
                        NumberInStock = 5,
                    },
                    new Book
                    {
                        Name = "Ludzie bezdomni",
                        AuthorName = "S. Żeromski",
                        GenreId = 4,
                        NumberInStock = 15,
                    }
                    );
                }

                if (!context.MembershipTypes.Any())
                {
                    Console.WriteLine("MembershipTypes added to database");
                    
                    context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name="Pay as You go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0,
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name="Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10,
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name="Quaterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15,
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name="Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20,
                    });
                }

                if (!context.RoleTypes.Any())
                {
                    Console.WriteLine("RoleTypes added to database");

                    context.RoleTypes.AddRange(
                    new RoleType
                    {
                        Id = 1,
                        Name = "User"
                    },
                    new RoleType
                    {
                        Id = 2,
                        Name = "StoreManager"
                    },
                    new RoleType
                    {
                        Id= 3,
                        Name = "Owner"
                    }
                    );
                }

                if (!context.Customers.Any())
                {
                    Console.WriteLine("Customers added to database");

                    context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Patryk Jablonski",
                        Email = "pj@pj.pl",
                        PasswordHash = "pjablonski",
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 3,
                        Birthdate = DateTime.Parse("05/03/1998"),
                        RoleTypeId = 1
                    },
                    new Customer
                    {
                        Name = "Wojciech Cejrowski",
                        Email = "wc@wc.wc",
                        PasswordHash = "wcejrowski",
                        HasNewsletterSubscribed = true,
                        MembershipTypeId = 4,
                        Birthdate = DateTime.Parse("05/10/1964"),
                        RoleTypeId = 2
                    },
                    new Customer
                    {
                        Name = "Adam Lis",
                        Email= "al@al.al",
                        PasswordHash = "alis",
                        HasNewsletterSubscribed = false,
                        MembershipTypeId = 2,
                        Birthdate = DateTime.Parse("01/11/1989"),
                        RoleTypeId = 3
                    }
                    );
                }

                context.SaveChanges();
            }
        }
    }
}
