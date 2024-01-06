using System;
using System.Collections.Generic;

namespace FoodStop_DB;

public partial class Branch
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public long Phone { get; set; }
}
