namespace EventHistoryService.Models;

public record Setting(Guid Id, string Org, string Login, string Password, string Authorization, string Locale, Uri? TemplateHost, Uri? TaskHost);
