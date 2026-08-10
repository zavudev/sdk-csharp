using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberRequirementsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberRequirementsResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        List<Requirement> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberRequirementsResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberRequirementsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberRequirementsResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberRequirementsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Requirement> expectedItems =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberRequirementsResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberRequirementsResponse
        {
            Items =
            [
                new()
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
                },
            ],
        };

        PhoneNumberRequirementsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
