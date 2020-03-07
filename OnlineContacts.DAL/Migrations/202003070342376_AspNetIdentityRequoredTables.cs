namespace OnlineContacts.DAL.Migrations
{
    using OnlineContacts.DAL.Helpers;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AspNetIdentityRequoredTables : DbMigration
    {
        public override void Up()
        {
            var resource = ScriptLoader.Load("OnlineContacts.DAL.Scripts.ASPNETIdentityTablesCreation.sql");

            if (!string.IsNullOrEmpty(resource))
            {
                Sql(resource);
            }
        }
        
        public override void Down()
        {
        }
    }
}
