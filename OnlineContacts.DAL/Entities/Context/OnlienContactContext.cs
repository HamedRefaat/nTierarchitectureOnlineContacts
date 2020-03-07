namespace OnlineContacts.DAL
{
    using OnlineContacts.DAL.Context;
    using OnlineContacts.DAL.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OnlienContactContext : DbContext
    {
       
        public OnlienContactContext()
            : base("name=OnlienContactContext")
        {
            Database.SetInitializer(new DBMigrationInit());
        }

        public virtual DbSet<ContactEntity> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>().HasKey(c => c.Id);
         
        }

        public override int SaveChanges()
        {
            //ToDo Save the Modified user and modified date for modified Entities 
            //ToDo save added user and craetedDateTime for Added Entites
            int result =  base.SaveChanges();
            //ToDO clear all attaced entities after saving

            return result;
        }

    }

}