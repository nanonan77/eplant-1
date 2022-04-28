using System;
using System.Collections.Generic;

namespace Sketec.Api.Resources
{
    public class ApiBadRequestResponse
    {
        public string Message { get; set; }
        public ICollection<Error> Errors { get; set; }

        public class Error
        {
            public string Code { get; set; }
            public string Message { get; set; }
            public string Local { get; set; }
        }
    }

    public class ApiInternalErrorResponse
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
    }


}
