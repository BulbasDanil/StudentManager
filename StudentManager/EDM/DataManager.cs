using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentManager.Models;

namespace StudentManager.EDM
{
    public class DataManager : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Group> Groups { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"workstation id=StudentManager.mssql.somee.com;packet size=4096;user id=pepega_SQLLogin_1;pwd=eidokvke81;data source=StudentManager.mssql.somee.com;persist security info=False;initial catalog=StudentManager ");
        }
    }
}
