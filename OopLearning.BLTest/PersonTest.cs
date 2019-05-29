using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using OopLearning.BL;

namespace OopLearning.BLTest
{
    public class PersonTest
    {
        [Theory]
        [InlineData("Kian Lindskou")]
        [InlineData("Anders And")]
        [InlineData("Mark Marksen")]
        [InlineData("Don Doner Kebab")]
        [InlineData("Ian Pian")]
        public void ValidateName_ValidValuesShouldReturnTrue(string validName)
        {
            //Act
            (bool isValid, string errMsg) = Person.ValidateName(validName);

            //Assert
            Assert.True(isValid, $"{validName} should be valid");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("A")]
        [InlineData("Kian")]
        public void ValidateName_InvalidValuesShouldReturnFalse(string invalidName)
        {
            //Act
            (bool isValid, string errMsg) = Person.ValidateName(invalidName);

            //Assert
            Assert.False(isValid, $"{invalidName} should be invalid");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("A")]
        [InlineData("Kian")]
        public void ArgumentExcept_InvalidNameShouldThrowException(string invalidName)
        {
            //Arrange
            Person person = new Person();

            //Act
            //Assert
            Assert.Throws<ArgumentException>(
                () => person.Name = invalidName
                );
        }

        [Theory]
        [InlineData("Kian Lindskou")]
        [InlineData("Anders And")]
        [InlineData("Mark Marksen")]
        [InlineData("Don Doner Kebab")]
        [InlineData("Ian Pian")]
        public void SetName_ValidValuesShouldNotBeChanged(string expectedName)
        {
            //Arrange
            Person person = new Person();
            person.Name = expectedName;

            //Act
            string actualName = person.Name;

            //Assert
            Assert.Equal(expectedName, actualName);
        }

        [Theory]
        [InlineData("1911980955")]
        [InlineData("0105011234")]
        [InlineData("1012951234")]
        [InlineData("2211111234")]
        [InlineData("3112901234")]
        public void GetBirthday_CprAlreadySetShouldReturnValidBirthday(string cpr)
        {
            //Arrange
            Person person = new Person();
            person.Cpr = cpr;
            string shortenedCpr = cpr.Remove(6);

            string dateFormattedCpr = shortenedCpr.Insert(2, "-");
            dateFormattedCpr = dateFormattedCpr.Insert(5, "-");

            DateTime.TryParse(dateFormattedCpr, out DateTime expectedBirthday);

            //Act
            DateTime actualBirthday = person.Birthday;

            //Assert
            Assert.Equal(expectedBirthday, actualBirthday);
        }

        [Fact]
        public void GetBirthday_CprNotSetShouldCastException()
        {
            //Arrange
            Person person = new Person();

            //Act
            //Assert
            Assert.Throws<InvalidOperationException>(
                () => person.Birthday
                );
        }

        [Theory]
        [InlineData("1911980955")]
        [InlineData("0105011234")]
        [InlineData("1012951234")]
        [InlineData("2211111234")]
        [InlineData("3112901234")]
        public void ValidateCpr_ValidValuesShouldReturnTrue(string validCpr)
        {
            //Act
            (bool isValid, string errMsg) = Person.ValidateCpr(validCpr);

            //Assert
            Assert.True(isValid, $"{validCpr} should be valid");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("111")]
        [InlineData("12345678901234567890")]
        [InlineData("1234567890")]
        public void ValidateCpr_InvalidValuesShouldReturnFalse(string invalidCpr)
        {
            //Act
            (bool isValid, string errMsg) = Person.ValidateCpr(invalidCpr);

            //Assert
            Assert.False(isValid, $"{invalidCpr} should be invalid");
        }

    }
}
