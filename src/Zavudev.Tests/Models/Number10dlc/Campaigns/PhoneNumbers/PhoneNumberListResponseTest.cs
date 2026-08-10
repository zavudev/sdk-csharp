using System;
using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns.PhoneNumbers;

public class PhoneNumberListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
            NextCursor = "nextCursor",
        };

        List<TenDlcPhoneNumberAssignment> expectedItems =
        [
            new()
            {
                ID = "id",
                CampaignID = "campaignId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PhoneNumberID = "phoneNumberId",
                Status = Status.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FailureReason = "failureReason",
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextCursor, model.NextCursor);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
            NextCursor = "nextCursor",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
            NextCursor = "nextCursor",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<TenDlcPhoneNumberAssignment> expectedItems =
        [
            new()
            {
                ID = "id",
                CampaignID = "campaignId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PhoneNumberID = "phoneNumberId",
                Status = Status.Pending,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                FailureReason = "failureReason",
            },
        ];
        string expectedNextCursor = "nextCursor";

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextCursor, deserialized.NextCursor);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
            NextCursor = "nextCursor",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
        };

        Assert.Null(model.NextCursor);
        Assert.False(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],

            NextCursor = null,
        };

        Assert.Null(model.NextCursor);
        Assert.True(model.RawData.ContainsKey("nextCursor"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],

            NextCursor = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CampaignID = "campaignId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PhoneNumberID = "phoneNumberId",
                    Status = Status.Pending,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    FailureReason = "failureReason",
                },
            ],
            NextCursor = "nextCursor",
        };

        PhoneNumberListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
