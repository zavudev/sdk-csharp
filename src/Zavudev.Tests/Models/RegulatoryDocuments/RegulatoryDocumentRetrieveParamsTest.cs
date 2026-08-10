using System;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Models.RegulatoryDocuments;

public class RegulatoryDocumentRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RegulatoryDocumentRetrieveParams { DocumentID = "documentId" };

        string expectedDocumentID = "documentId";

        Assert.Equal(expectedDocumentID, parameters.DocumentID);
    }

    [Fact]
    public void Url_Works()
    {
        RegulatoryDocumentRetrieveParams parameters = new() { DocumentID = "documentId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.zavu.dev/v1/documents/documentId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RegulatoryDocumentRetrieveParams { DocumentID = "documentId" };

        RegulatoryDocumentRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
