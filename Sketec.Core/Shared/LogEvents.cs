using Microsoft.Extensions.Logging;

namespace Sketec.Core.Shared
{
    public sealed class LogEvents
    {

        public static readonly EventId CrmApi_SyncMaster_Success = new EventId(1000, "CRM-SyncMaster-Success");
        public static readonly EventId CrmApi_SyncMaster_EX = new EventId(1001, "CRM-SyncMaster-Exception");
        public static readonly EventId CrmApi_SyncMaster_GetAster_EX = new EventId(1002, "CRM-SyncMaster-GetMaster-Exception");
        public static readonly EventId CrmApi_SyncMaster_GetAster_Success = new EventId(1003, "CRM-SyncMaster-GetMaster-Success");
        public static readonly EventId CrmApi_Response_Token = new EventId(1004, "CRM-Responsed-Token");
        public static readonly EventId CrmApi_Response_Token_PraseJson = new EventId(1005, "CRM-Responsed-Token-ParseJson");
        public static readonly EventId CrmApi_Response_Post = new EventId(1006, "CRM-Responsed-Post");
        public static readonly EventId CrmApi_Response_Post_PraseJson = new EventId(1007, "CRM-Responsed-Post-ParseJson");
        public static readonly EventId CrmApi_Set_UpdatedCrm_Success = new EventId(1008, "CRM-Set-UpdatedCrm-Success");


        public static readonly EventId Sftp_Connecting = new EventId(2001, "SFTP-Connecting");
        public static readonly EventId Sftp_Connected_Exception = new EventId(2002, "SFTP");
        public static readonly EventId Sftp_Connected_Success = new EventId(2003, "SFTP");

        public static readonly EventId Ftp_Connecting = new EventId(3001, "FTP-Connecting");
        public static readonly EventId Ftp_Connected_Exception = new EventId(3002, "FTP_Connected_Exceptiong");
        public static readonly EventId Ftp_Connected_Success = new EventId(3003, "FTP_Connected_Success");

        public static readonly EventId Sync_SdBilling_Start = new EventId(4000, "Sync_SdBilling_Start");
        public static readonly EventId Sync_SdBilling_Header_Start = new EventId(4002, "Sync_SdBillingHeader_Start");
        public static readonly EventId Sync_SdBilling_Header_Finished = new EventId(4003, "Sync_SdBillingHeader_Finished");
        public static readonly EventId Sync_SdBilling_End_Success = new EventId(4010, "Sync_SdBilling_End_Success");
        public static readonly EventId Sync_SdBilling_End_Exception = new EventId(4020, "Sync_SdBilling_End_Exception");
        public static readonly EventId Sync_SdBilling_YBill_Calculate_Exception = new EventId(4025, "Sync_SdBilling_YBill_Calculate_Exception");
        public static readonly EventId Sync_SdBilling_Process_Loop_Start= new EventId(4001, "Sync_SdBilling_Process_Loop_Start");
        public static readonly EventId Sync_SdBilling_Process_Loop_Not_In_Condition = new EventId(4012, "Sync_SdBilling_Process_Loop_Not_In_Condition");
        public static readonly EventId Sync_SdBilling_Process_Loop_Noti= new EventId(4041, "Sync_SdBilling_Process_Loop_Noti");
        public static readonly EventId Sync_SdBilling_Process_Loop_Success= new EventId(4011, "Sync_SdBilling_Process_Loop_Success");
        public static readonly EventId Sync_SdBilling_Process_Loop_Exception = new EventId(4022, "Sync_SdBilling_Process_Loop_Exception");
        public static readonly EventId Sync_SdBilling_Billing_Company_Not_Existing = new EventId(4032, "Sync_SdBilling_Billing_Company_Not_Existing");
        public static readonly EventId Sync_SdBilling_Billing_Customer_Not_Existing = new EventId(4033, "Sync_SdBilling_Billing_Customer_Not_Existing");
        public static readonly EventId Sync_SdBilling_Billing_Customer_SalesOrg_Not_Existing = new EventId(4035, "Sync_SdBilling_Billing_Customer_SalesOrg_Not_Existing");
        public static readonly EventId Sync_SdBilling_Billing_SalesOrg_Not_Existing = new EventId(4034, "Sync_SdBilling_Billing_SalesOrg_Not_Existing");
        public static readonly EventId Sync_SdBilling_YCol_Calculate_Exception = new EventId(4026, "Sync_SdBilling_YCol_Calculate_Exception");
        public static readonly EventId Sync_SdBilling_Process_Loop_Duplicate = new EventId(4013, "Sync_SdBilling_Process_Loop_Duplicate");
        public static readonly EventId Sync_SdBilling_Process_Loop_Cancel_Request = new EventId(4015, "Sync_SdBilling_Process_Loop_Cancel_Request");

        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Noti = new EventId(4141, "Sync_SdBilling_Item_Process_Loop_Noti");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Start = new EventId(4101, "Sync_SdBilling_Item_Process_Loop_Start");
        public static readonly EventId Sync_SdBilling_Item_Start = new EventId(4102, "Sync_SdBilling_Item_Start");
        public static readonly EventId Sync_SdBilling_Item_Finished = new EventId(4103, "Sync_SdBilling_Item_Finished");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Billing_Header_Not_Found = new EventId(4121, "Sync_SdBilling_Item_Process_Loop_Billing_Header_Not_Found");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Not_In_Condition = new EventId(4112, "Sync_SdBilling_Item_Process_Loop_Not_In_Condition");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Duplicate = new EventId(4113, "Sync_SdBilling_Item_Process_Loop_Duplicate");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Success = new EventId(4111, "Sync_SdBilling_Item_Process_Loop_Success");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Exception = new EventId(4122, "Sync_SdBilling_Item_Process_Loop_Exception");
        public static readonly EventId Sync_SdBilling_Item_Process_Loop_Cancel_Request = new EventId(4115, "Sync_SdBilling_Item_Process_Loop_Cancel_Request");

        public static readonly EventId Sync_DeliveryFlowDomestic_Start = new EventId(5000, "Sync_DeliveryFlowDomestic_Start");
        public static readonly EventId Sync_DeliveryFlowDomestic_End_Success = new EventId(5010, "Sync_DeliveryFlowDomestic_End_Success");
        public static readonly EventId Sync_DeliveryFlowDomestic_End_Exception = new EventId(5020, "Sync_DeliveryFlowDomestic_End_Exception");
        public static readonly EventId Sync_DeliveryFlowDomestic_Loop_Error = new EventId(5021, "Sync_DeliveryFlowDomestic_Loop_Error");
        public static readonly EventId Sync_DeliveryFlowDomestic_Loop_Notify = new EventId(5041, "Sync_DeliveryFlowDomestic_Loop_Notify");

        public static readonly EventId YBill_Start_Calculate_By_SalesOrg_CustomerCode = new EventId(6000, "YBill_Start_Calculate_By_SalesOrg_CustomerCode");
        public static readonly EventId YBill_Start_Calculate_By_SalesOrg_CustomerCode_Exception = new EventId(6020, "YBill_Start_Calculate_By_SalesOrg_CustomerCode_Exception");
        public static readonly EventId YBill_Start_Calculate_By_BillingId = new EventId(6001, "YBill_Start_Calculate_By_BillingId");
        public static readonly EventId YBill_Not_FoundBehavior = new EventId(6031, "YBill_Not_FoundBehavior");
        public static readonly EventId YBill_Calculate_Result_NULL = new EventId(6031, "YBill_Calculate_Result_NULL");
        public static readonly EventId YBill_Start_Calculate_By_SalesOrg_CustomerCode_Success = new EventId(6010, "YBill_Start_Calculate_By_SalesOrg_CustomerCode_Success");
        public static readonly EventId YBill_Start_Calculate_By_BillingId_Success = new EventId(6011, "YBill_Start_Calculate_By_BillingId_Success");
        public static readonly EventId YBill_Calculate_Billing_Date_NULL = new EventId(6032, "YBill_Calculate_Billing_Date_NULL");
        public static readonly EventId YBill_Calculate_Document_Date_NULL = new EventId(6132, "YBill_Calculate_Document_Date_NULL");
        public static readonly EventId YBill_Calculate_PaymentTerm_NULL = new EventId(6133, "YBill_Calculate_PaymentTerm_NULL");
        public static readonly EventId YBill_CashSales_Not_FoundBehavior = new EventId(6131, "YBill_CashSales_Not_FoundBehavior");
        public static readonly EventId YBill_CashSales_Calculate_Result_NULL = new EventId(6134, "YBill_CashSales_Calculate_Result_NULL");

        public static readonly EventId YCol_Start_Calculate_By_SalesOrg_CustomerCode = new EventId(7000, "YCol_Start_Calculate_By_SalesOrg_CustomerCode");
        public static readonly EventId YCol_Start_Calculate_By_SalesOrg_CustomerCode_Exception = new EventId(7020, "YCol_Start_Calculate_By_SalesOrg_CustomerCode_Exception");
        public static readonly EventId YCol_Start_Calculate_By_BillingId = new EventId(7001, "YCol_Start_Calculate_By_BillingId");
        public static readonly EventId YCol_Not_FoundBehavior = new EventId(7031, "YCol_Not_FoundBehavior");
        public static readonly EventId YCol_Calculate_Result_NULL = new EventId(7031, "YCol_Calculate_Result_NULL");
        public static readonly EventId YCol_Start_Calculate_By_SalesOrg_CustomerCode_Success = new EventId(7010, "YCol_Start_Calculate_By_SalesOrg_CustomerCode_Success");
        public static readonly EventId YCol_Start_Calculate_By_BillingId_Success = new EventId(7011, "YCol_Start_Calculate_By_BillingId_Success");
        public static readonly EventId YCol_Calculate_Calculate_Date_NULL = new EventId(7032, "YCol_Calculate_Calculate_Date_NULL");
        public static readonly EventId YCol_CashSales_Calculate_Calculate_Date_NULL = new EventId(7132, "YCol_CashSales_Calculate_Calculate_Date_NULL");
        public static readonly EventId YCol_CashSales_PaymentTerm_NULL = new EventId(7133, "YCol_CashSales_PaymentTerm_NULL");
        public static readonly EventId YCol_CashSales_Not_FoundBehavior = new EventId(7131, "YCol_CashSales_Not_FoundBehavior");
        public static readonly EventId YCol_CashSales_Calculate_Result_NULL = new EventId(7134, "YCol_CashSales_Calculate_Result_NULL");

        public static readonly EventId YCal_Start_Calculate_By_SalesOrg_CustomerCode = new EventId(8000, "YCal_Start_Calculate_By_SalesOrg_CustomerCode");
        public static readonly EventId YCal_Start_Calculate_By_SalesOrg_CustomerCode_Exception = new EventId(8020, "YCal_Start_Calculate_By_SalesOrg_CustomerCode_Exception");
        public static readonly EventId YCal_Start_Calculate_By_BillingId = new EventId(8001, "YCal_Start_Calculate_By_BillingId");
        public static readonly EventId YCal_Not_FoundBehavior = new EventId(8031, "YCal_Not_FoundBehavior");
        public static readonly EventId YCal_Calculate_Result_NULL = new EventId(8031, "YCal_Calculate_Result_NULL");
        public static readonly EventId YCal_Start_Calculate_By_SalesOrg_CustomerCode_Success = new EventId(8010, "YCal_Start_Calculate_By_SalesOrg_CustomerCode_Success");
        public static readonly EventId YCal_Start_Calculate_By_BillingId_Success = new EventId(8011, "YCal_Start_Calculate_By_BillingId_Success");
        public static readonly EventId YCal_Calculate_Calculate_Date_NULL = new EventId(8032, "YCal_Calculate_Calculate_Date_NULL");
        public static readonly EventId YCal_CashSales_Calculate_Calculate_Date_NULL = new EventId(8132, "YCal_CashSales_Calculate_Calculate_Date_NULL");
        public static readonly EventId YCal_CashSales_PaymentTerm_NULL = new EventId(8133, "YCal_CashSales_PaymentTerm_NULL");
        public static readonly EventId YCal_CashSales_Not_FoundBehavior = new EventId(8131, "YCal_CashSales_Not_FoundBehavior");
        public static readonly EventId YCal_CashSales_Calculate_Result_NULL = new EventId(8134, "YCal_CashSales_Calculate_Result_NULL");

        public static readonly EventId Enqueue_YCol_Exception = new EventId(9020, "Enqueue_YCol_Exception");
        public static readonly EventId Enqueue_YCal_Exception = new EventId(9021, "Enqueue_YCal_Exception");
        public static readonly EventId Enqueue_YBill_Exception = new EventId(9022, "Enqueue_YBill_Exception");

        public static readonly EventId Staging_BackGround_Service_Error_Add_Todo = new EventId(10020, "Staging_BackGround_Service_Error_Add_Todo");
        public static readonly EventId Staging_BackGround_Service_Success_Add_Todo = new EventId(10010, "Staging_BackGround_Service_Success_Add_Todo");
        public static readonly EventId Staging_BackGround_Service_StartExecuting = new EventId(10001, "Staging_BackGround_Service_StartExecuting");
        public static readonly EventId Staging_BackGround_Service_Error_Execution = new EventId(10021, "Staging_BackGround_Service_Error_Execution");
        public static readonly EventId Staging_BackGround_Service_Finished_Execution = new EventId(10002, "Staging_BackGround_Service_Finished_Execution");
        public static readonly EventId Staging_BackGround_Service_Success_Execution = new EventId(10011, "Staging_BackGround_Service_Success_Execution");

        public static readonly EventId Sync_FI_CashSale_Start = new EventId(11000, "Sync_FI_CashSale_Start");
        public static readonly EventId Sync_FI_CashSale_End_Success = new EventId(11010, "Sync_FI_CashSale_End_Success");
        public static readonly EventId Sync_FI_CashSale_End_Exception = new EventId(11020, "Sync_FI_CashSale_End_Exception");
        public static readonly EventId Sync_FI_CashSale_Loop_Error = new EventId(11021, "Sync_FI_CashSale_Loop_Error");
        public static readonly EventId Sync_FI_CashSale_Loop_No_Year = new EventId(11031, "Sync_FI_CashSale_Loop_No_Year");
        public static readonly EventId Sync_FI_CashSale_Loop_Notify = new EventId(11041, "Sync_FI_CashSale_Loop_Notify");


        public static readonly EventId Task_Behavior_Start_Calculate = new EventId(12100, "Task_Behavior_Start_Calculate");
        public static readonly EventId Task_Behavior_Finished_Calculate = new EventId(12110, "Task_Behavior_Finished_Calculate");
        public static readonly EventId Task_Behavior_Exception_Calculate = new EventId(12120, "Task_Behavior_Exception_Calculate");
        public static readonly EventId Task_Behavior_Add_Task_Request = new EventId(12000, "Task_Behavior_Add_Task_Request");
        public static readonly EventId Task_Behavior_Add_Task_Success = new EventId(12010, "Task_Behavior_Add_Task_Success");
        public static readonly EventId Task_Behavior_Add_Task_Fail = new EventId(12020, "Task_Behavior_Add_Task_Fail");
        public static readonly EventId Task_Behavior_Add_Task_Existing = new EventId(12001, "Task_Behavior_Add_Task_Existing");

        public static readonly EventId GdcApi_Response_Token = new EventId(13001, "GDC-Responsed-Token");
        public static readonly EventId GdcApi_Response_Token_PraseJson = new EventId(13002, "GDC-Responsed-Token-ParseJson");
        public static readonly EventId GdcApi_Response_Post = new EventId(13003, "GDC-Responsed-Post");
        public static readonly EventId GdcApi_Response_Post_PraseJson = new EventId(13004, "GDC-Responsed-Post-ParseJson");
    }

}