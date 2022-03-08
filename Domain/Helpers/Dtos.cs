using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AlawailApi.Domain.Models;

namespace AlawailApi.Domain.Helpers
{
    public class UserDto
    {

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
    public class RoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }

    }
    public class EmployeeAccountDto
    {
        public int EmployeeId { get; set; }
        public string Salary { get; set; }
        public string Tax { get; set; }
        public string Ammount { get; set; }
        public string BankAccountNumber { get; set; }
        public string Currency { get; set; }
    }
    public class DepartmentDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentHeadManager { get; set; }
    }
    public class IncomeDto
    {

    }
    public class OutcomeDto
    {

    }
    public class TransactionDto
    {
        public int Id { get; set; }
        public string Amount { get; set; }
        public string LeftOver { get; set; }
        public string Payments { get; set; }
        public string UserId { get; set; }
        public string StudentId { get; set; }
        public string PaymentMethod { get; set; }
        public string StudentYear { get; set; }
    }
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
    public class StudentAccountDto
    {
        public int Id { get; set; }
        public string StudentAccount { get; set; }
        public string Scholarships { get; set; }
        public string ScholarshipsType { get; set; }
        public string Tols { get; set; }
        public string Registration { get; set; }
        public string Cuurency { get; set; }
        public string Loan { get; set; }
    }
    public class StudentTollDto
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public string Amount { get; set; }
        public string Registration { get; set; }
        public string Currency { get; set; }
    }



}