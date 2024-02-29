using FluentValidation;
using NewAPIDemo.Models;

namespace NewAPIDemo.UserValidation
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x=>x.UserName)
                .NotNull().WithMessage("UserName is Required")
                .NotEmpty().WithMessage("UserName cannot be empty")
                .Length(5,30).WithMessage("UserName must be between 5 and 30 characters");
            RuleFor(x=>x.Email)
                .NotEmpty().WithMessage("Email is Required")
                .MaximumLength(40).WithMessage("Length should be less than 40 characters")
                .EmailAddress().WithMessage("Invalid Email Address")
                .WithName("User Email Address");
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("FirstName must not be null");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password is Required")
                .NotEmpty().WithMessage("Password cannot be empty")
                .Length(6, 50).WithMessage("Password must be between 6 and 50 characters")
                .Matches("(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{2,})$").WithMessage("Password can only contain alphanumeric character");
            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Confirm Password must be match Password")
                .DependentRules(() =>
                {
                    RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty when ConfirmPassword is Provided");
                });
            RuleFor(x => x.DOB)
                .NotEmpty().WithMessage("DOB is required")
                .LessThan(DateTime.Now).WithMessage("DOB must be in the past");
                //.Must(BeAValidAge);


        }
        public bool BeAValidAge(DateTime date)
        {
            int currentYear = DateTime.Now.Year;
            int dobYear = date.Year;

            if (dobYear <= currentYear && dobYear > (currentYear - 120))
            {
                return true;
            }

            return false;
        }
    }
}
