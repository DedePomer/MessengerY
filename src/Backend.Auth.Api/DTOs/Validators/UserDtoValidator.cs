using FluentValidation;

namespace Backend.Auth.Api.DTOs.Validators;

public class UserDtoValidator:AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username обязателен")
            .Length(50).WithMessage("Username не может быть длинее 50 символов");

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(8).WithMessage("Пароль минимум 8 символов")
            .MaximumLength(32).WithMessage("Пароль максимум 32 символа");
    }
}