using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Me;

namespace Zavudev.Tests.Models.Me;

public class MeRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MeRetrieveResponse
        {
            ApiKey = new("id"),
            IsTestMode = true,
            Project = new()
            {
                ID = "id",
                IsSubAccount = true,
                Name = "name",
            },
            Team = new() { ID = "id", Name = "name" },
        };

        ApiKey expectedApiKey = new("id");
        bool expectedIsTestMode = true;
        Project expectedProject = new()
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };
        Team expectedTeam = new() { ID = "id", Name = "name" };

        Assert.Equal(expectedApiKey, model.ApiKey);
        Assert.Equal(expectedIsTestMode, model.IsTestMode);
        Assert.Equal(expectedProject, model.Project);
        Assert.Equal(expectedTeam, model.Team);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MeRetrieveResponse
        {
            ApiKey = new("id"),
            IsTestMode = true,
            Project = new()
            {
                ID = "id",
                IsSubAccount = true,
                Name = "name",
            },
            Team = new() { ID = "id", Name = "name" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MeRetrieveResponse
        {
            ApiKey = new("id"),
            IsTestMode = true,
            Project = new()
            {
                ID = "id",
                IsSubAccount = true,
                Name = "name",
            },
            Team = new() { ID = "id", Name = "name" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MeRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiKey expectedApiKey = new("id");
        bool expectedIsTestMode = true;
        Project expectedProject = new()
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };
        Team expectedTeam = new() { ID = "id", Name = "name" };

        Assert.Equal(expectedApiKey, deserialized.ApiKey);
        Assert.Equal(expectedIsTestMode, deserialized.IsTestMode);
        Assert.Equal(expectedProject, deserialized.Project);
        Assert.Equal(expectedTeam, deserialized.Team);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MeRetrieveResponse
        {
            ApiKey = new("id"),
            IsTestMode = true,
            Project = new()
            {
                ID = "id",
                IsSubAccount = true,
                Name = "name",
            },
            Team = new() { ID = "id", Name = "name" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MeRetrieveResponse
        {
            ApiKey = new("id"),
            IsTestMode = true,
            Project = new()
            {
                ID = "id",
                IsSubAccount = true,
                Name = "name",
            },
            Team = new() { ID = "id", Name = "name" },
        };

        MeRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ApiKeyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ApiKey { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ApiKey { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ApiKey { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiKey>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ApiKey { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ApiKey { ID = "id" };

        ApiKey copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProjectTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };

        string expectedID = "id";
        bool expectedIsSubAccount = true;
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedIsSubAccount, model.IsSubAccount);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Project
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Project
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Project>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        bool expectedIsSubAccount = true;
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedIsSubAccount, deserialized.IsSubAccount);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Project
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Project
        {
            ID = "id",
            IsSubAccount = true,
            Name = "name",
        };

        Project copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TeamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Team { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Team { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Team>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Team { ID = "id", Name = "name" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Team>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Team { ID = "id", Name = "name" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Team { ID = "id", Name = "name" };

        Team copied = new(model);

        Assert.Equal(model, copied);
    }
}
