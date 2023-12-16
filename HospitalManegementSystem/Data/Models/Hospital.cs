using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class Hospital
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long Phone { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

    public virtual ICollection<Pateint> Pateints { get; set; } = new List<Pateint>();

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
