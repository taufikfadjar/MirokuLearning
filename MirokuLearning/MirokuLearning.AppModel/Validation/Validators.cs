using FluentValidation;
using MirokuLearning.AppModel.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MirokuLearning.AppModel.Validation
{
    public class ItemViewModelValidator : AbstractValidator<ItemViewModel>
    {
        public ItemViewModelValidator()
        {
            RuleFor(x => x.ItemCode).NotEmpty().Length(4,7);
            RuleFor(x => x.ItemDescription).NotEmpty().Length(5, 250);
            RuleFor(x => x.ItemName).NotEmpty().Length(1, 75);
        }
    }
}
