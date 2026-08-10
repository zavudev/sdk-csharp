using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Introspect;

namespace Zavudev.Tests.Models.Introspect;

public class IntrospectValidatePhoneResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
            AvailableChannels = ["string"],
            Carrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile },
            LineType = LineType.Mobile,
            NationalFormat = "(312) 945-7420",
        };

        string expectedCountryCode = "CL";
        string expectedPhoneNumber = "phoneNumber";
        bool expectedValidNumber = true;
        List<string> expectedAvailableChannels = ["string"];
        Carrier expectedCarrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile };
        ApiEnum<string, LineType> expectedLineType = LineType.Mobile;
        string expectedNationalFormat = "(312) 945-7420";

        Assert.Equal(expectedCountryCode, model.CountryCode);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedValidNumber, model.ValidNumber);
        Assert.NotNull(model.AvailableChannels);
        Assert.Equal(expectedAvailableChannels.Count, model.AvailableChannels.Count);
        for (int i = 0; i < expectedAvailableChannels.Count; i++)
        {
            Assert.Equal(expectedAvailableChannels[i], model.AvailableChannels[i]);
        }
        Assert.Equal(expectedCarrier, model.Carrier);
        Assert.Equal(expectedLineType, model.LineType);
        Assert.Equal(expectedNationalFormat, model.NationalFormat);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
            AvailableChannels = ["string"],
            Carrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile },
            LineType = LineType.Mobile,
            NationalFormat = "(312) 945-7420",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrospectValidatePhoneResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
            AvailableChannels = ["string"],
            Carrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile },
            LineType = LineType.Mobile,
            NationalFormat = "(312) 945-7420",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntrospectValidatePhoneResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCountryCode = "CL";
        string expectedPhoneNumber = "phoneNumber";
        bool expectedValidNumber = true;
        List<string> expectedAvailableChannels = ["string"];
        Carrier expectedCarrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile };
        ApiEnum<string, LineType> expectedLineType = LineType.Mobile;
        string expectedNationalFormat = "(312) 945-7420";

        Assert.Equal(expectedCountryCode, deserialized.CountryCode);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedValidNumber, deserialized.ValidNumber);
        Assert.NotNull(deserialized.AvailableChannels);
        Assert.Equal(expectedAvailableChannels.Count, deserialized.AvailableChannels.Count);
        for (int i = 0; i < expectedAvailableChannels.Count; i++)
        {
            Assert.Equal(expectedAvailableChannels[i], deserialized.AvailableChannels[i]);
        }
        Assert.Equal(expectedCarrier, deserialized.Carrier);
        Assert.Equal(expectedLineType, deserialized.LineType);
        Assert.Equal(expectedNationalFormat, deserialized.NationalFormat);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
            AvailableChannels = ["string"],
            Carrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile },
            LineType = LineType.Mobile,
            NationalFormat = "(312) 945-7420",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
        };

        Assert.Null(model.AvailableChannels);
        Assert.False(model.RawData.ContainsKey("availableChannels"));
        Assert.Null(model.Carrier);
        Assert.False(model.RawData.ContainsKey("carrier"));
        Assert.Null(model.LineType);
        Assert.False(model.RawData.ContainsKey("lineType"));
        Assert.Null(model.NationalFormat);
        Assert.False(model.RawData.ContainsKey("nationalFormat"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,

            // Null should be interpreted as omitted for these properties
            AvailableChannels = null,
            Carrier = null,
            LineType = null,
            NationalFormat = null,
        };

        Assert.Null(model.AvailableChannels);
        Assert.False(model.RawData.ContainsKey("availableChannels"));
        Assert.Null(model.Carrier);
        Assert.False(model.RawData.ContainsKey("carrier"));
        Assert.Null(model.LineType);
        Assert.False(model.RawData.ContainsKey("lineType"));
        Assert.Null(model.NationalFormat);
        Assert.False(model.RawData.ContainsKey("nationalFormat"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,

            // Null should be interpreted as omitted for these properties
            AvailableChannels = null,
            Carrier = null,
            LineType = null,
            NationalFormat = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntrospectValidatePhoneResponse
        {
            CountryCode = "CL",
            PhoneNumber = "phoneNumber",
            ValidNumber = true,
            AvailableChannels = ["string"],
            Carrier = new() { Name = "Verizon Wireless", Type = LineType.Mobile },
            LineType = LineType.Mobile,
            NationalFormat = "(312) 945-7420",
        };

        IntrospectValidatePhoneResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CarrierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless", Type = LineType.Mobile };

        string expectedName = "Verizon Wireless";
        ApiEnum<string, LineType> expectedType = LineType.Mobile;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless", Type = LineType.Mobile };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Carrier>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless", Type = LineType.Mobile };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Carrier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "Verizon Wireless";
        ApiEnum<string, LineType> expectedType = LineType.Mobile;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless", Type = LineType.Mobile };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless" };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Carrier
        {
            Name = "Verizon Wireless",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Carrier
        {
            Name = "Verizon Wireless",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Carrier { Type = LineType.Mobile };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Carrier { Type = LineType.Mobile };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Carrier
        {
            Type = LineType.Mobile,

            Name = null,
        };

        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Carrier
        {
            Type = LineType.Mobile,

            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Carrier { Name = "Verizon Wireless", Type = LineType.Mobile };

        Carrier copied = new(model);

        Assert.Equal(model, copied);
    }
}
