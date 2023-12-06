namespace WarehouseManager1._2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "TIGER.Carts",
                c => new
                    {
                        CartID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ProductID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Quantity = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.CartID)
                .ForeignKey("TIGER.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("TIGER.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "TIGER.Products",
                c => new
                    {
                        ProductID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockQuantity = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Description = c.String(),
                        Image = c.Binary(),
                        Category_CategoryID = c.Decimal(precision: 10, scale: 0),
                        Supplier_SupplierID = c.Decimal(precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("TIGER.Categories", t => t.Category_CategoryID)
                .ForeignKey("TIGER.Suppliers", t => t.Supplier_SupplierID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.Supplier_SupplierID);
            
            CreateTable(
                "TIGER.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        OrderID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        ProductID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Quantity = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Subtotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("TIGER.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("TIGER.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "TIGER.Orders",
                c => new
                    {
                        OrderID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        OrderDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("TIGER.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "TIGER.Users",
                c => new
                    {
                        UserID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        UserType = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "TIGER.Categories",
                c => new
                    {
                        CategoryID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "TIGER.LogEntries",
                c => new
                    {
                        LogEntryID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        UserID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        LogDateTime = c.DateTime(nullable: false),
                        Action = c.String(),
                    })
                .PrimaryKey(t => t.LogEntryID)
                .ForeignKey("TIGER.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "TIGER.NumeratorAllocations",
                c => new
                    {
                        AllocationID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        NumeratorID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        TableName = c.String(),
                    })
                .PrimaryKey(t => t.AllocationID)
                .ForeignKey("TIGER.Numerators", t => t.NumeratorID, cascadeDelete: true)
                .Index(t => t.NumeratorID);
            
            CreateTable(
                "TIGER.Numerators",
                c => new
                    {
                        NumeratorID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        Name = c.String(),
                        CurrentValue = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.NumeratorID);
            
            CreateTable(
                "TIGER.Reviews",
                c => new
                    {
                        ReviewID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        ProductID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        UserID = c.Decimal(nullable: false, precision: 10, scale: 0),
                        Comment = c.String(),
                        Rating = c.Decimal(nullable: false, precision: 10, scale: 0),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("TIGER.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("TIGER.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.UserID);
            
            CreateTable(
                "TIGER.Suppliers",
                c => new
                    {
                        SupplierID = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        SupplierName = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TIGER.Products", "Supplier_SupplierID", "TIGER.Suppliers");
            DropForeignKey("TIGER.Reviews", "UserID", "TIGER.Users");
            DropForeignKey("TIGER.Reviews", "ProductID", "TIGER.Products");
            DropForeignKey("TIGER.NumeratorAllocations", "NumeratorID", "TIGER.Numerators");
            DropForeignKey("TIGER.LogEntries", "UserID", "TIGER.Users");
            DropForeignKey("TIGER.Products", "Category_CategoryID", "TIGER.Categories");
            DropForeignKey("TIGER.OrderDetails", "ProductID", "TIGER.Products");
            DropForeignKey("TIGER.Orders", "UserID", "TIGER.Users");
            DropForeignKey("TIGER.Carts", "UserID", "TIGER.Users");
            DropForeignKey("TIGER.OrderDetails", "OrderID", "TIGER.Orders");
            DropForeignKey("TIGER.Carts", "ProductID", "TIGER.Products");
            DropIndex("TIGER.Reviews", new[] { "UserID" });
            DropIndex("TIGER.Reviews", new[] { "ProductID" });
            DropIndex("TIGER.NumeratorAllocations", new[] { "NumeratorID" });
            DropIndex("TIGER.LogEntries", new[] { "UserID" });
            DropIndex("TIGER.Orders", new[] { "UserID" });
            DropIndex("TIGER.OrderDetails", new[] { "ProductID" });
            DropIndex("TIGER.OrderDetails", new[] { "OrderID" });
            DropIndex("TIGER.Products", new[] { "Supplier_SupplierID" });
            DropIndex("TIGER.Products", new[] { "Category_CategoryID" });
            DropIndex("TIGER.Carts", new[] { "ProductID" });
            DropIndex("TIGER.Carts", new[] { "UserID" });
            DropTable("TIGER.Suppliers");
            DropTable("TIGER.Reviews");
            DropTable("TIGER.Numerators");
            DropTable("TIGER.NumeratorAllocations");
            DropTable("TIGER.LogEntries");
            DropTable("TIGER.Categories");
            DropTable("TIGER.Users");
            DropTable("TIGER.Orders");
            DropTable("TIGER.OrderDetails");
            DropTable("TIGER.Products");
            DropTable("TIGER.Carts");
        }
    }
}
