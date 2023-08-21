using Microsoft.EntityFrameworkCore;
using MvcBoard.Data;

namespace MvcBoard.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBoardContext(serviceProvider.GetRequiredService<DbContextOptions<MvcBoardContext>>()))
            {
                //Look for any Boards
                if (context.Board.Any())
                {
                    return; //DB has been seeded
                }

                context.Board.AddRange(
                    new Board
                    {
                        Name = "The Minilog",
                        Length = 6.00M,
                        Width = 21.00M,
                        Thickness = 2.75M,
                        Volume = 38.80M,
                        Type = "Shortboard",
                        Price = 565M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "The Wide Glider",
                        Length = 7.10M,
                        Width = 21.75M,
                        Thickness = 2.75M,
                        Volume = 44.16M,
                        Type = "Funboard",
                        Price = 685M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "The Golden Ratio",
                        Length = 6.30M,
                        Width = 21.85M,
                        Thickness = 2.90M,
                        Volume = 43.22M,
                        Type = "Funboard",
                        Price = 695M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "Mahi Mahi",
                        Length = 5.40M,
                        Width = 20.75M,
                        Thickness = 2.30M,
                        Volume = 29.39M,
                        Type = "Fish",
                        Price = 645M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "The Emerald Glider",
                        Length = 9.20M,
                        Width = 22.80M,
                        Thickness = 2.80M,
                        Volume = 65.40M,
                        Type = "Longboard",
                        Price = 895M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "The Bomb",
                        Length = 5.50M,
                        Width = 21.00M,
                        Thickness = 2.50M,
                        Volume = 33.70M,
                        Type = "Shortboard",
                        Price = 645M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "Walden Magic",
                        Length = 9.60M,
                        Width = 19.40M,
                        Thickness = 3.00M,
                        Volume = 80.00M,
                        Type = "Longboard",
                        Price = 1025M,
                        Equipment = ""
                    },
                    new Board
                    {
                        Name = "Naish One",
                        Length = 12.60M,
                        Width = 30.00M,
                        Thickness = 6.00M,
                        Volume = 301.00M,
                        Type = "SUP",
                        Price = 854M,
                        Equipment = "Paddle"
                    },
                    new Board
                    {
                        Name = "Six Tourer",
                        Length = 11.60M,
                        Width = 32.00M,
                        Thickness = 6.00M,
                        Volume = 270.00M,
                        Type = "SUP",
                        Price = 611M,
                        Equipment = "Fin, Paddle, Pump, Leash"
                    },
                    new Board
                    {
                        Name = "Naish Maliko",
                        Length = 11.60M,
                        Width = 25.00M,
                        Thickness = 6.00M,
                        Volume = 330.00M,
                        Type = "SUP",
                        Price = 1304M,
                        Equipment = "Fin, Paddle, Pump, Leash"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
