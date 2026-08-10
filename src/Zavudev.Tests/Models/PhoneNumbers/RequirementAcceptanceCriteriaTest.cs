using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class RequirementAcceptanceCriteriaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };

        List<string> expectedAllowedValues = ["string"];
        long expectedMaxLength = 0;
        long expectedMinLength = 0;
        string expectedRegexPattern = "regexPattern";

        Assert.NotNull(model.AllowedValues);
        Assert.Equal(expectedAllowedValues.Count, model.AllowedValues.Count);
        for (int i = 0; i < expectedAllowedValues.Count; i++)
        {
            Assert.Equal(expectedAllowedValues[i], model.AllowedValues[i]);
        }
        Assert.Equal(expectedMaxLength, model.MaxLength);
        Assert.Equal(expectedMinLength, model.MinLength);
        Assert.Equal(expectedRegexPattern, model.RegexPattern);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequirementAcceptanceCriteria>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequirementAcceptanceCriteria>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedAllowedValues = ["string"];
        long expectedMaxLength = 0;
        long expectedMinLength = 0;
        string expectedRegexPattern = "regexPattern";

        Assert.NotNull(deserialized.AllowedValues);
        Assert.Equal(expectedAllowedValues.Count, deserialized.AllowedValues.Count);
        for (int i = 0; i < expectedAllowedValues.Count; i++)
        {
            Assert.Equal(expectedAllowedValues[i], deserialized.AllowedValues[i]);
        }
        Assert.Equal(expectedMaxLength, deserialized.MaxLength);
        Assert.Equal(expectedMinLength, deserialized.MinLength);
        Assert.Equal(expectedRegexPattern, deserialized.RegexPattern);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RequirementAcceptanceCriteria { };

        Assert.Null(model.AllowedValues);
        Assert.False(model.RawData.ContainsKey("allowedValues"));
        Assert.Null(model.MaxLength);
        Assert.False(model.RawData.ContainsKey("maxLength"));
        Assert.Null(model.MinLength);
        Assert.False(model.RawData.ContainsKey("minLength"));
        Assert.Null(model.RegexPattern);
        Assert.False(model.RawData.ContainsKey("regexPattern"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RequirementAcceptanceCriteria { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = null,
            MaxLength = null,
            MinLength = null,
            RegexPattern = null,
        };

        Assert.Null(model.AllowedValues);
        Assert.True(model.RawData.ContainsKey("allowedValues"));
        Assert.Null(model.MaxLength);
        Assert.True(model.RawData.ContainsKey("maxLength"));
        Assert.Null(model.MinLength);
        Assert.True(model.RawData.ContainsKey("minLength"));
        Assert.Null(model.RegexPattern);
        Assert.True(model.RawData.ContainsKey("regexPattern"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = null,
            MaxLength = null,
            MinLength = null,
            RegexPattern = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequirementAcceptanceCriteria
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };

        RequirementAcceptanceCriteria copied = new(model);

        Assert.Equal(model, copied);
    }
}
