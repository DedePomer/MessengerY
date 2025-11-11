using FluentValidation;

namespace Backend.Auth.Api.DTOs.Validators;

public class UserDtoValidator:AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(u => u.Username)
            .NotEmpty().WithMessage("Username обязателен")
            .MaximumLength(50).WithMessage("Username не может быть длинее 50 символов");

        RuleFor(u => u.Password)
            .NotEmpty()
            .Length(8,32).WithMessage("Пароль минимум 8 символов, максимум 32");
    }
    
}