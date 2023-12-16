using System;
using System.Collections.Generic;

namespace HospitalManegementSystem.Data.Models;

public partial class Ward
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public int HospitalId { get; set; }

    public virtual Hospital Hospital { get; set; } = null!;

    public virtual ICollection<Pateint> Pateints { get; set; } = new List<Pateint>();
}
