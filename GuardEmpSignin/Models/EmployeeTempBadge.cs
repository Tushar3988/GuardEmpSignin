using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuardEmpSignin.Models;

public partial class EmployeeTempBadge
{
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]

    public int Id { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public string? TempBadge { get; set; }

    public DateTime SignInT { get; set; }

    public DateTime? SignOutT { get; set; }

    public DateTime? AssignT { get; set; }

    public int EmpContainer { get; set; }

}
