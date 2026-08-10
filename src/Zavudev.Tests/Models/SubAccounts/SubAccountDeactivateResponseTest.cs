using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountDeactivateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubAccountDeactivateResponse
        {
            KeysRevoked = 0,
            Message = "Sub-account deactivated",
        };

        long expectedKeysRevoked = 0;
        string expectedMessage = "Sub-account deactivated";

        Assert.Equal(expectedKeysRevoked, model.KeysRevoked);
        Assert.Equal(expectedMessage, model.Message);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubAccountDeactivateResponse
        {
            KeysRevoked = 0,
            Message = "Sub-account deactivated",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccountDeactivateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubAccountDeactivateResponse
        {
            KeysRevoked = 0,
            Message = "Sub-account deactivated",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubAccountDeactivateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedKeysRevoked = 0;
        string expectedMessage = "Sub-account deactivated";

        Assert.Equal(expectedKeysRevoked, deserialized.KeysRevoked);
        Assert.Equal(expectedMessage, deserialized.Message);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubAccountDeactivateResponse
        {
            KeysRevoked = 0,
            Message = "Sub-account deactivated",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubAccountDeactivateResponse
        {
            KeysRevoked = 0,
            Message = "Sub-account deactivated",
        };

        SubAccountDeactivateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
