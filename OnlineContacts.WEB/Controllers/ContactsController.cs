using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OnlineContacts.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineContacts.shared.DTOs;
using OnlineContacts.shared.Enums;

using System.Web.ModelBinding;

namespace OnlineContacts.WEB.Controllers
{
    [Authorize]
    public class ContactsController : BaseController
    {
        // GET: Contacts
        private readonly ContactesModel contactesModel;
        public ContactsController(ContactesModel ContactesModel)
        {
            contactesModel = ContactesModel;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _ContactInfo(int? Id)
        {
            var Model = new shared.DTOs.ContactDTO();
            if (Id.HasValue)
            {
                 Model = contactesModel.GetContact(Id.Value);
                if (Model == null)
                    Model = new shared.DTOs.ContactDTO();
            }
            
                
            return PartialView(Model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateOrEditContact(ContactDTO model)
        {
            string operationMode = OperationMode.Add.ToString();
            bool sucessed = false;
            if(ModelState.IsValid)
            {
                ContactDTO res;
                if(model.Id == 0)
                {
                    // new record
                    res = contactesModel.AddNewContact(model);
                }
                else
                {
                    // edit
                    operationMode = OperationMode.Edit.ToString();
                    res = contactesModel.EditContact(model);
                }
                if (res != null)
                {
                    sucessed = true;
                    model.Id = res.Id;
                }

            }

            var Errors = ModelState.Where(d => d.Value.Errors.Count > 0).ToDictionary(k => k.Key, k => k.Value.Errors.Select(s => s.ErrorMessage).FirstOrDefault());


            return Json(new { Success = sucessed, Mode = operationMode, _Id = model.Id},JsonRequestBehavior.AllowGet);



        }

        public ActionResult Delete(int Id)
        {
            bool deleted = contactesModel.DeleteContact(Id);
            return Json(new { success = deleted }, JsonRequestBehavior.AllowGet);
        }

        #region Fill Grid

        public ActionResult Contacts_Read([DataSourceRequest]DataSourceRequest request)
        {
            var Data = contactesModel.GetForGrid();
            if (request.Sorts.Count > 1)
            {
                request.Sorts.Remove(request.Sorts.FirstOrDefault(d => d.Member == "CreatedDate"));
            }
            return Json(Data.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        #endregion


    }
}
