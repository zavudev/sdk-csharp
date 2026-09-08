using System;
using System.Collections.Generic;
using Zavudev.Models.Introspect;

namespace Zavudev.Tests.Models.Introspect;

public class IntrospectValidateEmailParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntrospectValidateEmailParams
        {
            Email = "maria@example.com",
            Emails = ["maria@example.com", "info@deaddomain.example"],
        };

        string expectedEmail = "maria@example.com";
        List<string> expectedEmails = ["maria@example.com", "info@deaddomain.example"];

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.NotNull(parameters.Emails);
        Assert.Equal(expectedEmails.Count, parameters.Emails.Count);
        for (int i = 0; i < expectedEmails.Count; i++)
        {
            Assert.Equal(expectedEmails[i], parameters.Emails[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntrospectValidateEmailParams { };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Emails);
        Assert.False(parameters.RawBodyData.ContainsKey("emails"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntrospectValidateEmailParams
        {
            // Null should be interpreted as omitted for these properties
            Email = null,
            Emails = null,
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Emails);
        Assert.False(parameters.RawBodyData.ContainsKey("emails"));
    }

    [Fact]
    public void Url_Works()
    {
        IntrospectValidateEmailParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/introspect/email"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntrospectValidateEmailParams
        {
            Email = "maria@example.com",
            Emails = ["maria@example.com", "info@deaddomain.example"],
        };

        IntrospectValidateEmailParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
