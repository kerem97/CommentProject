using CommentProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1MSR6CD\\SQLEXPRESS;initial catalog=DbComment;integrated security=true");
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
