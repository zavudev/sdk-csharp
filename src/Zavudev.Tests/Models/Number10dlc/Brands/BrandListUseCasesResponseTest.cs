using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Brands;

namespace Zavudev.Tests.Models.Number10dlc.Brands;

public class BrandListUseCasesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrandListUseCasesResponse
        {
            UseCases = [new() { Description = "description", Name = "name" }],
        };

        List<UseCase> expectedUseCases = [new() { Description = "description", Name = "name" }];

        Assert.Equal(expectedUseCases.Count, model.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], model.UseCases[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrandListUseCasesResponse
        {
            UseCases = [new() { Description = "description", Name = "name" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListUseCasesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrandListUseCasesResponse
        {
            UseCases = [new() { Description = "description", Name = "name" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrandListUseCasesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<UseCase> expectedUseCases = [new() { Description = "description", Name = "name" }];

        Assert.Equal(expectedUseCases.Count, deserialized.UseCases.Count);
        for (int i = 0; i < expectedUseCases.Count; i++)
        {
            Assert.Equal(expectedUseCases[i], deserialized.UseCases[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrandListUseCasesResponse
        {
            UseCases = [new() { Description = "description", Name = "name" }],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrandListUseCasesResponse
        {
            UseCases = [new() { Description = "description", Name = "name" }],
        };

        BrandListUseCasesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UseCaseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UseCase { Description = "description", Name = "name" };

        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UseCase { Description = "description", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UseCase { Description = "description", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UseCase>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "description";
        string expectedName = "name";

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UseCase { Description = "description", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UseCase { };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UseCase { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UseCase
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Name = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UseCase
        {
            // Null should be interpreted as omitted for these properties
            Description = null,
            Name = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UseCase { Description = "description", Name = "name" };

        UseCase copied = new(model);

        Assert.Equal(model, copied);
    }
}
