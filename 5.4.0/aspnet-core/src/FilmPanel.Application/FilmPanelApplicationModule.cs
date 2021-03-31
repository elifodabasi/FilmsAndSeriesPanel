using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FilmPanel.Authorization;

namespace FilmPanel
{
    [DependsOn(
        typeof(FilmPanelCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FilmPanelApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FilmPanelAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FilmPanelApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
