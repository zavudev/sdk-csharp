using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Models.Senders;

public class WebhookSecretResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebhookSecretResponse { Secret = "whsec_abc123..." };

        string expectedSecret = "whsec_abc123...";

        Assert.Equal(expectedSecret, model.Secret);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebhookSecretResponse { Secret = "whsec_abc123..." };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSecretResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebhookSecretResponse { Secret = "whsec_abc123..." };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebhookSecretResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedSecret = "whsec_abc123...";

        Assert.Equal(expectedSecret, deserialized.Secret);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebhookSecretResponse { Secret = "whsec_abc123..." };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebhookSecretResponse { Secret = "whsec_abc123..." };

        WebhookSecretResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
