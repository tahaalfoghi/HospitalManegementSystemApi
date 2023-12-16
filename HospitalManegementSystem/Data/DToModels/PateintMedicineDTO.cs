﻿using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class PateintMedicineDTO
{
    public int Id { get; set; }

    public int PateintId { get; set; }

    public int MedicineId { get; set; }

    public virtual Medicine Medicine { get; set; } = null!;

    public virtual Pateint Pateint { get; set; } = null!;
}
