using EnsureThat;
using Sketec.Core.Exceptions;
using Sketec.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Sketec.Core.Domains
{
    public class RoleActivity : Entity, IAggregateRoot
    {
        public string Role { get; set; }
        public string Page { get; set; }
        public string Activity { get; set; }
    }
}
