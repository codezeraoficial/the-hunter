﻿using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using Service.Interfaces;
using Service.Notifications;

namespace Service.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }
        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }
        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entiy) where TV: AbstractValidator<TE> where TE: Entity
        {
            var validator = validation.Validate(entiy);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
