using System;
using System.Linq;
using System.Web;
using NLog;
using OnlineContacts.BLL.Managers.Interfaces;
using OnlineContacts.shared.DTOs;
namespace OnlineContacts.WEB.Models
{
    public class ContactesModel
    {
        private readonly IContactManager contactManager;
        public ContactesModel(IContactManager IContactManager)
        {
            contactManager = IContactManager;
        }
        internal IQueryable<ContactDTO> GetForGrid()
        {
            try
            {
                return contactManager.GetForGrid();
            }
            catch (Exception ex)
            {

                var loger = LogManager.GetLogger("*");
                loger.Log(LogLevel.Error, ex.Message);
                return null;
            }

         
        }

        internal ContactDTO AddNewContact(ContactDTO Model)
        {
           

            try
            {
                return contactManager.Add(Model);
            }
            catch (Exception ex)
            {

                var loger = LogManager.GetLogger("*");
                loger.Log(LogLevel.Error, ex.Message);
                return null;
            }

        }

        internal ContactDTO EditContact(ContactDTO Model)
        {
            

            try
            {
                return contactManager.Update(Model);
            }
            catch (Exception ex)
            {

                var loger = LogManager.GetLogger("*");
                loger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        internal ContactDTO GetContact(int Id)
        {
           
            try
            {
                return contactManager.GetById(Id);
            }
            catch (Exception ex)
            {

                var loger = LogManager.GetLogger("*");
                loger.Log(LogLevel.Error, ex.Message);
                return null;
            }
        }

        internal bool DeleteContact(int Id)
        {
            try
            {
                contactManager.DeleteById(Id);
                return true;
            }
            catch (Exception ex)
            {

                var loger = LogManager.GetLogger("*");
                loger.Log(LogLevel.Error, ex.Message);
                return false;
            }
           
           
        }
    }
}