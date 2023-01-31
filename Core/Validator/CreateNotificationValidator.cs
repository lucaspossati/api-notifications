using API.Domain.VM;
using FluentValidation;

namespace api.Validator
{
    public class CreateNotificationValidator : AbstractValidator<NotificationVM>
    {
        public CreateNotificationValidator() 
        {
            RuleFor(p => p.Mensagem)
                .NotNull()
                .MinimumLength(2).WithMessage("Mensagem precisa ter mais de 1 caracter")
                .MaximumLength(200).WithMessage("Mensagem não pode ter mais de 200 caracteres");

            RuleFor(p => p.Assunto).NotNull().NotEmpty().WithMessage("Assunto é obrigatório");
            RuleFor(p => p.Cliente).NotNull().NotEmpty().WithMessage("Cliente é obrigatório");
            RuleFor(p => p.NomeUsuario).NotNull().NotEmpty().WithMessage("NomeUsuario é obrigatório");

            RuleFor(p => p.EmailDestinatario).EmailAddress().WithMessage("Email inválido");
            RuleFor(p => p.Tipo).NotNull().IsInEnum().WithMessage("Tipo inválido");
        }
    }
}
