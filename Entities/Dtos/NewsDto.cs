using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class NewsDto:IDto
    {
        public int NewsId { get; set; }
        public string Caption { get; set; }
        public string Content { get; set; }
        public bool Published { get; set; }
    }
}
