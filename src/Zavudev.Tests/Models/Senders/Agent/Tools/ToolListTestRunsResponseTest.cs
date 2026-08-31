using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Senders.Agent.Tools;

namespace Zavudev.Tests.Models.Senders.Agent.Tools;

public class ToolListTestRunsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolListTestRunsResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DurationMs = 0,
                    Success = true,
                    ToolID = "toolId",
                    Error = "error",
                    Params = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = "response",
                    StatusCode = 0,
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DurationMs = 0,
                Success = true,
                ToolID = "toolId",
                Error = "error",
                Params = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Response = "response",
                StatusCode = 0,
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
        var model = new ToolListTestRunsResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DurationMs = 0,
                    Success = true,
                    ToolID = "toolId",
                    Error = "error",
                    Params = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = "response",
                    StatusCode = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolListTestRunsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolListTestRunsResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DurationMs = 0,
                    Success = true,
                    ToolID = "toolId",
                    Error = "error",
                    Params = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = "response",
                    StatusCode = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolListTestRunsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DurationMs = 0,
                Success = true,
                ToolID = "toolId",
                Error = "error",
                Params = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Response = "response",
                StatusCode = 0,
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
        var model = new ToolListTestRunsResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DurationMs = 0,
                    Success = true,
                    ToolID = "toolId",
                    Error = "error",
                    Params = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = "response",
                    StatusCode = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolListTestRunsResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DurationMs = 0,
                    Success = true,
                    ToolID = "toolId",
                    Error = "error",
                    Params = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Response = "response",
                    StatusCode = 0,
                },
            ],
        };

        ToolListTestRunsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = "response",
            StatusCode = 0,
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDurationMs = 0;
        bool expectedSuccess = true;
        string expectedToolID = "toolId";
        string expectedError = "error";
        Dictionary<string, JsonElement> expectedParams = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedResponse = "response";
        long expectedStatusCode = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDurationMs, model.DurationMs);
        Assert.Equal(expectedSuccess, model.Success);
        Assert.Equal(expectedToolID, model.ToolID);
        Assert.Equal(expectedError, model.Error);
        Assert.NotNull(model.Params);
        Assert.Equal(expectedParams.Count, model.Params.Count);
        foreach (var item in expectedParams)
        {
            Assert.True(model.Params.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Params[item.Key]));
        }
        Assert.Equal(expectedResponse, model.Response);
        Assert.Equal(expectedStatusCode, model.StatusCode);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = "response",
            StatusCode = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = "response",
            StatusCode = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedDurationMs = 0;
        bool expectedSuccess = true;
        string expectedToolID = "toolId";
        string expectedError = "error";
        Dictionary<string, JsonElement> expectedParams = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedResponse = "response";
        long expectedStatusCode = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDurationMs, deserialized.DurationMs);
        Assert.Equal(expectedSuccess, deserialized.Success);
        Assert.Equal(expectedToolID, deserialized.ToolID);
        Assert.Equal(expectedError, deserialized.Error);
        Assert.NotNull(deserialized.Params);
        Assert.Equal(expectedParams.Count, deserialized.Params.Count);
        foreach (var item in expectedParams)
        {
            Assert.True(deserialized.Params.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Params[item.Key]));
        }
        Assert.Equal(expectedResponse, deserialized.Response);
        Assert.Equal(expectedStatusCode, deserialized.StatusCode);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = "response",
            StatusCode = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Response = "response",
            StatusCode = 0,
        };

        Assert.Null(model.Params);
        Assert.False(model.RawData.ContainsKey("params"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Response = "response",
            StatusCode = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Response = "response",
            StatusCode = 0,

            // Null should be interpreted as omitted for these properties
            Params = null,
        };

        Assert.Null(model.Params);
        Assert.False(model.RawData.ContainsKey("params"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Response = "response",
            StatusCode = 0,

            // Null should be interpreted as omitted for these properties
            Params = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        Assert.Null(model.Error);
        Assert.False(model.RawData.ContainsKey("error"));
        Assert.Null(model.Response);
        Assert.False(model.RawData.ContainsKey("response"));
        Assert.Null(model.StatusCode);
        Assert.False(model.RawData.ContainsKey("statusCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Error = null,
            Response = null,
            StatusCode = null,
        };

        Assert.Null(model.Error);
        Assert.True(model.RawData.ContainsKey("error"));
        Assert.Null(model.Response);
        Assert.True(model.RawData.ContainsKey("response"));
        Assert.Null(model.StatusCode);
        Assert.True(model.RawData.ContainsKey("statusCode"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },

            Error = null,
            Response = null,
            StatusCode = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DurationMs = 0,
            Success = true,
            ToolID = "toolId",
            Error = "error",
            Params = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Response = "response",
            StatusCode = 0,
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}
