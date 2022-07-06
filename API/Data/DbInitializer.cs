using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
       public static async Task Initialize(StoreContext context, UserManager<User> userManager)
       {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            };

           if(context.Products.Any()) return;

           var products = new List<Product> 
           {
                new Product
                {
                    Name = "Snowboard Nitro Team Gullwing",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/i01_ski-830668001_171_1_781.jpg",
                    Brand = "Nitro",
                    Type = "Boards",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Snowboard Elan Explore Plus R",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 15000,
                    PictureUrl = "/images/products/i01_ski-brd80618_296_1_193.jpg",
                    Brand = "Elan",
                    Type = "Boards",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Snowboard Nitro Cinema",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/i01_ski-830548001_127_1_727.jpg",
                    Brand = "Nitro",
                    Type = "Boards",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Burton Process Fv Snowboard",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 30000,
                    PictureUrl = "/images/products/i01_10712108_000-01_1.jpg",
                    Brand = "Burton",
                    Type = "Boards",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Nidecker board",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 25000,
                    PictureUrl = "/images/products/i01_blade212-01.jpg",
                    Brand = "Nidecker",
                    Type = "Boards",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Merinotre Men Ski Jacket",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 100000,
                    PictureUrl = "/images/products/i01_aa3999f04c898c44d23b181d92f68358a9d0.jpeg",
                    Brand = "Colmar",
                    Type = "Jacket",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Sapporo-Rec Men Ski-Jacket",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 120000,
                    PictureUrl = "/images/products/i01_ce17f62c5b25df91c6dbccf00ea4fe9cefd0.jpg",
                    Brand = "Colmar",
                    Type = "Jacket",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Colmar M HAT",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 3000,
                    PictureUrl = "/images/products/i01_colmar-m-hat_2.jpg",
                    Brand = "Colmar",
                    Type = "Hats",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Ski Gloves With DNA",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1800,
                    PictureUrl = "/images/products/i01_8033129079451---51831vcin2199c-s-ao-n-d-05-n.jpg",
                    Brand = "Colmar",
                    Type = "Gloves",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Ski Gloves With DNA Printed Fabric",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1500,
                    PictureUrl = "/images/products/i01_8033129079550---51838wmin2195-s-ao-n-d-05-n.jpg",
                    Brand = "Colmar",
                    Type = "Gloves",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Capital TLS",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 25000,
                    PictureUrl = "/images/products/i01_848600-001_capital-tls_black-iridium_product-1_0.jpg",
                    Brand = "Nitro",
                    Type = "Boots",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Team TLS",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 18999,
                    PictureUrl = "/images/products/i01_848556-004_team-tls_white-black_product-1_0.jpg",
                    Brand = "Nitro",
                    Type = "Boots",
                    QuantityInStock = 100
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
       } 
    }
}