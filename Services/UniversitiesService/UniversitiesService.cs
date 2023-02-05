global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTNET2.Services.UniversitiesService
{
    public class UniversitiesService : IUniversitiesService
    {
        private static List<Universities> universities = new List<Universities>{
            new  Universities(),
            new Universities { Id = 1, Country = "Italy", UniName = "University of Rome", UniWebpage = "https://www.uniroma.it" },

        };

        private readonly IMapper _mapper;

        public UniversitiesService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
        }

        public ServiceResponse<List<Universities>> AddUni(Universities uni) //async calls for Entity,Database 
        {
            var ServiceResponse = new ServiceResponse<List<Universities>>();
            universities.Add(uni);
            ServiceResponse.Data = universities;
            return ServiceResponse;
        }

        public ServiceResponse<List<Universities>> GetUniversities()
        {
            var ServiceResponse = new ServiceResponse<List<Universities>>();
            ServiceResponse.Data = universities;
            return ServiceResponse;
        }

        public ServiceResponse<Universities> GetSingleUniversity(string Country)
        {
            var ServiceResponse = new ServiceResponse<Universities>();
            var uni = universities.FirstOrDefault(u => u.Country == Country);
            ServiceResponse.Data = uni;
            return ServiceResponse;
            // if (uni is not null)
            //     return uni;

            // throw new Exception("No university with this country");

        }

        Task<ServiceResponse<List<Universities>>> IUniversitiesService.GetUniversities()
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<List<Universities>>> IUniversitiesService.AddUni(Universities uni)
        {
            throw new NotImplementedException();
        }

        Task<ServiceResponse<Universities>> IUniversitiesService.GetSingleUniversity(string Country)
        {
            throw new NotImplementedException();
        }
    }
}