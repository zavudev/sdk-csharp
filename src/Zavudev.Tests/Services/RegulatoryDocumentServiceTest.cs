using System.Threading.Tasks;
using Zavudev.Models.RegulatoryDocuments;

namespace Zavudev.Tests.Services;

public class RegulatoryDocumentServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var regulatoryDocument = await this.client.RegulatoryDocuments.Create(
            new()
            {
                DocumentType = DocumentType.Passport,
                FileSize = 102400,
                MimeType = "image/jpeg",
                Name = "Passport Scan",
                StorageID = "kg2abc123...",
            },
            TestContext.Current.CancellationToken
        );
        regulatoryDocument.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var regulatoryDocument = await this.client.RegulatoryDocuments.Retrieve(
            "documentId",
            new(),
            TestContext.Current.CancellationToken
        );
        regulatoryDocument.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.RegulatoryDocuments.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.RegulatoryDocuments.Delete(
            "documentId",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UploadUrl_Works()
    {
        var response = await this.client.RegulatoryDocuments.UploadUrl(
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
