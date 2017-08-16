namespace MirokuLearning.Business
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Linq;

    public class MirokuLearningContext : DbContext
    {
        // Your context has been configured to use a 'MirokuLearningContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MirokuLearning.Business.MirokuLearningContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MirokuLearningContext' 
        // connection string in the application configuration file.
        public MirokuLearningContext()
            : base("MirokuLearningContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MirokuLearningContext, MirokuLearning.Business.Migrations.Configuration>("SchoolDBConnectionString"));
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<InstructionInOut> InstructionInOuts { get; set; }
        public virtual DbSet<TransactionInOut> TransactionInOuts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstructionInOut>()
                .HasMany<TransactionInOut>(s => s.TransactionInOuts)
                .WithOptional(s => s.InstructionInOut);

            base.OnModelCreating(modelBuilder);
        }
    }

    public class Item
    {
        [Key]
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public long ItemTotalQty { get; set; }
    }

    public class InstructionInOut
    {
        public InstructionInOut()
        {
            TransactionInOuts = new List<TransactionInOut>();
        }

        [Key]
        public long InstructionInOutId { get; set; }
        public string TypeInstruction { get; set; }
        public virtual ICollection<TransactionInOut> TransactionInOuts { get; set; }
    }

    public class TransactionInOut
    {
        [Key]
        public long TransactionInOutId { get; set; }
        public virtual Item Item { get; set; }
        public virtual InstructionInOut InstructionInOut { get; set; }
        public long TransactionInOutQty { get; set; }
    }

   
}