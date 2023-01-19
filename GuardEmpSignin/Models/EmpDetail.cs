using System;
using System.Collections.Generic;

namespace GuardEmpSignin.Models;

public partial class EmpDetail
{
    public int Id { get; set; }

    public string EmpFirstname { get; set; } = null!;

    public string EmpLastname { get; set; } = null!;

    public string? Photo { get; set; }
}
