using FirstResponsiveWebAppJohnson.Models;
using Xunit;

namespace FirstResponsiveWebAppJohnson.Test
{
    public class AgeCalculatorTests
    {
        [Fact]
        public void AgeThisYear_ReturnsCorrectAge()
        {
            // Arrange
            var user = new UserModel { BirthYear = 2000 };

            // Act
            var result = user.AgeThisYear();

            // Assert
            Assert.Equal(DateTime.Now.Year - 2000, result);
        }

        [Fact]
        public void AgeToday_ReturnsCorrectAge_WhenBirthdayHasNotOccurredYet()
        {
            // Arrange: set a birthday later in the year
            var birthday = new DateTime(DateTime.Now.Year, 12, 31);
            var user = new UserModel { Birthday = birthday, BirthYear = birthday.Year };

            // Act
            var result = user.AgeToday();

            // Assert: should be one less than AgeThisYear
            Assert.Equal(user.AgeThisYear() - 1, result);
        }

        [Fact]
        public void AgeToday_ReturnsCorrectAge_WhenBirthdayHasAlreadyOccurred()
        {
            // Arrange: set a birthday earlier in the year
            var birthday = new DateTime(DateTime.Now.Year, 1, 1);
            var user = new UserModel { Birthday = birthday, BirthYear = birthday.Year };

            // Act
            var result = user.AgeToday();

            // Assert: should match AgeThisYear
            Assert.Equal(user.AgeThisYear(), result);
        }

        [Fact]
        public void AgeToday_ReturnsNull_WhenBirthdayNotProvided()
        {
            // Arrange
            var user = new UserModel { BirthYear = 2000, Birthday = null };

            // Act
            var result = user.AgeToday();

            // Assert
            Assert.Null(result);
        }
    }
}
