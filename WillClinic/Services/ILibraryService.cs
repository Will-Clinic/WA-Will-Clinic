using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WillClinic.Models;

namespace WillClinic.Services
{
    public interface ILibraryService
    {
        IEnumerable<Library> GetAllLibraries();
        Task<Library> FindLibraryByNameAsync(string name);
    }
}
