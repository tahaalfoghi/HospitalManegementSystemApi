using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class PateintDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public int HospitalId { get; set; }

    public int WardId { get; set; }

    
}
