using HospitalManegementSystem.Data.Models;
using System;
using System.Collections.Generic;

namespace HospitalManegementSystem;

public partial class PrescriptionMedicineDTO
{
    public int Id { get; set; }

    public int PrescriptionId { get; set; }

    public int MedicineId { get; set; }

    
}
