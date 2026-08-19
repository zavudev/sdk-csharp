using System;
using Zavudev.Models.Functions.Triggers;

namespace Zavudev.Tests.Models.Functions.Triggers;

public class TriggerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TriggerUpdateParams { TriggerID = "triggerId", Active = true };

        string expectedTriggerID = "triggerId";
        bool expectedActive = true;

        Assert.Equal(expectedTriggerID, parameters.TriggerID);
        Assert.Equal(expectedActive, parameters.Active);
    }

    [Fact]
    public void Url_Works()
    {
        TriggerUpdateParams parameters = new() { TriggerID = "triggerId", Active = true };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/functions/triggers/triggerId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TriggerUpdateParams { TriggerID = "triggerId", Active = true };

        TriggerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
