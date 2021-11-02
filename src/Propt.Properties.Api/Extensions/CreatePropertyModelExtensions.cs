using Propt.Properties.Application.Commands;
using Propt.Properties.DataModels;
using System;

namespace Propt.Properties.Api.Extensions
{
    internal static class CreatePropertyModelExtensions
    {
        public static CreateProperty ToCommand(this CreatePropertyRequestModel model)
        {
            if(model.Id == Guid.Empty)
                model.Id = Guid.NewGuid();

            return new CreateProperty(
                model.Id,
                model.NameNumber,
                model.Street,
                model.City,
                model.County,
                model.Postcode);
        }
    }
}
