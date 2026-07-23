using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hello";
        string expected = "olleH";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act & Assert - NEW SYTNAX
        Assert.That(() => _exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);

        // Act & Assert - OLD SYTNAX + Message
        var ex = Assert.Throws<ArgumentNullException>(() => _exceptions.ArgumentNullReverse(input));
        Assert.That(ex.Message, Does.StartWith("String cannot be null."));
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        //Arrange
        decimal price = 200m;
        decimal discount = 10m;
        decimal expected = 180m;

        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(price, discount);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = -10.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    // TODO: finish test
    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal totalPrice = 100.0m;
        decimal discount = 110.0m;

        // Act & Assert
        Assert.That(() => this._exceptions.ArgumentCalculateDiscount(totalPrice, discount), Throws.ArgumentException);
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        //Arrange
        int[] input = { 10, 20, 30, 40 };
        int index = 2;
        int expected = 30;

        // Act
        int result = _exceptions.IndexOutOfRangeGetElement(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40 };
        int index = -2;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    // TODO: finish test
    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = input.Length;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] input = { 10, 20, 30, 40, 50 };
        int index = 7;

        // Act & Assert
        Assert.That(() => this._exceptions.IndexOutOfRangeGetElement(input, index), Throws.InstanceOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arange
        bool input = true;
        string expected = "User logged in.";

        // Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);
        
        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool input = false;

        // Act & Assert
        Assert.That(() => _exceptions.InvalidOperationPerformSecureOperation(input), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arange
        string input = "42";
        int expected = 42;

        // Act
        int result = _exceptions.FormatExceptionParseInt(input);

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException()
    {
        // Arange
        string input = "five";
        string expectedMessage = "Input is not in the correct format for an integer.";

        // Act & Assert + Message
        var ex = Assert.Throws<FormatException>(() => _exceptions.FormatExceptionParseInt(input));
        Assert.That(ex.Message, Is.EqualTo(expectedMessage));
    }

    [TestCase("two", 2)]
    [TestCase("five", 5)]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue(string key, int expected)
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1, 
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5
        };

        // Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>()
        {
            ["one"] = 1,
            ["two"] = 2,
            ["three"] = 3,
            ["four"] = 4,
            ["five"] = 5
        };

        string key = "six";

        // Act & Assert
        Assert.That(() => _exceptions.KeyNotFoundFindValueByKey(input, key), 
            Throws.TypeOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int num1 = 10;
        int num2 = 20;
        int expected = 30;

        // Act
        int result = _exceptions.OverflowAddNumbers(num1, num2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int num1 = int.MaxValue;
        int num2 = 1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(num1, num2), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int num1 = int.MinValue;
        int num2 = -1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(num1, num2), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int a = 13;
        int divisor = 4;

        int expected = 3;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(a, divisor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int a = 13;
        int divisor = 0;

        // Act & Assert
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(a, divisor), Throws.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4 };
        int index = 2;
        int expected = 10;

        // Act
        int result = _exceptions.SumCollectionElements(numbers, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] numbers = null;
        int index = 2;

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(numbers, index), Throws.ArgumentNullException);
    }

    [TestCase(-1)]
    [TestCase(4)]
    [TestCase(10)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        int[] numbers = { 1, 2, 3, 4 };

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(numbers, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3",
            ["four"] = "4"
        };

        string key = "two";
        int expected = 2;

        // Act
        int result = _exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3",
            ["four"] = "4"
        };

        string key = "five";

        // Acy & Assert
        Assert.That(() => _exceptions.GetElementAsNumber(input, key), Throws.TypeOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>()
        {
            ["one"] = "1a",
            ["two"] = "2.2",
            ["three"] = "tri",
            ["four"] = "four"
        };

        string key = "one";

        // Acy & Assert
        Assert.That(() => _exceptions.GetElementAsNumber(input, key), Throws.TypeOf<FormatException>());

        // Message
        try
        {
            _exceptions.GetElementAsNumber(input, key);
        }
        catch (FormatException ex)
        {
            Assert.That(ex.Message, Is.EqualTo("Can't parse string."));
        }
    }
}

