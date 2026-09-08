using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Zavudev.Core;

namespace Zavudev.Models.Templates;

[JsonConverter(typeof(JsonModelConverter<TemplateSyncResponse, TemplateSyncResponseFromRaw>))]
public sealed record class TemplateSyncResponse : JsonModel
{
    /// <summary>
    /// WhatsApp Business Accounts reconciled in this call.
    /// </summary>
    public required long AccountsSynced
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("accountsSynced");
        }
        init { this._rawData.Set("accountsSynced", value); }
    }

    /// <summary>
    /// Problems hit while syncing. Non-empty with a 200 means part of the sync did
    /// not complete — the rest still did.
    /// </summary>
    public required IReadOnlyList<string> Errors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("errors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// Templates that existed on Meta and were created in Zavu by this call.
    /// </summary>
    public required long Imported
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("imported");
        }
        init { this._rawData.Set("imported", value); }
    }

    /// <summary>
    /// Existing Zavu templates that were matched to a Meta template by name and bound
    /// to its Meta ID.
    /// </summary>
    public required long Linked
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("linked");
        }
        init { this._rawData.Set("linked", value); }
    }

    /// <summary>
    /// Meta templates left alone: already linked to a Zavu template, or rejected/disabled
    /// on Meta.
    /// </summary>
    public required long Skipped
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("skipped");
        }
        init { this._rawData.Set("skipped", value); }
    }

    /// <summary>
    /// Templates whose approval status changed to match Meta.
    /// </summary>
    public required long Updated
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("updated");
        }
        init { this._rawData.Set("updated", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccountsSynced;
        _ = this.Errors;
        _ = this.Imported;
        _ = this.Linked;
        _ = this.Skipped;
        _ = this.Updated;
    }

    public TemplateSyncResponse() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public TemplateSyncResponse(TemplateSyncResponse templateSyncResponse)
        : base(templateSyncResponse) { }
#pragma warning restore CS8618

    public TemplateSyncResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    TemplateSyncResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="TemplateSyncResponseFromRaw.FromRawUnchecked"/>
    public static TemplateSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class TemplateSyncResponseFromRaw : IFromRawJson<TemplateSyncResponse>
{
    /// <inheritdoc/>
    public TemplateSyncResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => TemplateSyncResponse.FromRawUnchecked(rawData);
}
