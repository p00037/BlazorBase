using System;
using ExtensionsLibrary;

namespace BlazorBase.Domain.Exceptions
{
    public class SaveErrorExcenption : Exception
    {
        public SaveErrorExcenption(string message) : base(message)
        {
        }
    }
}
