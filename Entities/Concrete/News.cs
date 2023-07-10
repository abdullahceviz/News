using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class News: IEntity
    {
        public int NewsId { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
        public virtual int UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
