using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineContacts.shared.DTOs
{
  public  class BaseDto: IDisposable
    {
        public string CreatedUser { get; set; }
        public string ModifiedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? MofdifiedDate { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
