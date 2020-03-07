using System.Data.Entity;

namespace OnlineContacts.DAL.Context
{
   internal class DBMigrationInit : MigrateDatabaseToLatestVersion<OnlienContactContext,Migrations.Configuration>
    {

    }
}
