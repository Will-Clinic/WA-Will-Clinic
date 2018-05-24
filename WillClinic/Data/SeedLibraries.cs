using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WillClinic.Models;

namespace WillClinic.Data
{
    public static class SeedLibraries
    {
        /// <summary>
        /// Deserializes a JSON library list at the provided filename (relative to the
        /// project root) into a list of Library objects to be seeded into the database.
        /// </summary>
        /// <param name="jsonFilename">The path to the source JSON file relative to the project root</param>
        /// <returns>A list of Library objects from the provided JSON</returns>
        private static List<Library> GetLibrariesFromJson(string jsonFilename)
        {
            // Ensures we are pointing to a path relative to the root of the project
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), jsonFilename);
            // Deserializes the JSON into a list of Library objects and returns it to the caller
            return JsonConvert.DeserializeObject<List<Library>>(File.ReadAllText(jsonPath));
        }

        /// <summary>
        /// Attempts to seed the database with libraries if the Library table is currently
        /// empty; otherwise, simply returns to the caller
        /// </summary>
        /// <param name="services">IServiceProvider from a built IWebHost object</param>
        public static void Initialize(IServiceProvider services)
        {
            using (ApplicationDbContext context = new ApplicationDbContext(
                services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // If there are any existing rows in the Library table then bail out of seeding
                if (context.Libraries.Any())
                {
                    return;
                }

                // If there are any pending migrations, apply them first
                if (context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }

                // Add the libraries from JSON and save changes
                context.Libraries.AddRange(GetLibrariesFromJson("StaticLibraryList.json"));
                context.SaveChanges();
            }
        }
    }
}
