using CaWorkshop.Application.TodoLists.Commands.CreateTodoList;
using CaWorkshop.Infrastructure.Persistence;
using FluentAssertions;
using FluentValidation.TestHelper;
using Xunit;

namespace CaWorkshop.Application.UnitTests.TodoLists.Commands.CreateTodoList
{
    public class CreateTodoListCommandValidatorTests : IClassFixture<TestFixture>
    {
        private readonly ApplicationDbContext _context;

        public CreateTodoListCommandValidatorTests(TestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public void IsValid_ShouldBeTrue_WhenListTitleIsUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Bucket List"
            };

            var validator = new CreateTodoListCommandValidator(_context);

            var result = validator.TestValidate(command);

            result.IsValid.Should().Be(true);
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenListTitleIsNotUnique()
        {
            var command = new CreateTodoListCommand
            {
                Title = "Todo List"
            };

            var validator = new CreateTodoListCommandValidator(_context);

            var result = validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(r => r.Title)
                .WithErrorCode("UNIQUE_TITLE");
        }
    }
}
