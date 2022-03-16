using System;
using System.Collections.Generic;

#nullable disable

namespace MagiProject.Domain.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CityName { get; set; }
    }
}
