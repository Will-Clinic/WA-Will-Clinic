using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    /// <summary>
    /// Interface to provide access to queries and CRUD on Veteran entities via DI. Additionally
    /// provides abstractions to many-to-many relationships which require the use of junction tables
    /// to reduce the complexity of those operations.
    /// </summary>
    public interface IVeteranService
    {
        /// <summary>
        /// Retrieves a Veteran entity using a ClaimsPrincipal such as that found in the User property
        /// in the Controller, PageModel, and HttpContext classes. 
        /// </summary>
        /// <param name="principal">The ClaimsPrincipal for the ApplicationUser entity corresponding
        /// to the requested Veteran entity.</param>
        /// <returns>The Veteran entity corresponding to the ApplicationUser entity represented
        /// by the specified ClaimsPrincipal object. If no such entity exists, then this method will
        /// return null.</returns>
        Task<Veteran> GetVeteranByPrincipalAsync(ClaimsPrincipal principal);
        /// <summary>
        /// Using an IEnumerable of primary keys for Library entities and the primary key for a Veteran
        /// entity, performs CRUD operations on junction table rows in order to form many-to-many relationships
        /// between the specified Veteran entity and the specified Library entities while avoiding duplicate
        /// or orphaned junction table rows.
        /// </summary>
        /// <param name="veteranId">The primary key for the Veteran entity to relate the Library entities to</param>
        /// <param name="libraryIds">An IEnumerable of primary keys for the Library entities that the Veteran
        /// entity should be related to. Any existing relationships not included in this IEnumerable will
        /// be removed from the database.</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> MergeLibraryListWithVeteranAsync(string veteranId, IEnumerable<long> libraryIds);
        /// <summary>
        /// Retrieves an IEnumerable of Veteran entities which fit the criteria for being potential clients
        /// for a lawyer, ordered chronologically by the dates and times in which the veterans added meeting
        /// locations.
        /// </summary>
        /// <param name="lawyerId">The primary key for the Lawyer entity to retrieve potential clients for</param>
        /// <returns>An IEnumerable of Veteran entities that meet the criteria for matching with the specified
        /// Lawyer entity</returns>
        Task<IEnumerable<Veteran>> GetPotentialClientsForLawyerAsync(string lawyerId);
        /// <summary>
        /// Finds a Veteran entity by primary key
        /// </summary>
        /// <param name="id">The primary key of the Veteran to find</param>
        /// <returns>The Veteran entity corresponding to the specified primary key. Returns null if no such
        /// Veteran entity is found.</returns>
        Task<Veteran> FindVeteranAsync(string id);
        /// <summary>
        /// Retrieves all VeteranLibraryJunction junction table entities corresponding to the specified
        /// Veteran entity by primary key.
        /// </summary>
        /// <param name="veteranId">The primary key for the Veteran entity to retrieve VeteranLibraryJunction
        /// entities for</param>
        /// <returns>An IEnumerable of all VeteranLibraryJunction entities related to the specified Veteran
        /// entity by the provided primary key or null if the Veteran could not be found.</returns>
        Task<IEnumerable<VeteranLibraryJunction>> GetVeteranLibraryJunctionsAsync(string veteranId);
    }
}
