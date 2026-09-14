using System;
using Zavudev.Models.Agents;

namespace Zavudev.Tests.Models.Agents;

public class AgentListVoicesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AgentListVoicesParams { Language = "es" };

        string expectedLanguage = "es";

        Assert.Equal(expectedLanguage, parameters.Language);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AgentListVoicesParams { };

        Assert.Null(parameters.Language);
        Assert.False(parameters.RawQueryData.ContainsKey("language"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AgentListVoicesParams
        {
            // Null should be interpreted as omitted for these properties
            Language = null,
        };

        Assert.Null(parameters.Language);
        Assert.False(parameters.RawQueryData.ContainsKey("language"));
    }

    [Fact]
    public void Url_Works()
    {
        AgentListVoicesParams parameters = new() { Language = "es" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/agents/voices?language=es"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AgentListVoicesParams { Language = "es" };

        AgentListVoicesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
