using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns.PhoneNumbers;

public class PhoneNumberAssignResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PhoneNumberAssignResponse
        {
            Assignment = new()
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
        };

        TenDlcPhoneNumberAssignment expectedAssignment = new()
        {
            ID = "id",
            CampaignID = "campaignId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumberID = "phoneNumberId",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failureReason",
        };

        Assert.Equal(expectedAssignment, model.Assignment);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PhoneNumberAssignResponse
        {
            Assignment = new()
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberAssignResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PhoneNumberAssignResponse
        {
            Assignment = new()
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PhoneNumberAssignResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TenDlcPhoneNumberAssignment expectedAssignment = new()
        {
            ID = "id",
            CampaignID = "campaignId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumberID = "phoneNumberId",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            AssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            FailureReason = "failureReason",
        };

        Assert.Equal(expectedAssignment, deserialized.Assignment);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PhoneNumberAssignResponse
        {
            Assignment = new()
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PhoneNumberAssignResponse
        {
            Assignment = new()
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
        };

        PhoneNumberAssignResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
