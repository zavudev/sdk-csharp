using System;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.Number10dlc.Campaigns.PhoneNumbers;

namespace Zavudev.Tests.Models.Number10dlc.Campaigns.PhoneNumbers;

public class TenDlcPhoneNumberAssignmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
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

        string expectedID = "id";
        string expectedCampaignID = "campaignId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPhoneNumberID = "phoneNumberId";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedAssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failureReason";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCampaignID, model.CampaignID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPhoneNumberID, model.PhoneNumberID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedAssignedAt, model.AssignedAt);
        Assert.Equal(expectedFailureReason, model.FailureReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcPhoneNumberAssignment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenDlcPhoneNumberAssignment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCampaignID = "campaignId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPhoneNumberID = "phoneNumberId";
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedAssignedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedFailureReason = "failureReason";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCampaignID, deserialized.CampaignID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPhoneNumberID, deserialized.PhoneNumberID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedAssignedAt, deserialized.AssignedAt);
        Assert.Equal(expectedFailureReason, deserialized.FailureReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
        {
            ID = "id",
            CampaignID = "campaignId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumberID = "phoneNumberId",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.AssignedAt);
        Assert.False(model.RawData.ContainsKey("assignedAt"));
        Assert.Null(model.FailureReason);
        Assert.False(model.RawData.ContainsKey("failureReason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
        {
            ID = "id",
            CampaignID = "campaignId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumberID = "phoneNumberId",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
        {
            ID = "id",
            CampaignID = "campaignId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumberID = "phoneNumberId",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AssignedAt = null,
            FailureReason = null,
        };

        Assert.Null(model.AssignedAt);
        Assert.True(model.RawData.ContainsKey("assignedAt"));
        Assert.Null(model.FailureReason);
        Assert.True(model.RawData.ContainsKey("failureReason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
        {
            ID = "id",
            CampaignID = "campaignId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PhoneNumberID = "phoneNumberId",
            Status = Status.Pending,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            AssignedAt = null,
            FailureReason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TenDlcPhoneNumberAssignment
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

        TenDlcPhoneNumberAssignment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Active)]
    [InlineData(Status.Failed)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Active)]
    [InlineData(Status.Failed)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
