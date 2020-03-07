namespace OnlineContacts.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initMigrationCreatTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 12),
                        Address = c.String(),
                        Notes = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ModifiedDate = c.DateTime(),
                        CreatedUser = c.String(),
                        ModifiedUser = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ContactEntities");
        }
    }
}
