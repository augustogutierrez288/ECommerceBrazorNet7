using System;
using System.Collections.Generic;

namespace ECommerceBrazorNet7.Model;

public partial class User
{
    public int IdUser { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
