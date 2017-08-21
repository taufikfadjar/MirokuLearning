using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MirokuLearning.Web.Models
{
    public class ItemViewModel
    {
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}