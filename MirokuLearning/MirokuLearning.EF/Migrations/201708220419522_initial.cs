namespace MirokuLearning.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InstructionInOuts",
                c => new
                    {
                        InstructionInOutId = c.Long(nullable: false, identity: true),
                        TypeInstruction = c.String(),
                    })
                .PrimaryKey(t => t.InstructionInOutId);
            
            CreateTable(
                "dbo.TransactionInOuts",
                c => new
                    {
                        TransactionInOutId = c.Long(nullable: false, identity: true),
                        TransactionInOutQty = c.Long(nullable: false),
                        Item_ItemId = c.Long(),
                        InstructionInOut_InstructionInOutId = c.Long(),
                    })
                .PrimaryKey(t => t.TransactionInOutId)
                .ForeignKey("dbo.Items", t => t.Item_ItemId)
                .ForeignKey("dbo.InstructionInOuts", t => t.InstructionInOut_InstructionInOutId)
                .Index(t => t.Item_ItemId)
                .Index(t => t.InstructionInOut_InstructionInOutId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Long(nullable: false, identity: true),
                        ItemCode = c.String(),
                        ItemName = c.String(),
                        ItemDescription = c.String(),
                        ItemTotalQty = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TransactionInOuts", "InstructionInOut_InstructionInOutId", "dbo.InstructionInOuts");
            DropForeignKey("dbo.TransactionInOuts", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.TransactionInOuts", new[] { "InstructionInOut_InstructionInOutId" });
            DropIndex("dbo.TransactionInOuts", new[] { "Item_ItemId" });
            DropTable("dbo.Items");
            DropTable("dbo.TransactionInOuts");
            DropTable("dbo.InstructionInOuts");
        }
    }
}
