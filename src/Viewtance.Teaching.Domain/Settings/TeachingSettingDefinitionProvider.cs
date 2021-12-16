using Volo.Abp.Settings;

namespace Viewtance.Teaching.Settings
{
    public class TeachingSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TeachingSettings.MySetting1));
        }
    }
}
