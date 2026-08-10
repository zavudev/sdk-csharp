using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class RequirementTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
            Example = "example",
        };

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedName = "name";
        ApiEnum<string, RequirementFieldType> expectedType = RequirementFieldType.Textual;
        RequirementAcceptanceCriteria expectedAcceptanceCriteria = new()
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };
        string expectedExample = "example";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAcceptanceCriteria, model.AcceptanceCriteria);
        Assert.Equal(expectedExample, model.Example);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
            Example = "example",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequirementType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
            Example = "example",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RequirementType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDescription = "description";
        string expectedName = "name";
        ApiEnum<string, RequirementFieldType> expectedType = RequirementFieldType.Textual;
        RequirementAcceptanceCriteria expectedAcceptanceCriteria = new()
        {
            AllowedValues = ["string"],
            MaxLength = 0,
            MinLength = 0,
            RegexPattern = "regexPattern",
        };
        string expectedExample = "example";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAcceptanceCriteria, deserialized.AcceptanceCriteria);
        Assert.Equal(expectedExample, deserialized.Example);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
            Example = "example",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            Example = "example",
        };

        Assert.Null(model.AcceptanceCriteria);
        Assert.False(model.RawData.ContainsKey("acceptanceCriteria"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            Example = "example",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            Example = "example",

            // Null should be interpreted as omitted for these properties
            AcceptanceCriteria = null,
        };

        Assert.Null(model.AcceptanceCriteria);
        Assert.False(model.RawData.ContainsKey("acceptanceCriteria"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            Example = "example",

            // Null should be interpreted as omitted for these properties
            AcceptanceCriteria = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
        };

        Assert.Null(model.Example);
        Assert.False(model.RawData.ContainsKey("example"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },

            Example = null,
        };

        Assert.Null(model.Example);
        Assert.True(model.RawData.ContainsKey("example"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },

            Example = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RequirementType
        {
            ID = "id",
            Description = "description",
            Name = "name",
            Type = RequirementFieldType.Textual,
            AcceptanceCriteria = new()
            {
                AllowedValues = ["string"],
                MaxLength = 0,
                MinLength = 0,
                RegexPattern = "regexPattern",
            },
            Example = "example",
        };

        RequirementType copied = new(model);

        Assert.Equal(model, copied);
    }
}
