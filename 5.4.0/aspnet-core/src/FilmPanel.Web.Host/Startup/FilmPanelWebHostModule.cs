using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FilmPanel.Configuration;

namespace FilmPanel.Web.Host.Startup
{
    [DependsOn(
       typeof(FilmPanelWebCoreModule))]
    public class FilmPanelWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FilmPanelWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FilmPanelWebHostModule).GetAssembly());
        }
    }
}
