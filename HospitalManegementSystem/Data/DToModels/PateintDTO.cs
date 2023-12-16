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

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<DoctorPateint> DoctorPateints { get; set; } = new List<DoctorPateint>();

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual ICollection<PateintMedicine> PateintMedicines { get; set; } = new List<PateintMedicine>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    public virtual Ward Ward { get; set; } = null!;
}
