using FluentAssertions;
using FluentValidation.Results;
using Moq;
using Rookie.Ecom.Business.Interfaces;
using Rookie.Ecom.Contracts.Dtos;
using Rookie.Ecom.Tests.Validations;
using Rookie.Ecom.UnitTests.API.Validators.TestData;
using Rookie.Ecom.Admin.Validators;
using System.Linq;
using Xunit;

namespace Rookie.Ecom.UnitTests.API.Validators
{
    public class CategoryDtoValidatorShould : BaseValidatorShould
    {
        private readonly ValidationTestRunner<CategoryDtoValidator, CategoryDto> _testRunner;
        private readonly Mock<ICategoryService> _categoryService;

        public CategoryDtoValidatorShould()
        {
            _categoryService = new Mock<ICategoryService>();
            _testRunner = ValidationTestRunner
                .Create<CategoryDtoValidator, CategoryDto>(new CategoryDtoValidator(_categoryService.Object));
        }

        [Theory]
        [MemberData(nameof(CategoryTestData.ValidTexts), MemberType = typeof(CategoryTestData))]
        public void NotHaveErrorWhenNameIsvalid(string name) =>
            _testRunner
                .For(m => m.Name = name)
                .ShouldNotHaveErrorsFor(m => m.Name);

        [Theory]
        [MemberData(nameof(CategoryTestData.ValidTexts), MemberType = typeof(CategoryTestData))]
        public void NotHaveErrorWhenPrefixIsvalid(string desc) =>
           _testRunner
               .For(m => m.Desc = desc)
               .ShouldNotHaveErrorsFor(m => m.Desc);

        [Theory]
        [MemberData(nameof(CategoryTestData.InvalidNames), MemberType = typeof(CategoryTestData))]
        public void HaveErrorWhenNameIsInvalid(string name, string errorMessage) =>
            _testRunner
                .For(m => m.Name = name)
                .ShouldHaveErrorsFor(m => m.Name, errorMessage);

        [Theory]
        [MemberData(nameof(CategoryTestData.InvalidDescs), MemberType = typeof(CategoryTestData))]
        public void HaveErrorWhenDescIsInvalid(string desc, string errorMessage)
        {
            var validator = new CategoryDtoValidator(_categoryService.Object);

            // Act
            ValidationResult result = validator.Validate(new CategoryDto
            {
                Id = System.Guid.NewGuid(),
                Name = "test",
                Desc = desc
            });

            result.Errors.Count.Should().Be(1);
            result
                .Errors
                .Select(x => x.ErrorMessage)
                .ToList()
                .Should()
                .Contain(errorMessage);
        }
    }
}
