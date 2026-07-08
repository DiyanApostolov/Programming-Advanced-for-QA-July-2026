using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    // TODO: finish the test
    [TestCase("dido.apostolov@mail.bg")]
    [TestCase("Pesho83-sofia@gmail.com")]
    [TestCase("gosho+vanq_sf@abv.bg")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    // TODO: finish the test
    [TestCase("dido.apostolov@mail.b")]
    [TestCase("Pesho83#sofia@gmail.com")]
    [TestCase("gosho+vanq_sf@@abv.bg")]
    [TestCase("gosho_abv.bg")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
