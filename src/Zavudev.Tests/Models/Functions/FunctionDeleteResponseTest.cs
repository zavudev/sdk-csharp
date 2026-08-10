using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Functions;

namespace Zavudev.Tests.Models.Functions;

public class FunctionDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,
            Name = "name",
            Slug = "slug",
        };

        bool expectedDeleted = true;
        string expectedName = "name";
        string expectedSlug = "slug";

        Assert.Equal(expectedDeleted, model.Deleted);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedSlug, model.Slug);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,
            Name = "name",
            Slug = "slug",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,
            Name = "name",
            Slug = "slug",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FunctionDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedDeleted = true;
        string expectedName = "name";
        string expectedSlug = "slug";

        Assert.Equal(expectedDeleted, deserialized.Deleted);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedSlug, deserialized.Slug);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,
            Name = "name",
            Slug = "slug",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new FunctionDeleteResponse { Deleted = true };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new FunctionDeleteResponse { Deleted = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,

            // Null should be interpreted as omitted for these properties
            Name = null,
            Slug = null,
        };

        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Slug);
        Assert.False(model.RawData.ContainsKey("slug"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,

            // Null should be interpreted as omitted for these properties
            Name = null,
            Slug = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FunctionDeleteResponse
        {
            Deleted = true,
            Name = "name",
            Slug = "slug",
        };

        FunctionDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
