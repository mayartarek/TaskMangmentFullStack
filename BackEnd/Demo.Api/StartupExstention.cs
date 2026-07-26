namespace Demo.Api
{
    public static class StartupExstention
    {
        public static async Task<WebApplication> SeedDatabaseAsync(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {            }
            return app;
        }
    }
}
