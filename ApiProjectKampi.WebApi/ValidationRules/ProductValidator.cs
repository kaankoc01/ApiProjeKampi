using ApiProjectKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjectKampi.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez"); 
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır");
            RuleFor(p => p.ProductName).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez")
                .GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz")
                .LessThan(1000).WithMessage("Ürün fiyatı Bu kadar yüksek olamaz girdiğiniz değeri kontrol ediniz.");

            RuleFor(p => p.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez");

        }
    }
}
