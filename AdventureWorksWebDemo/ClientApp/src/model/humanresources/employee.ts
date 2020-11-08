export interface Employee {
  businessEntityId: number;
  nationalIdnumber: string;
  loginId: string;
  organizationLevel: number | null;
  jobTitle: string;
  birthDate: string;
  maritalStatus: string;
  gender: string;
  hireDate: string;
  salariedFlag: boolean | null;
  vacationHours: number;
  sickLeaveHours: number;
  currentFlag: boolean | null;
}
