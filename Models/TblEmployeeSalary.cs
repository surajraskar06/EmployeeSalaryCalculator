using System;
using System.Collections.Generic;

namespace EmployeeSalaryCalculator.Models;

public partial class TblEmployeeSalary
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? Department { get; set; }

    public string? Designation { get; set; }

    public decimal? BasicSalary { get; set; }

    public decimal? HouseRentAllowance { get; set; }

    public decimal? DearnessAllowance { get; set; }

    public decimal? ProvidentFund { get; set; }

    public decimal? GrossSalary { get; set; }

    public decimal? NetSalary { get; set; }
}
