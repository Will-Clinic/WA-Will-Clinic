using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    /// <summary>
    /// Interface to provide access to queries on Library entities via DI. Additionally, provides
    /// abstractions to many-to-many relationships between Library, Lawyer, and Veteran entities
    /// </summary>
    public interface ILibraryService
    {
        /// <summary>
        /// Returns all Library entities from the database
        /// </summary>
        /// <returns>An IEnumerable of all Library entities from the database</returns>
        IEnumerable<Library> GetAllLibraries();

        /// <summary>
        /// returns all libraries that lawyers have associated themselves with
        /// </summary>
        /// <returns>IEnumerable of Library entities associated with lawyers</returns>
        Task<IEnumerable<Library>> GetAllLibrariesWithLawyers();

        /// <summary>
        /// Finds Library entities by their names
        /// </summary>
        /// <param name="name">The name to search for. Can be a partial name and is not case sensitive.</param>
        /// <returns>An IEnumerable of Library entities matching the search criteria</returns>
        Task<IEnumerable<Library>> FindLibrariesByNameAsync(string name);
        /// <summary>
        /// Find a Library entity by its primary key
        /// </summary>
        /// <param name="id">The primary key for the Library entity to find</param>
        /// <returns>The Library entity corresponding to the specified primary key. Returns false if no
        /// such Library entity exists.</returns>
        Task<Library> FindLibraryByIdAsync(long id);

        /// <summary>
        /// Gets all Library entities related to the specified Lawyer entity via the LaywerLibraryJunction
        /// junction table.
        /// </summary>
        /// <param name="lawyerId">The primary key for the Lawyer entity to retrieve related Library entities for</param>
        /// <returns>IEnumerable of all Library entities related to the specified Lawyer entity</returns>
        Task<IEnumerable<Library>> GetAllLibrariesForLawyerAsync(string lawyerId);
        /// <summary>
        /// Gets all Library entities related to the specified Veteran entity via the VeteranLibraryJunction
        /// junction table.
        /// </summary>
        /// <param name="veteranId">The primary key for the Veteran entity to retrieve related Library entities for</param>
        /// <returns>IEnumerable of all Library entities related to the specified Veteran entity</returns>
        Task<IEnumerable<Library>> GetAllLibrariesForVeteranAsync(string veteranId);
    }
}
