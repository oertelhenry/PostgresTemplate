using EventHistoryService.Models;
using JetBrains.Annotations;

namespace EventHistoryService.Database.Extensions;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public static class SettingsExtensions
{
    public static Setting Map(this Public.Tables.Setting source)
    {
        return new Setting(
            source.Id,
            source.Org,
            source.Login,
            source.Password,
            source.Authorization,
            source.Locale,
            source.TemplateHost,
            source.TaskHost
        );
    }

    public static Public.Tables.Setting Map(this Setting source, Guid operatorId)
    {
        return new Public.Tables.Setting
        {
            Id = source.Id,
            OperatorId = operatorId,
            Org = source.Org,
            Login = source.Login,
            Password = source.Password,
            Authorization = source.Authorization,
            Locale = source.Locale,
            TemplateHost = source.TemplateHost,
            TaskHost = source.TaskHost
        };
    }
}