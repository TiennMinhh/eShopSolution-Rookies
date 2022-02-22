using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Rookie.Ecom.Tests.Assertions;
using Rookie.Ecom.Tests.Validations;

namespace Rookie.Ecom.Tests
{
    public static class AssertionExtensions
    {
        public static ActionResultAssertions Should(this ActionResult actualValue)
            => new ActionResultAssertions(actualValue);

        public static ValidationResultAssertions Should(this ValidationResult actualValue)
            => new ValidationResultAssertions(actualValue);
    }
}
