﻿using Almaz.AssetManagement.Infrastructure.DatabaseInitialization;
using Calabonga.AspNetCore.AppDefinitions;

namespace Almaz.AssetManagement.Web.Definitions.DataSeeding
{
    /// <summary>
    /// Seeding DbContext for default data for EntityFrameworkCore
    /// </summary>
    public class DataSeedingDefinition : AppDefinition
    {
        /// <summary>
        /// Configure application for current application
        /// </summary>
        /// <param name="app"></param>
        public override void ConfigureApplication(WebApplication app)
        {
            DatabaseInitializer.SeedUsers(app.Services);
            DatabaseInitializer.SeedEvents(app.Services);
        }
    }
}