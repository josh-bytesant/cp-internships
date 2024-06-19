using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Application.Create
{
    public static class CreateApplicationErrors
    {
        public static readonly Error ErrorCreatingApplication = new(
        "CreateApplication.ErrorCreatingApplication",
        "An error was encountered when creating the application");

        public static readonly Error ProgramNotFoundForApplication = new(
        "CreateApplication.ProgramNotFoundForApplication",
        "A related program was not found for the program");
    }
}
