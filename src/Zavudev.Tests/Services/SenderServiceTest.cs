using System.Threading.Tasks;
using Zavudev.Models.Senders;

namespace Zavudev.Tests.Services;

public class SenderServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var sender = await this.client.Senders.Create(
            new() { Name = "name" },
            TestContext.Current.CancellationToken
        );
        sender.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var sender = await this.client.Senders.Retrieve(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        sender.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var sender = await this.client.Senders.Update(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        sender.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.Senders.List(new(), TestContext.Current.CancellationToken);
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Senders.Delete("senderId", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task GetProfile_Works()
    {
        var whatsappBusinessProfileResponse = await this.client.Senders.GetProfile(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        whatsappBusinessProfileResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RegenerateWebhookSecret_Works()
    {
        var webhookSecretResponse = await this.client.Senders.RegenerateWebhookSecret(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        webhookSecretResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateProfile_Works()
    {
        var response = await this.client.Senders.UpdateProfile(
            "senderId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UploadProfilePicture_Works()
    {
        var response = await this.client.Senders.UploadProfilePicture(
            "senderId",
            new() { ImageUrl = "https://example.com/profile.jpg", MimeType = MimeType.ImageJpeg },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
