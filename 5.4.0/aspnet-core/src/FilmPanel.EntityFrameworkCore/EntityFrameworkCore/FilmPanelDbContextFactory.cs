using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using FilmPanel.Configuration;
using FilmPanel.Web;

namespace FilmPanel.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class FilmPanelDbContextFactory : IDesignTimeDbContextFactory<FilmPanelDbContext>
    {
        public FilmPanelDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FilmPanelDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            FilmPanelDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FilmPanelConsts.ConnectionStringName));

            return new FilmPanelDbContext(builder.Options);
        }
    }
}
