using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Tests.Models.EmailDomains;

public class EmailDomainCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailDomainCreateResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                DomainValue = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = Purpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        Domain expectedDomain = new()
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
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
        var model = new EmailDomainCreateResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                DomainValue = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = Purpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailDomainCreateResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                DomainValue = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = Purpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Domain expectedDomain = new()
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
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
        var model = new EmailDomainCreateResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                DomainValue = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = Purpose.Dkim,
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
        var model = new EmailDomainCreateResponse
        {
            Domain = new()
            {
                ID = "emd_abc123",
                DkimStatus = "not_started",
                DomainValue = "example.com",
                Status = "pending",
                DnsRecords =
                [
                    new()
                    {
                        Name = "name",
                        Purpose = Purpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
            },
        };

        EmailDomainCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DomainTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string expectedID = "emd_abc123";
        string expectedDkimStatus = "not_started";
        string expectedDomainValue = "example.com";
        string expectedStatus = "pending";
        List<DnsRecord> expectedDnsRecords =
        [
            new()
            {
                Name = "name",
                Purpose = Purpose.Dkim,
                Required = true,
                Type = "CNAME",
                Value = "value",
                Priority = 0,
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDkimStatus, model.DkimStatus);
        Assert.Equal(expectedDomainValue, model.DomainValue);
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
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Domain>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Domain>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "emd_abc123";
        string expectedDkimStatus = "not_started";
        string expectedDomainValue = "example.com";
        string expectedStatus = "pending";
        List<DnsRecord> expectedDnsRecords =
        [
            new()
            {
                Name = "name",
                Purpose = Purpose.Dkim,
                Required = true,
                Type = "CNAME",
                Value = "value",
                Priority = 0,
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDkimStatus, deserialized.DkimStatus);
        Assert.Equal(expectedDomainValue, deserialized.DomainValue);
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
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
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
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
        };

        Assert.Null(model.DnsRecords);
        Assert.False(model.RawData.ContainsKey("dnsRecords"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
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
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",

            // Null should be interpreted as omitted for these properties
            DnsRecords = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Domain
        {
            ID = "emd_abc123",
            DkimStatus = "not_started",
            DomainValue = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = Purpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        Domain copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DnsRecordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string expectedName = "name";
        ApiEnum<string, Purpose> expectedPurpose = Purpose.Dkim;
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
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DnsRecord>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DnsRecord>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        ApiEnum<string, Purpose> expectedPurpose = Purpose.Dkim;
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
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
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
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
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
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
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
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
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
        var model = new DnsRecord
        {
            Name = "name",
            Purpose = Purpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        DnsRecord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PurposeTest : TestBase
{
    [Theory]
    [InlineData(Purpose.Dkim)]
    [InlineData(Purpose.Spf)]
    [InlineData(Purpose.Dmarc)]
    [InlineData(Purpose.MailFrom)]
    public void Validation_Works(Purpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Purpose> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Purpose.Dkim)]
    [InlineData(Purpose.Spf)]
    [InlineData(Purpose.Dmarc)]
    [InlineData(Purpose.MailFrom)]
    public void SerializationRoundtrip_Works(Purpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Purpose> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Purpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
