using System;
using System.Collections.Generic;

namespace StageApp.Models;

public partial class Phase
{
    public int IdPhase { get; set; }

    public string Phase1 { get; set; } = null!;

    public virtual ICollection<PhaseAffectation> PhaseAffectations { get; set; } = new List<PhaseAffectation>();
}
