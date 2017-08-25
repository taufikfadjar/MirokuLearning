using FluentValidation.Attributes;
using MirokuLearning.AppModel.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.AppModel.APIViewModels
{
    [Validator(typeof(ItemAPIViewModelValidator))]
    public class ItemViewModel
    {
        public long ItemId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
    }
}
