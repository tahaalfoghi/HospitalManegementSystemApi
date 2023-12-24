﻿using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class AppointmentDTO
{
    public int Id { get; set; }

    public int PateintId { get; set; }

    public int DoctorId { get; set; }

    public DateTime AppointmentDate { get; set; }

   
}
