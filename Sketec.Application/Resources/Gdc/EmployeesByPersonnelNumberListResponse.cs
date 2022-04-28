using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.Application.Resources.Gdc
{
    public class EmployeesByPersonnelNumberListResponse
    {
        public List<EmployeesByPersonnelNumberList> ResponseData { get; set; }
        public GdcResponseBase ResponseBase { get; set; }
    }
    public class EmployeesByPersonnelNumberListRequest
    {
        public string PersonnelNumberList { get; set; }
        public string ReferenceToken { get; set; }
    }
    public class EmployeesByPersonnelNumberList
    {
        public int employee_File_DuplicationId { get; set; }
        public int organizationId { get; set; }
        public string peoplesoft_ID { get; set; }
        public string employment_Status_Code { get; set; }
        public string employment_Status_Text { get; set; }
        public string main_Position { get; set; }
        public string scG_Employee_ID { get; set; }
        public string alter_EMPID { get; set; }
        public string name_Title_Thai { get; set; }
        public string firstName_Thai { get; set; }
        public string lastName_Thai { get; set; }
        public string name_Title_English { get; set; }
        public string firstName_English { get; set; }
        public string lastName_English { get; set; }
        public string user_ID { get; set; }
        public string company { get; set; }
        public string company_Description { get; set; }
        public string company_Thai { get; set; }
        public string position_Name_English { get; set; }
        public string position_Name_Thai { get; set; }
        public string position_Number { get; set; }
        public string position_Description { get; set; }
        public string action { get; set; }
        public string action_date { get; set; }
        public string departmentID { get; set; }
        public string department_Description { get; set; }
        public string employee_Department_Description_Thai { get; set; }
        public string sub_1_Business_Unit_English { get; set; }
        public string sub_1_Business_Unit_Thai { get; set; }
        public string sub_1_1_Business_Unit_Thai { get; set; }
        public string sub_1_Company_English { get; set; }
        public string sub_1_Company_Thai { get; set; }
        public string division_English { get; set; }
        public string division_Thai { get; set; }
        public string sub_1_Division_English { get; set; }
        public string sub_1_Division_Thai { get; set; }
        public string department_Thai { get; set; }
        public string department_English { get; set; }
        public string sub_1_Department_English { get; set; }
        public string sub_1_Department_Thai { get; set; }
        public string section_English { get; set; }
        public string section_Thai { get; set; }
        public string sub_1_Section_English { get; set; }
        public string sub_1_Section_Thai { get; set; }
        public string shift_English { get; set; }
        public string shift_Thai { get; set; }
        public string sub_1_Shift_English { get; set; }



        public string sub_1_Shift_Thai { get; set; }
        public string location { get; set; }
        public string location_Description { get; set; }
        public string business_Unit { get; set; }
        public string business_Unit_Description_English { get; set; }
        public string business_Unit_Description_Thai { get; set; }
        public string manager { get; set; }
        public string employee_Class { get; set; }
        public string employee_Class_Description { get; set; }
        public string pL_Group { get; set; }
        public string pL_Group_Description { get; set; }
        public string pL_Employee_Subgroup_Objects { get; set; }
        public string pL_Date { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string nationality { get; set; }
        public string martial_Status { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string address4 { get; set; }
        public string city { get; set; }
        public string state1 { get; set; }
        public string postal { get; set; }
        public string telephone_Home { get; set; }
        public string address_Offiice { get; set; }
        public string office_Address_Floor { get; set; }
        public string office_Address_Room { get; set; }
        public string office_Address_Province { get; set; }
        public string telephone_Business { get; set; }
        public string telephone_Beside { get; set; }
        public string spouse_Name { get; set; }
        public string spouse_LastName { get; set; }
        public string highest_Education_Level { get; set; }
        public string education { get; set; }
        public string blood_Type { get; set; }
        public string hire_Date { get; set; }
        public string position_Entry_Date { get; set; }
        public string employee_Type_ID { get; set; }
        public string national_ID { get; set; }
        public string email { get; set; }
        public string report_To { get; set; }
        public string report_to_Position_Name { get; set; }
        public string report_Employee_ID { get; set; }
        public string report_Name { get; set; }
        public string report_Email { get; set; }
        public string manager_Position { get; set; }
        public string manager_SCG_EMP_ID { get; set; }
        public string manager_s_User_ID { get; set; }
        public string nick_Name { get; set; }
        public string telephone_Mobile { get; set; }
        public string emergency_Contact_Name_Primary { get; set; }
        public string emergency_Contact_Telephone_Number_Primary { get; set; }
        public string emergency_Contact_Mobile_Number_Primary { get; set; }
        public string email_Home { get; set; }
        public string email_Other { get; set; }
        public string costCenter_Dept { get; set; }
        public string organization_Unit_ID_of_Parent_Node { get; set; }
        public string costCenter_Over { get; set; }
        public string termination_Date { get; set; }
        public string service_Year { get; set; }
        public string service_Months { get; set; }
        public string terminate_Reason { get; set; }
        public string tax_ID { get; set; }
        public string account_Locked { get; set; }
        public string last_Sign_on_Date_Time { get; set; }
        public string last_Update_Date_Time { get; set; }
        public string vendor_Customer_ID { get; set; }
        public string flag_IInsert_DDelete_UUpdate { get; set; }
        public string system_Date_Time { get; set; }
        public string bank_ID_Primary { get; set; }
        public string branch_ID_Primary { get; set; }
        public string bank_Name_Primary { get; set; }
        public string banch_Name_Primary { get; set; }
        public string account_ID { get; set; }
        public string old_Company { get; set; }
        public string old_SCG_EMP_ID { get; set; }
        public string middle_name { get; set; }
        public DateTime createdDate { get; set; }
        public int createdBy { get; set; }
        public bool isDeleted { get; set; }
        public int state { get; set; }
    }
}
