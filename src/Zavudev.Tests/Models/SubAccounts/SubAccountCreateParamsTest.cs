using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Models.SubAccounts;

namespace Zavudev.Tests.Models.SubAccounts;

public class SubAccountCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubAccountCreateParams
        {
            Name = "Client ABC",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedName = "Client ABC";
        long expectedCreditLimit = 0;
        string expectedExternalID = "externalId";
        Dictionary<string, JsonElement> expectedMetadata = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedCreditLimit, parameters.CreditLimit);
        Assert.Equal(expectedExternalID, parameters.ExternalID);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Metadata[item.Key]));
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubAccountCreateParams { Name = "Client ABC" };

        Assert.Null(parameters.CreditLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("creditLimit"));
        Assert.Null(parameters.ExternalID);
        Assert.False(parameters.RawBodyData.ContainsKey("externalId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubAccountCreateParams
        {
            Name = "Client ABC",

            // Null should be interpreted as omitted for these properties
            CreditLimit = null,
            ExternalID = null,
            Metadata = null,
        };

        Assert.Null(parameters.CreditLimit);
        Assert.False(parameters.RawBodyData.ContainsKey("creditLimit"));
        Assert.Null(parameters.ExternalID);
        Assert.False(parameters.RawBodyData.ContainsKey("externalId"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        SubAccountCreateParams parameters = new() { Name = "Client ABC" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/sub-accounts"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubAccountCreateParams
        {
            Name = "Client ABC",
            CreditLimit = 0,
            ExternalID = "externalId",
            Metadata = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        SubAccountCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
