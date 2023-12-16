using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class MedicineDTO
{
    public int Id { get; set; }

    public string GenericName { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<PateintMedicine> PateintMedicines { get; set; } = new List<PateintMedicine>();

    public virtual ICollection<PrescriptionMedicine> PrescriptionMedicines { get; set; } = new List<PrescriptionMedicine>();
}
