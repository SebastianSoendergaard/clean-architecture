using System;

namespace CleanArchitecture.Application.Common
{
    public class Error<Terrorcode> where Terrorcode : Enum
    {
        public static Error<Terrorcode> Create(Terrorcode code, string desciption)
        {
            return new Error<Terrorcode>
            { 
                Code = code,
                Description = desciption
            };
        }

        public Terrorcode Code { get; init; }
        public string Description { get; init; }
    }
}
