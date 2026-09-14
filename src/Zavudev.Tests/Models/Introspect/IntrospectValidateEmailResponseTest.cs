using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Introspect;

namespace Zavudev.Tests.Models.Introspect;

public class IntrospectValidateEmailResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrospectValidateEmailResponse
        {
            Results =
            [
                new()
                {
                    Domain = "domain",
                    Email = "email",
                    Normalized = "normalized",
                    Reasons = [Reason.InvalidSyntax],
                    Verdict = Verdict.Deliverable,
                },
            ],
            Summary = new()
            {
                Deliverable = 0,
                Risky = 0,
                Total = 0,
                Undeliverable = 0,
            },
        };

        List<Result> expectedResults =
        [
            new()
            {
                Domain = "domain",
                Email = "email",
                Normalized = "normalized",
                Reasons = [Reason.InvalidSyntax],
                Verdict = Verdict.Deliverable,
            },
        ];
        Summary expectedSummary = new()
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
        Assert.Equal(expectedSummary, model.Summary);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntrospectValidateEmailResponse
        {
            Results =
            [
                new()
                {
                    Domain = "domain",
                    Email = "email",
                    Normalized = "normalized",
                    Reasons = [Reason.InvalidSyntax],
                    Verdict = Verdict.Deliverable,
                },
            ],
            Summary = new()
            {
                Deliverable = 0,
                Risky = 0,
                Total = 0,
                Undeliverable = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrospectValidateEmailResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrospectValidateEmailResponse
        {
            Results =
            [
                new()
                {
                    Domain = "domain",
                    Email = "email",
                    Normalized = "normalized",
                    Reasons = [Reason.InvalidSyntax],
                    Verdict = Verdict.Deliverable,
                },
            ],
            Summary = new()
            {
                Deliverable = 0,
                Risky = 0,
                Total = 0,
                Undeliverable = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrospectValidateEmailResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Result> expectedResults =
        [
            new()
            {
                Domain = "domain",
                Email = "email",
                Normalized = "normalized",
                Reasons = [Reason.InvalidSyntax],
                Verdict = Verdict.Deliverable,
            },
        ];
        Summary expectedSummary = new()
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
        Assert.Equal(expectedSummary, deserialized.Summary);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntrospectValidateEmailResponse
        {
            Results =
            [
                new()
                {
                    Domain = "domain",
                    Email = "email",
                    Normalized = "normalized",
                    Reasons = [Reason.InvalidSyntax],
                    Verdict = Verdict.Deliverable,
                },
            ],
            Summary = new()
            {
                Deliverable = 0,
                Risky = 0,
                Total = 0,
                Undeliverable = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrospectValidateEmailResponse
        {
            Results =
            [
                new()
                {
                    Domain = "domain",
                    Email = "email",
                    Normalized = "normalized",
                    Reasons = [Reason.InvalidSyntax],
                    Verdict = Verdict.Deliverable,
                },
            ],
            Summary = new()
            {
                Deliverable = 0,
                Risky = 0,
                Total = 0,
                Undeliverable = 0,
            },
        };

        IntrospectValidateEmailResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            Domain = "domain",
            Email = "email",
            Normalized = "normalized",
            Reasons = [Reason.InvalidSyntax],
            Verdict = Verdict.Deliverable,
        };

        string expectedDomain = "domain";
        string expectedEmail = "email";
        string expectedNormalized = "normalized";
        List<ApiEnum<string, Reason>> expectedReasons = [Reason.InvalidSyntax];
        ApiEnum<string, Verdict> expectedVerdict = Verdict.Deliverable;

        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedNormalized, model.Normalized);
        Assert.Equal(expectedReasons.Count, model.Reasons.Count);
        for (int i = 0; i < expectedReasons.Count; i++)
        {
            Assert.Equal(expectedReasons[i], model.Reasons[i]);
        }
        Assert.Equal(expectedVerdict, model.Verdict);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            Domain = "domain",
            Email = "email",
            Normalized = "normalized",
            Reasons = [Reason.InvalidSyntax],
            Verdict = Verdict.Deliverable,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            Domain = "domain",
            Email = "email",
            Normalized = "normalized",
            Reasons = [Reason.InvalidSyntax],
            Verdict = Verdict.Deliverable,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDomain = "domain";
        string expectedEmail = "email";
        string expectedNormalized = "normalized";
        List<ApiEnum<string, Reason>> expectedReasons = [Reason.InvalidSyntax];
        ApiEnum<string, Verdict> expectedVerdict = Verdict.Deliverable;

        Assert.Equal(expectedDomain, deserialized.Domain);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedNormalized, deserialized.Normalized);
        Assert.Equal(expectedReasons.Count, deserialized.Reasons.Count);
        for (int i = 0; i < expectedReasons.Count; i++)
        {
            Assert.Equal(expectedReasons[i], deserialized.Reasons[i]);
        }
        Assert.Equal(expectedVerdict, deserialized.Verdict);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            Domain = "domain",
            Email = "email",
            Normalized = "normalized",
            Reasons = [Reason.InvalidSyntax],
            Verdict = Verdict.Deliverable,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            Domain = "domain",
            Email = "email",
            Normalized = "normalized",
            Reasons = [Reason.InvalidSyntax],
            Verdict = Verdict.Deliverable,
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.InvalidSyntax)]
    [InlineData(Reason.DomainNotFound)]
    [InlineData(Reason.DomainNoMx)]
    [InlineData(Reason.DisposableDomain)]
    [InlineData(Reason.RoleAddress)]
    [InlineData(Reason.SuppressedHardBounce)]
    [InlineData(Reason.SuppressedSoftBounce)]
    [InlineData(Reason.SuppressedComplaint)]
    [InlineData(Reason.SuppressedManual)]
    [InlineData(Reason.SuppressedUnsubscribe)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.InvalidSyntax)]
    [InlineData(Reason.DomainNotFound)]
    [InlineData(Reason.DomainNoMx)]
    [InlineData(Reason.DisposableDomain)]
    [InlineData(Reason.RoleAddress)]
    [InlineData(Reason.SuppressedHardBounce)]
    [InlineData(Reason.SuppressedSoftBounce)]
    [InlineData(Reason.SuppressedComplaint)]
    [InlineData(Reason.SuppressedManual)]
    [InlineData(Reason.SuppressedUnsubscribe)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class VerdictTest : TestBase
{
    [Theory]
    [InlineData(Verdict.Deliverable)]
    [InlineData(Verdict.Risky)]
    [InlineData(Verdict.Undeliverable)]
    public void Validation_Works(Verdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verdict> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Verdict.Deliverable)]
    [InlineData(Verdict.Risky)]
    [InlineData(Verdict.Undeliverable)]
    public void SerializationRoundtrip_Works(Verdict rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Verdict> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Verdict>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SummaryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Summary
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        long expectedDeliverable = 0;
        long expectedRisky = 0;
        long expectedTotal = 0;
        long expectedUndeliverable = 0;

        Assert.Equal(expectedDeliverable, model.Deliverable);
        Assert.Equal(expectedRisky, model.Risky);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedUndeliverable, model.Undeliverable);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Summary
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Summary
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Summary>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDeliverable = 0;
        long expectedRisky = 0;
        long expectedTotal = 0;
        long expectedUndeliverable = 0;

        Assert.Equal(expectedDeliverable, deserialized.Deliverable);
        Assert.Equal(expectedRisky, deserialized.Risky);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedUndeliverable, deserialized.Undeliverable);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Summary
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Summary
        {
            Deliverable = 0,
            Risky = 0,
            Total = 0,
            Undeliverable = 0,
        };

        Summary copied = new(model);

        Assert.Equal(model, copied);
    }
}
