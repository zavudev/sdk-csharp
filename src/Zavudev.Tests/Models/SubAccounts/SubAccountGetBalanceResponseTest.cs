using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountGetBalanceResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            IsSubAccount = true,
            TotalSpent = 0,
        };

        long expectedBalance = 0;
        string expectedCurrency = "usd";
        long expectedCreditLimit = 0;
        bool expectedIsSubAccount = true;
        long expectedTotalSpent = 0;

        Assert.Equal(expectedBalance, model.Balance);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCreditLimit, model.CreditLimit);
        Assert.Equal(expectedIsSubAccount, model.IsSubAccount);
        Assert.Equal(expectedTotalSpent, model.TotalSpent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            IsSubAccount = true,
            TotalSpent = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccountGetBalanceResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            IsSubAccount = true,
            TotalSpent = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccountGetBalanceResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedBalance = 0;
        string expectedCurrency = "usd";
        long expectedCreditLimit = 0;
        bool expectedIsSubAccount = true;
        long expectedTotalSpent = 0;

        Assert.Equal(expectedBalance, deserialized.Balance);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCreditLimit, deserialized.CreditLimit);
        Assert.Equal(expectedIsSubAccount, deserialized.IsSubAccount);
        Assert.Equal(expectedTotalSpent, deserialized.TotalSpent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            IsSubAccount = true,
            TotalSpent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            TotalSpent = 0,
        };

        Assert.Null(model.IsSubAccount);
        Assert.False(model.RawData.ContainsKey("isSubAccount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            TotalSpent = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            TotalSpent = 0,

            // Null should be interpreted as omitted for these properties
            IsSubAccount = null,
        };

        Assert.Null(model.IsSubAccount);
        Assert.False(model.RawData.ContainsKey("isSubAccount"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            TotalSpent = 0,

            // Null should be interpreted as omitted for these properties
            IsSubAccount = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            IsSubAccount = true,
        };

        Assert.Null(model.CreditLimit);
        Assert.False(model.RawData.ContainsKey("creditLimit"));
        Assert.Null(model.TotalSpent);
        Assert.False(model.RawData.ContainsKey("totalSpent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            IsSubAccount = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            IsSubAccount = true,

            CreditLimit = null,
            TotalSpent = null,
        };

        Assert.Null(model.CreditLimit);
        Assert.True(model.RawData.ContainsKey("creditLimit"));
        Assert.Null(model.TotalSpent);
        Assert.True(model.RawData.ContainsKey("totalSpent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            IsSubAccount = true,

            CreditLimit = null,
            TotalSpent = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubAccountGetBalanceResponse
        {
            Balance = 0,
            Currency = "usd",
            CreditLimit = 0,
            IsSubAccount = true,
            TotalSpent = 0,
        };

        SubAccountGetBalanceResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
