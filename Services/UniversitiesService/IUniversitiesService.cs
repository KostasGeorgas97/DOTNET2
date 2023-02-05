using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET2.Services.UniversitiesService
{
    public interface IUniversitiesService
    {
        Task <ServiceResponse<List<Universities>>> GetUniversities();
        Task <ServiceResponse<Universities>> GetSingleUniversity(string Country);
        Task <ServiceResponse<List<Universities>>> AddUni(Universities uni);
    }
}