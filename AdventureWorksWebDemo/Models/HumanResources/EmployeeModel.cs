using AdventureWorksWebDemo.Attributes;
using System;

namespace AdventureWorksWebDemo.Models.HumanResources
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [ColumnMetadata("Id number")]
        public string NationalIdnumber { get; set; }

        [ColumnMetadata("Title")]
        public string Title { get; set; }

        [ColumnMetadata("First name")]
        public string FirstName { get; set; }

        [ColumnMetadata("Middle name")]
        public string MiddleName { get; set; }

        [ColumnMetadata("Last name")]
        public string LastName { get; set; }

        public string Suffix { get; set; }

        [ColumnMetadata("Job title")]
        public string JobTitle { get; set; }

        [ColumnMetadata("Birth date")]
        public DateTime BirthDate { get; set; }

        [ColumnMetadata("Maritals status")]
        public string MaritalStatus { get; set; }

        [ColumnMetadata("Gender")]
        public string Gender { get; set; }

        [ColumnMetadata("Hire date")]
        public DateTime HireDate { get; set; }

        [ColumnMetadata("Vacation hours")]
        public short VacationHours { get; set; }

        [ColumnMetadata("Sick-leave hours")]
        public short SickLeaveHours { get; set; }

        [ColumnMetadata("Additional contact info")]
        public string AdditionalContactInfo { get; set; }
    }
}
