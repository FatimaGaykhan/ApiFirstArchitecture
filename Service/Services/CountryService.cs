using System;
using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class CountryService:ICountryService
	{
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

		public CountryService(ICountryRepository countryRepo,
                             IMapper mapper)
		{
            _countryRepo = countryRepo;
            _mapper = mapper;
		}

        public async Task CreateAsync(CountryCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();

            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int id)
        {
             await _countryRepo.DeleteAsync(id);
        }

        public async Task EditAsync(CountryEditDto model,int id)
        {
            var existData = await _countryRepo.GetAsync(id);
            if (model is null) throw new ArgumentNullException();
            
            await _countryRepo.EditAsync(_mapper.Map(model, existData));

        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CountryDto>(await _countryRepo.GetById(id));
        }
    }
}

