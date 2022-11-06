namespace StudentManagementAPI.Migrations
{
    using StudentManagementAPI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentManagementAPI.Models.StudentManagementEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(StudentManagementAPI.Models.StudentManagementEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
         }

        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<Mark> Marks { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

    }
}
