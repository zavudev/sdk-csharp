using System;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Tests.Models.Functions.Triggers;

public class TriggerDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TriggerDeleteParams { TriggerID = "triggerId" };

        string expectedTriggerID = "triggerId";

        Assert.Equal(expectedTriggerID, parameters.TriggerID);
    }

    [Fact]
    public void Url_Works()
    {
        TriggerDeleteParams parameters = new() { TriggerID = "triggerId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/functions/triggers/triggerId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TriggerDeleteParams { TriggerID = "triggerId" };

        TriggerDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
