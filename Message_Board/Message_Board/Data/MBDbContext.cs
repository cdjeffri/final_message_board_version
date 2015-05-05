namespace Message_Board.Data
{
    using Message_Board.Migrations;
    using Message_Board.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MBDbContext : DbContext
    {
        // Your context has been configured to use a 'MBDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Message_Board.Data.MBDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MBDbContext' 
        // connection string in the application configuration file.
        public MBDbContext()
            : base("name=MBDbContext")
        {
            Database.SetInitializer<MBDbContext>(new MigrateDatabaseToLatestVersion<MBDbContext, Configuration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Thread> Threads { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}