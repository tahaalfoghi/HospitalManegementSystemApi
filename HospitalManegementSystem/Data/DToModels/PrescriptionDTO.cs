using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class PrescriptionDTO
{
    public int Id { get; set; }

    public int PateintId { get; set; }

    public int DoctorId { get; set; }

    public DateTime PrescriptionDate { get; set; }

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Pateint Pateint { get; set; } = null!;

    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
