using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class PrescriptionDTO
{
    public int Id { get; set; }

    public int PateintId { get; set; }

    public int DoctorId { get; set; }

    public DateTime PrescriptionDate { get; set; }


}
