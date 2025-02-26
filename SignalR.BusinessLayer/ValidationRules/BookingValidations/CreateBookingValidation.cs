using FluentValidation;
using SignalR.DtoLayer.BookingDtos;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon Alanı Boş Geçilemez!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez!");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Alanı Boş Geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Alanı Boş Geçilemez!");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("İsim Alanı En Az 5 Karakter Olmalıdır!");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim Alanı En Fazla 50 Karakter Olmalıdır!");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Açıklama Alanı En Fazla 250 Karakter Olmalıdır!");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Geçerli Bir Email Adresi Giriniz!");
        }
    }
}
