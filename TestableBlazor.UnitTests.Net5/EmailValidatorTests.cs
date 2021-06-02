using System;
using System.Linq;
using TestableBlazor.Net5.Shared;
using Xunit;

namespace TestableBlazor.UnitTests.Net5
{
    public class EmailValidatorTests
    {
        [Fact(DisplayName = "Can validate correctly formatted email address")]
        public void ValidateCorrectlyFormattedEmail()
        {
            // Arrange
            var validEmail = "fake@domain.com";
            var uut = new EmailValidator();

            // Act
            var isValid = uut.Validate(validEmail);

            // Assert
            Assert.True(isValid);
        }

        [Fact(DisplayName = "Can invalidate email address missing @")]
        public void InvalidateMissingAt()
        {
            // detect no @ character

            // Arrange
            var invalidEmail = "fakeMissingAtdomain.com";
            var uut = new EmailValidator();

            // Act
            var isValid = uut.Validate(invalidEmail);

            // Assert
            Assert.False(isValid);
        }

        [Theory(DisplayName = "Can validate correctly formatted email address")]
        // Valid initial state
        [InlineData((string)null)]
        // May contain any casing
        [InlineData("testperson@gmail.com")]
        [InlineData("TestPerson@gmail.com")]
        // May contain spaces
        [InlineData("\"Fred Bloggs\"@example.com")]
        [InlineData("\"Joe\\Blow\"@example.com")]
        // May contain special characters
        [InlineData("customer/department=shipping@example.com")]
        [InlineData("$A12345@example.com")]
        [InlineData("!def!xyz%abc@example.com")]
        [InlineData("__somename@example.com")]
        [InlineData("testperson+label@gmail.com")]
        [InlineData("first.last@test.co.uk")]
        public void ValidateCorrectlyFormattedEmail_Theory(string validEmail)
        {
            // Arrange
            var uut = new EmailValidator();

            // Act
            var isValid = uut.Validate(validEmail);

            // Assert
            Assert.True(isValid);
        }

        [Theory(DisplayName = "Can invalidate incorrectly formatted email.")]
        // Invalid cleared or empty state
        [InlineData("")]
        // Missing TLD
        [InlineData("testperso")]
        // Missing @
        [InlineData("thisisaverylongstringcodeplex.com")]
        // Improper @ index
        [InlineData("@someDomain.com")]
        [InlineData("someName@")]
        // Includes double @
        [InlineData("@someDomain@abc.com")]
        [InlineData("someName@a@b.com")]
        public void InvalidateIncorrectlyFormattedEmail(string invalidEmail)
        {
            // Arrange
            var uut = new EmailValidator();

            // Act
            var isValid = uut.Validate(invalidEmail);

            // Assert
            Assert.False(isValid);
        }


    }
}
