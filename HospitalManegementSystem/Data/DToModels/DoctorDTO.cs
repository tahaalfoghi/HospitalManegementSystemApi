using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class DoctorDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string Specialization { get; set; } = null!;

    public int HospitalId { get; set; }

}
