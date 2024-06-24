﻿using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;

namespace Service
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            services.AddScoped<IValidator<CountryCreateDto>, CountryCreateDtoValidator>();
            services.AddScoped<IValidator<CountryEditDto>, CountryEditDtoValidator>();

            services.AddScoped<ICountryService, CountryService>();

            return services;
        }
    }
}
