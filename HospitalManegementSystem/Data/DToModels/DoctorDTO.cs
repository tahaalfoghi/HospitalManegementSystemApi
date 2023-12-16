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

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorPateint> DoctorPateints { get; set; } = new List<DoctorPateint>();

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
