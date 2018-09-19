using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Team9_AD.App_Code;
using Team9_AD.HodClass;
using System.Collections;


namespace Team9_AD.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(UriTemplate = "list/{departmentID}", ResponseFormat = WebMessageFormat.Json)]
        List<RepClass> listdis(string departmentID);

       

        [OperationContract]
        [WebGet(UriTemplate = "/login/{empid}/{pass}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Employee PassEmp(String empid, String pass);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Update", Method = "POST",ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
         string Update(WCF_Inventory  wCF_Inventory);

        [OperationContract]
        [WebGet(UriTemplate = "/listClerkRequest", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Store_Request> GetListOfRequest();

        [OperationContract]
        [WebGet(UriTemplate = "/listClerkRequest/{StoreRequestID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Store_Request_items> Store_Request_Items(string StoreRequestID);

        [OperationContract]
        [WebGet(UriTemplate = "/listDepartment", ResponseFormat = WebMessageFormat.Json)]
        List<String> listdepartment();


        [OperationContract]
        [WebGet(UriTemplate = "/selectDepartment/{selectDepartment}",  ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Store_Request> GetListOfRequest_depart(string selectDepartment);

        [OperationContract]
        [WebGet(UriTemplate = "/Stationary_Retrieval_List", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Store_Request> StationaryRetrievalList();

        [OperationContract]
        [WebGet(UriTemplate = "/WarehouseRetrievelList", ResponseFormat = WebMessageFormat.Json)]
        List<WarehouseRetrivelList> WarehouRetrievelList();

        [OperationContract]
        [WebInvoke(UriTemplate = "/Updatewarehouse", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string Updatewarehouse(List<WCF_updateWarehouseAndDamage> WCF_WareAndDamageUpdate);

        [OperationContract]
        [WebGet(UriTemplate = "/HodViewPage/{DepartId}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Employee_Request> getEmployeeReq(String DepartId);


        [OperationContract]
        [WebGet(UriTemplate = "/HodDetailsPage/{requestId}", ResponseFormat = WebMessageFormat.Json)]
        List<EmplyReqDetails> GetEmp_Request_Items(string requestId);


        [OperationContract]
        [WebGet(UriTemplate = "/employeedetails/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Employee GetEmployeesdetails(string id);


        [OperationContract]
        [WebGet(UriTemplate = "/departmentemployeelist/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<string> GetEmployeesall(string id);



        [OperationContract]
        [WebInvoke(UriTemplate = "/DamageUpdate", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        string UpdateDamage(WCF_DamageUpdate damageUpdate);


       // android services

        [OperationContract]
        [WebGet(UriTemplate = "/HOD/Employee_List/{DeptID}", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Employee> GetEmployeeListbyDeptID(String DeptID);

        [OperationContract]
        [WebGet(UriTemplate = "/HOD/DeptRep/{DeptID}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Department GetRepbyDeptID(String DeptID);


        [OperationContract]
        [WebGet(UriTemplate = "/employee/{empid}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Employee GetempbyID(String empid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/HOD/DeptRep/Update", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        String UpdateRep(WCF_Department wCF_Department);

        [OperationContract]
        [WebGet(UriTemplate = "/HOD/Delegate/{deptid}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Approver CurrentDelg(String deptid);

        [OperationContract]
        [WebInvoke(UriTemplate = "/HOD/DeptDelg/Update", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        String AddApprovers(WCF_Approver wCF_Approver);

        [OperationContract]
        [WebInvoke(UriTemplate = "/HOD/DeptDelg/Revoke", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        String RevokeDelg(WCF_Approver wCF_Approver);

        [OperationContract]
        [WebGet(UriTemplate = "/HOD/DeptDelg/mail/{empid}/{name}/{startdate}/{enddate}", ResponseFormat = WebMessageFormat.Xml)]
        void sendMailAnd(String empid, String name, String startdate, String enddate);


        //Update Approval or Rejection HOD 
        [OperationContract]
        [WebInvoke(UriTemplate = "/HOD/Approval", Method = "POST", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string Android_hod_Appr(List<WCF_Android_Appr> WCF_Android_Appr);


        [OperationContract]

        [WebGet(UriTemplate = "/SupplierList", ResponseFormat = WebMessageFormat.Json)]
        List<WCF_Supplier> GetSupplierList();

        [OperationContract]
        [WebGet(UriTemplate = "/supplierdetails/{id}", ResponseFormat = WebMessageFormat.Json)]
        WCF_Supplier GetSupplier(string id);
    }

}
