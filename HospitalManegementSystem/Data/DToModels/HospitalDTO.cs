using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class HospitalDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long Phone { get; set; }

  
}
