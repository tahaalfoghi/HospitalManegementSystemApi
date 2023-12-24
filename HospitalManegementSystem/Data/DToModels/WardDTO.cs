using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class WardDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int HospitalId { get; set; }

}
