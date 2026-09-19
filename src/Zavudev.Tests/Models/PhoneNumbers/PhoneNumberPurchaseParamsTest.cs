using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.PhoneNumbers;

namespace Zavudev.Tests.Models.PhoneNumbers;

public class PhoneNumberPurchaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PhoneNumberPurchaseParams
        {
            PhoneNumber = "+15551234567",
            Name = "Primary Line",
            RegulatoryRequirements =
            [
                new()
                {
                    FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
                    RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
                },
            ],
            Type = PhoneNumberType.Local,
        };

        string expectedPhoneNumber = "+15551234567";
        string expectedName = "Primary Line";
        List<RegulatoryRequirement> expectedRegulatoryRequirements =
        [
            new()
            {
                FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
                RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
            },
        ];
        ApiEnum<string, PhoneNumberType> expectedType = PhoneNumberType.Local;

        Assert.Equal(expectedPhoneNumber, parameters.PhoneNumber);
        Assert.Equal(expectedName, parameters.Name);
        Assert.NotNull(parameters.RegulatoryRequirements);
        Assert.Equal(expectedRegulatoryRequirements.Count, parameters.RegulatoryRequirements.Count);
        for (int i = 0; i < expectedRegulatoryRequirements.Count; i++)
        {
            Assert.Equal(expectedRegulatoryRequirements[i], parameters.RegulatoryRequirements[i]);
        }
        Assert.Equal(expectedType, parameters.Type);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PhoneNumberPurchaseParams { PhoneNumber = "+15551234567" };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.RegulatoryRequirements);
        Assert.False(parameters.RawBodyData.ContainsKey("regulatoryRequirements"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PhoneNumberPurchaseParams
        {
            PhoneNumber = "+15551234567",

            // Null should be interpreted as omitted for these properties
            Name = null,
            RegulatoryRequirements = null,
            Type = null,
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.RegulatoryRequirements);
        Assert.False(parameters.RawBodyData.ContainsKey("regulatoryRequirements"));
        Assert.Null(parameters.Type);
        Assert.False(parameters.RawBodyData.ContainsKey("type"));
    }

    [Fact]
    public void Url_Works()
    {
        PhoneNumberPurchaseParams parameters = new() { PhoneNumber = "+15551234567" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/phone-numbers"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PhoneNumberPurchaseParams
        {
            PhoneNumber = "+15551234567",
            Name = "Primary Line",
            RegulatoryRequirements =
            [
                new()
                {
                    FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
                    RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
                },
            ],
            Type = PhoneNumberType.Local,
        };

        PhoneNumberPurchaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class RegulatoryRequirementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RegulatoryRequirement
        {
            FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
            RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
        };

        string expectedFieldValue = "jd7x2k3m4n5p6q7r8s9t0abc";
        string expectedRequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10";

        Assert.Equal(expectedFieldValue, model.FieldValue);
        Assert.Equal(expectedRequirementType, model.RequirementType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RegulatoryRequirement
        {
            FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
            RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryRequirement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RegulatoryRequirement
        {
            FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
            RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RegulatoryRequirement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFieldValue = "jd7x2k3m4n5p6q7r8s9t0abc";
        string expectedRequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10";

        Assert.Equal(expectedFieldValue, deserialized.FieldValue);
        Assert.Equal(expectedRequirementType, deserialized.RequirementType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RegulatoryRequirement
        {
            FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
            RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RegulatoryRequirement
        {
            FieldValue = "jd7x2k3m4n5p6q7r8s9t0abc",
            RequirementType = "8c5b1a2e-0f3d-4f5b-9a61-2c7e4d9b1f10",
        };

        RegulatoryRequirement copied = new(model);

        Assert.Equal(model, copied);
    }
}
