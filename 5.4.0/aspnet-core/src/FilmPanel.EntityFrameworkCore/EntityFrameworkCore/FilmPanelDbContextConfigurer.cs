using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace FilmPanel.EntityFrameworkCore
{
    public static class FilmPanelDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<FilmPanelDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<FilmPanelDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
