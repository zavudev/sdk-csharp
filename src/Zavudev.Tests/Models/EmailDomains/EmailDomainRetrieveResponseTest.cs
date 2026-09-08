using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Tests.Models.EmailDomains;

public class EmailDomainRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailDomainRetrieveResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                Domain = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        EmailDomainRetrieveResponseDomain expectedDomain = new()
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        Assert.Equal(expectedDomain, model.Domain);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailDomainRetrieveResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                Domain = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailDomainRetrieveResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                Domain = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        EmailDomainRetrieveResponseDomain expectedDomain = new()
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        Assert.Equal(expectedDomain, deserialized.Domain);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailDomainRetrieveResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                Domain = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailDomainRetrieveResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                Domain = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        EmailDomainRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmailDomainRetrieveResponseDomainTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string expectedID = "emd_abc123";
        string expectedDkimStatus = "not_started";
        string expectedDomain = "example.com";
        string expectedStatus = "pending";
        List<EmailDomainRetrieveResponseDomainDnsRecord> expectedDnsRecords =
        [
            new()
            {
                Name = "name",
                Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                Required = true,
                Type = "CNAME",
                Value = "value",
                Priority = 0,
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDkimStatus, model.DkimStatus);
        Assert.Equal(expectedDomain, model.Domain);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.DnsRecords);
        Assert.Equal(expectedDnsRecords.Count, model.DnsRecords.Count);
        for (int i = 0; i < expectedDnsRecords.Count; i++)
        {
            Assert.Equal(expectedDnsRecords[i], model.DnsRecords[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainRetrieveResponseDomain>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainRetrieveResponseDomain>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "emd_abc123";
        string expectedDkimStatus = "not_started";
        string expectedDomain = "example.com";
        string expectedStatus = "pending";
        List<EmailDomainRetrieveResponseDomainDnsRecord> expectedDnsRecords =
        [
            new()
            {
                Name = "name",
                Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                Required = true,
                Type = "CNAME",
                Value = "value",
                Priority = 0,
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDkimStatus, deserialized.DkimStatus);
        Assert.Equal(expectedDomain, deserialized.Domain);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.DnsRecords);
        Assert.Equal(expectedDnsRecords.Count, deserialized.DnsRecords.Count);
        for (int i = 0; i < expectedDnsRecords.Count; i++)
        {
            Assert.Equal(expectedDnsRecords[i], deserialized.DnsRecords[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
        };

        Assert.Null(model.DnsRecords);
        Assert.False(model.RawData.ContainsKey("dnsRecords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",

            // Null should be interpreted as omitted for these properties
            DnsRecords = null,
        };

        Assert.Null(model.DnsRecords);
        Assert.False(model.RawData.ContainsKey("dnsRecords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",

            // Null should be interpreted as omitted for these properties
            DnsRecords = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailDomainRetrieveResponseDomain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        EmailDomainRetrieveResponseDomain copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmailDomainRetrieveResponseDomainDnsRecordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string expectedName = "name";
        ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose> expectedPurpose =
            EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim;
        bool expectedRequired = true;
        string expectedType = "CNAME";
        string expectedValue = "value";
        long expectedPriority = 0;

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPurpose, model.Purpose);
        Assert.Equal(expectedRequired, model.Required);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedPriority, model.Priority);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainRetrieveResponseDomainDnsRecord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainRetrieveResponseDomainDnsRecord>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose> expectedPurpose =
            EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim;
        bool expectedRequired = true;
        string expectedType = "CNAME";
        string expectedValue = "value";
        long expectedPriority = 0;

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPurpose, deserialized.Purpose);
        Assert.Equal(expectedRequired, deserialized.Required);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedPriority, deserialized.Priority);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
        };

        Assert.Null(model.Priority);
        Assert.False(model.RawData.ContainsKey("priority"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Priority = null,
        };

        Assert.Null(model.Priority);
        Assert.False(model.RawData.ContainsKey("priority"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",

            // Null should be interpreted as omitted for these properties
            Priority = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailDomainRetrieveResponseDomainDnsRecord
        {
            Name = "name",
            Purpose = EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        EmailDomainRetrieveResponseDomainDnsRecord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EmailDomainRetrieveResponseDomainDnsRecordPurposeTest : TestBase
{
    [Theory]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim)]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.Spf)]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dmarc)]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.MailFrom)]
    public void Validation_Works(EmailDomainRetrieveResponseDomainDnsRecordPurpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dkim)]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.Spf)]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.Dmarc)]
    [InlineData(EmailDomainRetrieveResponseDomainDnsRecordPurpose.MailFrom)]
    public void SerializationRoundtrip_Works(
        EmailDomainRetrieveResponseDomainDnsRecordPurpose rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, EmailDomainRetrieveResponseDomainDnsRecordPurpose>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
