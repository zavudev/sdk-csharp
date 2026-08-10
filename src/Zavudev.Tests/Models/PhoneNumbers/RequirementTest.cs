using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class RequirementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Requirement
        {
            ID = "id",
            Action = "ordering",
            CountryCode = "DE",
            PhoneNumberType = "local",
            RequirementTypes =
            [
                new()
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
                },
            ],
        };

        string expectedID = "id";
        string expectedAction = "ordering";
        string expectedCountryCode = "DE";
        string expectedPhoneNumberType = "local";
        List<RequirementType> expectedRequirementTypes =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAction, model.Action);
        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedPhoneNumberType, model.PhoneNumberType);
        Assert.Equal(expectedRequirementTypes.Count, model.RequirementTypes.Count);
        for (int i = 0; i < expectedRequirementTypes.Count; i++)
        {
            Assert.Equal(expectedRequirementTypes[i], model.RequirementTypes[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Requirement
        {
            ID = "id",
            Action = "ordering",
            CountryCode = "DE",
            PhoneNumberType = "local",
            RequirementTypes =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Requirement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Requirement
        {
            ID = "id",
            Action = "ordering",
            CountryCode = "DE",
            PhoneNumberType = "local",
            RequirementTypes =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Requirement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAction = "ordering";
        string expectedCountryCode = "DE";
        string expectedPhoneNumberType = "local";
        List<RequirementType> expectedRequirementTypes =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedPhoneNumberType, deserialized.PhoneNumberType);
        Assert.Equal(expectedRequirementTypes.Count, deserialized.RequirementTypes.Count);
        for (int i = 0; i < expectedRequirementTypes.Count; i++)
        {
            Assert.Equal(expectedRequirementTypes[i], deserialized.RequirementTypes[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Requirement
        {
            ID = "id",
            Action = "ordering",
            CountryCode = "DE",
            PhoneNumberType = "local",
            RequirementTypes =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Requirement
        {
            ID = "id",
            Action = "ordering",
            CountryCode = "DE",
            PhoneNumberType = "local",
            RequirementTypes =
            [
                new()
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
                },
            ],
        };

        Requirement copied = new(model);

        Assert.Equal(model, copied);
    }
}
