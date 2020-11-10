using System;

namespace AdventureWorksWebDemo.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string NationalIdnumber { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string JobTitle { get; set; }
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public string AdditionalContactInfo { get; set; }
    }
}
