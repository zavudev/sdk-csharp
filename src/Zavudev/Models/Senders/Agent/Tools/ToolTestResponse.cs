using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Senders.Agent.Tools;

[JsonConverter(typeof(JsonModelConverter<ToolTestResponse, ToolTestResponseFromRaw>))]
public sealed record class ToolTestResponse : JsonModel
{
    /// <summary>
    /// One run of a tool triggered from the test endpoint. Recorded so a test is
    /// verifiable after the fact rather than only visible in the response.
    /// </summary>
    public required Run Run
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<Run>("run");
        }
        init { this._rawData.Set("run", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Run.Validate();
    }

    public ToolTestResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ToolTestResponse(ToolTestResponse toolTestResponse)
        : base(toolTestResponse) { }
#pragma warning restore CS8618

    public ToolTestResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolTestResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolTestResponseFromRaw.FromRawUnchecked"/>
    public static ToolTestResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ToolTestResponse(Run run)
        : this()
    {
        this.Run = run;
    }
}

class ToolTestResponseFromRaw : IFromRawJson<ToolTestResponse>
{
    /// <inheritdoc/>
    public ToolTestResponse FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolTestResponse.FromRawUnchecked(rawData);
}

/// <summary>
/// One run of a tool triggered from the test endpoint. Recorded so a test is verifiable
/// after the fact rather than only visible in the response.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<Run, RunFromRaw>))]
public sealed record class Run : JsonModel
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

    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("createdAt");
        }
        init { this._rawData.Set("createdAt", value); }
    }

    public required long DurationMs
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("durationMs");
        }
        init { this._rawData.Set("durationMs", value); }
    }

    /// <summary>
    /// Whether the tool returned without error. A tool that answered with a non-2xx
    /// status is a failed run, not an error of this endpoint.
    /// </summary>
    public required bool Success
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("success");
        }
        init { this._rawData.Set("success", value); }
    }

    public required string ToolID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("toolId");
        }
        init { this._rawData.Set("toolId", value); }
    }

    /// <summary>
    /// Why the run failed, when it did.
    /// </summary>
    public string? Error
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("error");
        }
        init { this._rawData.Set("error", value); }
    }

    /// <summary>
    /// The parameters the tool was called with.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Params
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("params");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "params",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// The tool's response body, truncated.
    /// </summary>
    public string? Response
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("response");
        }
        init { this._rawData.Set("response", value); }
    }

    /// <summary>
    /// HTTP status the tool's webhook returned. Absent for tools that do not go over HTTP.
    /// </summary>
    public long? StatusCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<long>("statusCode");
        }
        init { this._rawData.Set("statusCode", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ID;
        _ = this.CreatedAt;
        _ = this.DurationMs;
        _ = this.Success;
        _ = this.ToolID;
        _ = this.Error;
        _ = this.Params;
        _ = this.Response;
        _ = this.StatusCode;
    }

    public Run() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public Run(Run run)
        : base(run) { }
#pragma warning restore CS8618

    public Run(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Run(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="RunFromRaw.FromRawUnchecked"/>
    public static Run FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class RunFromRaw : IFromRawJson<Run>
{
    /// <inheritdoc/>
    public Run FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        Run.FromRawUnchecked(rawData);
}
