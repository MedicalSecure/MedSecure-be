﻿
using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors;

public class ValidationBehavior<TRequest, TRespone>
    (IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TRespone>
    where TRequest : ICommand<TRespone>
{
    public async Task<TRespone> Handle(TRequest request, RequestHandlerDelegate<TRespone> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        
        var validatorResults = 
            await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
        
        var failures = 
            validatorResults.Where(r => r.Errors.Any()).SelectMany(r => r.Errors).ToList();

        if (failures.Any())
        {
            throw new ValidationException(failures);
        }
        return await next();

    }
}
