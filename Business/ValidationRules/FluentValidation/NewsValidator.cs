using Business.Constants;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class NewsValidator:AbstractValidator<NewsDto>
    {
        public NewsValidator()
        {
            RuleFor(p => p.Caption).NotEmpty().WithMessage(Messages.NewsCaptionNotEmpty);
            RuleFor(p => p.Content).NotEmpty().WithMessage(Messages.NewsContentNotEmpty);
        }
    }
}
