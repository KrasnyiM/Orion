using Microsoft.EntityFrameworkCore;


namespace DbGame
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Game> Games {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Accounting> Accountings {get; set;}

        public ApplicationContext(DbContextOptions<ApplicationContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasMany(e => e.Users).WithMany(e => e.Games)
                .UsingEntity<Accounting>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Myroslav",
                    Surname = "Chervonyi",
                    Email = "miroslavchevonij01@gmail.com",
                    PhoneNumber = "0638576491",
                    Password = "111"
                },
                new User
                {
                    Id = 2,
                    Name = "Andrii",
                    Surname = "Ryzkov",
                    Email = "ryzkovandruha01@gmail.com",
                    PhoneNumber = "063148869",
                    Password = "111"
                },
                new User
                {
                    Id = 3,
                    Name = "Anton",
                    Surname = "Lutsenko",
                    Email = "antonlutsenko01@gmail.com",
                    PhoneNumber = "06344444",
                    Password = "111"
                },
                new User
                {
                    Id = 4,
                    Name = "Slavik",
                    Surname = "Nikituk",
                    Email = "slaviknikituk01@gmail.com",
                    PhoneNumber = "0633344455",
                    Password = "111"
                }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game
                {
                    Id = 1,
                    Name = "Red Dead Redemtion 2",
                    Genre = "RPG",
                    SystemRequirements = "Powerful PC",
                    Description = "It is a classic game about wild West with cowboys and revolvers",
                    Price = 699
                },
                new Game
                {
                    Id = 2,
                    Name = "Dota 2",
                    Genre = "MMORPG",
                    SystemRequirements = "Not PC, calculator",
                    Description = "A Game about niggers, who try to destroy your ass. The conception of the game is one on nine",
                    Price = 666
                },
                new Game
                {
                    Id = 3,
                    Name = "World of tanks",
                    Genre = "MMORPG",
                    SystemRequirements = "Not PC, calculator",
                    Description = "If you play in this game, you are idiot",
                    Price = 0
                });
        }

    }
}
