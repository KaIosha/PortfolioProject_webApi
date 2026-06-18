using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.OwnerDTOs
{
    public class UpdateOwnerDto
    {
        public required string FullName { get; set; }
        public required string Profile { get; set; }
        public string? Avatar { get; set; }

    }
}
