using System.Collections.Generic;
using System.Text.Json;
using Zavudev.Core;
using Zavudev.Exceptions;
using Zavudev.Models.EmailDomains;

namespace Zavudev.Tests.Models.EmailDomains;

public class EmailDomainListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailDomainListResponse
        {
            Items =
            [
                new()
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
                            Purpose = ItemDnsRecordPurpose.Dkim,
                            Required = true,
                            Type = "CNAME",
                            Value = "value",
                            Priority = 0,
                        },
                    ],
                },
            ],
        };

        List<Item> expectedItems =
        [
            new()
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
                        Purpose = ItemDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
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
        var model = new EmailDomainListResponse
        {
            Items =
            [
                new()
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
                            Purpose = ItemDnsRecordPurpose.Dkim,
                            Required = true,
                            Type = "CNAME",
                            Value = "value",
                            Priority = 0,
                        },
                    ],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailDomainListResponse
        {
            Items =
            [
                new()
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
                            Purpose = ItemDnsRecordPurpose.Dkim,
                            Required = true,
                            Type = "CNAME",
                            Value = "value",
                            Priority = 0,
                        },
                    ],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Item> expectedItems =
        [
            new()
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
                        Purpose = ItemDnsRecordPurpose.Dkim,
                        Required = true,
                        Type = "CNAME",
                        Value = "value",
                        Priority = 0,
                    },
                ],
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
        var model = new EmailDomainListResponse
        {
            Items =
            [
                new()
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
                            Purpose = ItemDnsRecordPurpose.Dkim,
                            Required = true,
                            Type = "CNAME",
                            Value = "value",
                            Priority = 0,
                        },
                    ],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailDomainListResponse
        {
            Items =
            [
                new()
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
                            Purpose = ItemDnsRecordPurpose.Dkim,
                            Required = true,
                            Type = "CNAME",
                            Value = "value",
                            Priority = 0,
                        },
                    ],
                },
            ],
        };

        EmailDomainListResponse copied = new(model);

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
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = ItemDnsRecordPurpose.Dkim,
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
        List<ItemDnsRecord> expectedDnsRecords =
        [
            new()
            {
                Name = "name",
                Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new Item
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
                    Purpose = ItemDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
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
            ID = "emd_abc123",
            DkimStatus = "not_started",
            Domain = "example.com",
            Status = "pending",
            DnsRecords =
            [
                new()
                {
                    Name = "name",
                    Purpose = ItemDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "emd_abc123";
        string expectedDkimStatus = "not_started";
        string expectedDomain = "example.com";
        string expectedStatus = "pending";
        List<ItemDnsRecord> expectedDnsRecords =
        [
            new()
            {
                Name = "name",
                Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new Item
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
                    Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new Item
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
        var model = new Item
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
        var model = new Item
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
        var model = new Item
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
        var model = new Item
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
                    Purpose = ItemDnsRecordPurpose.Dkim,
                    Required = true,
                    Type = "CNAME",
                    Value = "value",
                    Priority = 0,
                },
            ],
        };

        Item copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemDnsRecordTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string expectedName = "name";
        ApiEnum<string, ItemDnsRecordPurpose> expectedPurpose = ItemDnsRecordPurpose.Dkim;
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
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemDnsRecord>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ItemDnsRecord>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        ApiEnum<string, ItemDnsRecordPurpose> expectedPurpose = ItemDnsRecordPurpose.Dkim;
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
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
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
        var model = new ItemDnsRecord
        {
            Name = "name",
            Purpose = ItemDnsRecordPurpose.Dkim,
            Required = true,
            Type = "CNAME",
            Value = "value",
            Priority = 0,
        };

        ItemDnsRecord copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ItemDnsRecordPurposeTest : TestBase
{
    [Theory]
    [InlineData(ItemDnsRecordPurpose.Dkim)]
    [InlineData(ItemDnsRecordPurpose.Spf)]
    [InlineData(ItemDnsRecordPurpose.Dmarc)]
    [InlineData(ItemDnsRecordPurpose.MailFrom)]
    public void Validation_Works(ItemDnsRecordPurpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemDnsRecordPurpose> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemDnsRecordPurpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<ZavudevInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ItemDnsRecordPurpose.Dkim)]
    [InlineData(ItemDnsRecordPurpose.Spf)]
    [InlineData(ItemDnsRecordPurpose.Dmarc)]
    [InlineData(ItemDnsRecordPurpose.MailFrom)]
    public void SerializationRoundtrip_Works(ItemDnsRecordPurpose rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ItemDnsRecordPurpose> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemDnsRecordPurpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ItemDnsRecordPurpose>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ItemDnsRecordPurpose>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
