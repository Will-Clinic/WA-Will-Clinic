using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    /// <summary>
    /// Interface to provide access to queries and CRUD on Lawyer entities
    /// via DI. Additionally provides abstractions to many-to-many relationships
    /// which require the use of junction tables to reduce the complexity of
    /// those operations.
    /// </summary>
    public interface ILawyerService
    {
        /// <summary>
        /// Retrieves a Lawyer entity using a ClaimsPrincipal such as that found
        /// in the User property in the Controller, PageModel, and HttpContext classes.
        /// </summary>
        /// <param name="principal">The ClaimsPrincipal for the ApplicationUser entity corresponding
        /// to the requested Lawyer entity.</param>
        /// <returns>The Lawyer entity corresponding to the ApplicationUser entity represented
        /// by the specified ClaimsPrincipal object. If no such entity exists, then this method
        /// will return null.</returns>
        Task<Lawyer> GetLawyerByPrincipalAsync(ClaimsPrincipal principal);
        /// <summary>
        /// Finds a Lawyer entity using the provided primary key
        /// </summary>
        /// <param name="id">The primary key of the requested Lawyer entity</param>
        /// <returns>The Lawyer entity corresponding to the specified primary key; otherwise,
        /// returns null</returns>
        Task<Lawyer> FindAsync(string id);
        /// <summary>
        /// Tries to update the database with the provided Lawyer entity state.
        /// </summary>
        /// <param name="lawyer">The updated state of a Lawyer entity</param>
        /// <returns>True on successful update; otherwise, false</returns>
        Task<bool> TryUpdateAsync(Lawyer lawyer);
        /// <summary>
        /// Tries to lock out the specified Lawyer entity by its primary key
        /// </summary>
        /// <param name="id">The primary key for the Lawyer entity to lock out</param>
        /// <returns>True if the Lawyer has been locked out; otherwise, false</returns>
        Task<bool> LockOutAsync(string id);
        /// <summary>
        /// Retrieves an IEnumerable of all LawyerSchedule entities related to the specified
        /// Lawyer entity by the Lawyer entity's primary key
        /// </summary>
        /// <param name="lawyerId">The primary key for the Lawyer entity to retrieve related
        /// LawyerSchedule entities for</param>
        /// <returns>An IEnumerable of all LawyerSchedule entities related to the specified
        /// Lawyer entity by the Lawyer entity's primary key</returns>
        Task<IEnumerable<LawyerSchedule>> GetSchedulesAsync(string lawyerId);

        /// <summary>
        /// Tries to add a LawyerSchedule entity to the database.
        /// </summary>
        /// <param name="lawyerSchedule">The LawyerSchedule object to add as an entity
        /// to the database with the foreign key set to the related Lawyer entity</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> AddScheduleAsync(LawyerSchedule lawyerSchedule);
        /// <summary>
        /// Tries to update an existing LawyerSchedule entity in the database
        /// </summary>
        /// <param name="lawyerSchedule">The updated state of a LawyerSchedule entity</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> UpdateScheduleAsync(LawyerSchedule lawyerSchedule);
        /// <summary>
        /// Tries to delete an existing LawyerSchedule entity from the database
        /// </summary>
        /// <param name="lawyerSchedule">The LawyerSchedule entity to delete</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> DeleteScheduleAsync(LawyerSchedule lawyerSchedule);

        /// <summary>
        /// Creates a many-to-many relationship between a Lawyer and a Library via their
        /// primary keys. Creates the necessary junction table row to establish the relationship.
        /// </summary>
        /// <param name="lawyerId">The primary key of the Lawyer entity in the relationship</param>
        /// <param name="libraryId">The primary key of the Library entity in the relationship</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> AddLibraryToLawyerAsync(string lawyerId, long libraryId);
        /// <summary>
        /// Removes a many-to-many relationship between a Lawyer and a Library via their
        /// primary keys. Removes the junction table row that was created to establish the relationship.
        /// </summary>
        /// <param name="lawyerId">The primary key of the Lawyer entity in the relationship</param>
        /// <param name="libraryId">The primary key of the Library entity in the relationship</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> RemoveLibraryFromLawyerAsync(string lawyerId, long libraryId);
        /// <summary>
        /// Using an IEnumerable of primary keys for Library entities and the primary key for a Lawyer entity,
        /// performs CRUD operations on junction table rows in order to form many-to-many relationships
        /// between the specified Lawyer entity and the specified Library entities while avoiding duplicate
        /// or orphaned junction table rows.
        /// </summary>
        /// <param name="lawyerId">The primary key for the Lawyer entity to relate the Library entities to</param>
        /// <param name="libraryIds">An IEnumerable of primary keys for the Library entities that the
        /// Lawyer entity should be related to. Any existing relationships not included in this IEnumerable
        /// will be removed from the database.</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> MergeLibraryListWithLawyerAsync(string lawyerId, IEnumerable<long> libraryIds);

        /// <summary>
        /// Creates a VeteranLawyerMatch table row related to the Lawyer and Veteran entities specified by
        /// primary key to this method.
        /// </summary>
        /// <param name="lawyerId">The primary key for the Lawyer entity for the new match</param>
        /// <param name="veteranId">The primary key for the Veteran entity for the new match</param>
        /// <returns>True on success; otherwise, false</returns>
        Task<bool> MatchWithVeteranAsync(string lawyerId, string veteranId, string libraryName);

        /// <summary>
        /// Verifies the specified Lawyer entity's bar status, returning true or false if the lawyer
        /// is verified to be eligible to provide services or not (respectively).
        /// </summary>
        /// <param name="id">The primary key for the Lawyer to verify with the WSBA</param>
        /// <returns>True if the Lawyer is able to provide services; otherwise, false if the lawyer is
        /// not allowed to practice law by the WSBA, his/her information is invalid, or the lawyer
        /// was not found.</returns>
        Task<bool> VerifyBarStatus(string id);
    }
}
