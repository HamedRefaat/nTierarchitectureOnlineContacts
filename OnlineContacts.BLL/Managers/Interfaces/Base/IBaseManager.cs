using OnlineContacts.shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.BLL.Managers.Interfaces
{
   public interface IBaseManager<TDto> where TDto : BaseDto, IDisposable
    {
        TDto Add(TDto Model);
        TDto Update(TDto Model);
        void DeleteById(object Id);
        TDto GetById(object Id);
        IQueryable<TDto> GetForGrid();
    }
}
