using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Functions.GitLink;

namespace Zavudev.Tests.Models.Functions.GitLink;

public class GitLinkDeployNowResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GitLinkDeployNowResponse { Scheduled = true };

        bool expectedScheduled = true;

        Assert.Equal(expectedScheduled, model.Scheduled);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GitLinkDeployNowResponse { Scheduled = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitLinkDeployNowResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GitLinkDeployNowResponse { Scheduled = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GitLinkDeployNowResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedScheduled = true;

        Assert.Equal(expectedScheduled, deserialized.Scheduled);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GitLinkDeployNowResponse { Scheduled = true };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GitLinkDeployNowResponse { Scheduled = true };

        GitLinkDeployNowResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
