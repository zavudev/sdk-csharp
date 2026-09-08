using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;
using Zavudev.Exceptions;

namespace Zavudev.Models.AgentTemplates;

[JsonConverter(
    typeof(JsonModelConverter<AgentTemplateRetrieveResponse, AgentTemplateRetrieveResponseFromRaw>)
)]
public sealed record class AgentTemplateRetrieveResponse : JsonModel
{
    /// <summary>
    /// A fully rendered factory agent: the function files to scaffold plus the secrets
    /// it needs. Returned by GET /v1/agent-templates/{templateId} and consumed by
    /// `npx zavudev agents pull`.
    /// </summary>
    public required Template Template
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Template>("template");
        }
        init { this._rawData.Set("template", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Template.Validate();
    }

    public AgentTemplateRetrieveResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public AgentTemplateRetrieveResponse(
        AgentTemplateRetrieveResponse agentTemplateRetrieveResponse
    )
        : base(agentTemplateRetrieveResponse) { }
#pragma warning restore CS8618

    public AgentTemplateRetrieveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AgentTemplateRetrieveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="AgentTemplateRetrieveResponseFromRaw.FromRawUnchecked"/>
    public static AgentTemplateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public AgentTemplateRetrieveResponse(Template template)
        : this()
    {
        this.Template = template;
    }
}

class AgentTemplateRetrieveResponseFromRaw : IFromRawJson<AgentTemplateRetrieveResponse>
{
    /// <inheritdoc/>
    public AgentTemplateRetrieveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => AgentTemplateRetrieveResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// A fully rendered factory agent: the function files to scaffold plus the secrets
/// it needs. Returned by GET /v1/agent-templates/{templateId} and consumed by `npx
/// zavudev agents pull`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Template, TemplateFromRaw>))]
public sealed record class Template : JsonModel
{
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

    public required ApiEnum<string, Category> Category
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Category>>("category");
        }
        init { this._rawData.Set("category", value); }
    }

    public required string DefaultSlug
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("defaultSlug");
        }
        init { this._rawData.Set("defaultSlug", value); }
    }

    /// <summary>
    /// npm dependencies for the scaffolded function.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Dependencies
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("dependencies");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "dependencies",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    public required IReadOnlyList<File> Files
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<File>>("files");
        }
        init
        {
            this._rawData.Set<ImmutableArray<File>>(
                "files",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    public required IReadOnlyList<RequiredSecret> RequiredSecrets
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<RequiredSecret>>(
                "requiredSecrets"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<RequiredSecret>>(
                "requiredSecrets",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public required string Summary
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("summary");
        }
        init { this._rawData.Set("summary", value); }
    }

    public required bool Voice
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("voice");
        }
        init { this._rawData.Set("voice", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        this.Category.Validate();
        _ = this.DefaultSlug;
        _ = this.Dependencies;
        foreach (var item in this.Files)
        {
            item.Validate();
        }
        _ = this.Name;
        foreach (var item in this.RequiredSecrets)
        {
            item.Validate();
        }
        _ = this.Summary;
        _ = this.Voice;
    }

    public Template() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Template(Template template)
        : base(template) { }
#pragma warning restore CS8618

    public Template(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Template(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateFromRaw.FromRawUnchecked"/>
    public static Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateFromRaw : IFromRawJson<Template>
{
    /// <inheritdoc/>
    public Template FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Template.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(CategoryConverter))]
public enum Category
{
    Sales,
    Support,
    FrontDesk,
    Ops,
}

sealed class CategoryConverter : JsonConverter<Category>
{
    public override Category Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sales" => Category.Sales,
            "support" => Category.Support,
            "frontDesk" => Category.FrontDesk,
            "ops" => Category.Ops,
            _ => (Category)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Category value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Category.Sales => "sales",
                Category.Support => "support",
                Category.FrontDesk => "frontDesk",
                Category.Ops => "ops",
                _ => throw new ZavudevInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

[JsonConverter(typeof(JsonModelConverter<File, FileFromRaw>))]
public sealed record class File : JsonModel
{
    /// <summary>
    /// File contents to write verbatim.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
    }

    public required string Path
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("path");
        }
        init { this._rawData.Set("path", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Content;
        _ = this.Path;
    }

    public File() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public File(File file)
        : base(file) { }
#pragma warning restore CS8618

    public File(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    File(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileFromRaw.FromRawUnchecked"/>
    public static File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileFromRaw : IFromRawJson<File>
{
    /// <inheritdoc/>
    public File FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        File.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(JsonModelConverter<RequiredSecret, RequiredSecretFromRaw>))]
public sealed record class RequiredSecret : JsonModel
{
    public required string Hint
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("hint");
        }
        init { this._rawData.Set("hint", value); }
    }

    public required string Key
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("key");
        }
        init { this._rawData.Set("key", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Hint;
        _ = this.Key;
    }

    public RequiredSecret() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public RequiredSecret(RequiredSecret requiredSecret)
        : base(requiredSecret) { }
#pragma warning restore CS8618

    public RequiredSecret(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    RequiredSecret(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RequiredSecretFromRaw.FromRawUnchecked"/>
    public static RequiredSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RequiredSecretFromRaw : IFromRawJson<RequiredSecret>
{
    /// <inheritdoc/>
    public RequiredSecret FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        RequiredSecret.FromRawUnchecked(rawData);
}
