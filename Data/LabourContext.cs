using Microsoft.EntityFrameworkCore;
using zbs_gp_project.Models;

namespace zbs_gp_project.Data
{
    public class LabourContext : DbContext
    {
        public LabourContext(DbContextOptions<LabourContext> options): base(options) { }
      
        public DbSet<Labour> Labours { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labour>().HasKey(b=> b.Id);

            modelBuilder.Entity<User>().HasKey(b => b.Id);

            modelBuilder.Entity<Labour>()
                .HasOne(b => b.User)
                .WithMany(u => u.Labours)
                .HasForeignKey(b => b.UserId)
                .HasPrincipalKey(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>().HasData(
       new User { Id = "u1abc", Name = "User1", Email = "user1email@gmail.com", Password = "dummyPassword", UserTimeStamp = new DateTime(2002, 12, 12) },
       new User { Id = "u2abc", Name = "User2", Email = "user2email@gmail.com", Password = "dummyPassword", UserTimeStamp = new DateTime(2002, 12, 12) },
       new User { Id = "u3abc", Name = "User3", Email = "user3email@gmail.com", Password = "dummyPassword", UserTimeStamp = new DateTime(2002, 12, 12) },
       new User { Id = "u4abc", Name = "User4", Email = "user4email@gmail.com", Password = "dummyPassword", UserTimeStamp = new DateTime(2002, 12, 12) }
   );

            modelBuilder.Entity<Labour>().HasData(
                // User1
                new Labour { Id = "l1a001", UserId = "u1abc", Title = "Task 1", Description = "Description 1", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l1a002", UserId = "u1abc", Title = "Task 2", Description = "Description 2", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l1a003", UserId = "u1abc", Title = "Task 3", Description = "Description 3", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l1a004", UserId = "u1abc", Title = "Task 4", Description = "Description 4", TimeStamp = new DateTime(2002, 12, 12) },

                // User2
                new Labour { Id = "l2a001", UserId = "u2abc", Title = "Task 5", Description = "Description 5", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l2a002", UserId = "u2abc", Title = "Task 6", Description = "Description 6", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l2a003", UserId = "u2abc", Title = "Task 7", Description = "Description 7", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l2a004", UserId = "u2abc", Title = "Task 8", Description = "Description 8", TimeStamp = new DateTime(2002, 12, 12) },

                // User3
                new Labour { Id = "l3a001", UserId = "u3abc", Title = "Task 9", Description = "Description 9", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l3a002", UserId = "u3abc", Title = "Task 10", Description = "Description 10", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l3a003", UserId = "u3abc", Title = "Task 11", Description = "Description 11", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l3a004", UserId = "u3abc", Title = "Task 12", Description = "Description 12", TimeStamp = new DateTime(2002, 12, 12) },

                // User4
                new Labour { Id = "l4a001", UserId = "u4abc", Title = "Task 13", Description = "Description 13", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l4a002", UserId = "u4abc", Title = "Task 14", Description = "Description 14", TimeStamp = new DateTime(2002, 12, 12) },
                new Labour { Id = "l4a003", UserId = "u4abc", Title = "Task 15", Description = "Description 15", TimeStamp = new DateTime(2002, 12, 12) }
            );



        }

    }
}
