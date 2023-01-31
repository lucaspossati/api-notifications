﻿using api.Domain.VM.Shared;
using API.Domain.VM;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validator
{
    public static class Validation
    {
        public static void AddErrors(dynamic model, ValidationResult results)
        {
            if (!results.IsValid)
            {
                var errors = results.Errors.Select(x => new Error { PropertyName = x.PropertyName, ErrorMessage = x.ErrorMessage }).ToList();
                model.SetErrors(errors);
            }
            
        }
    }
}
