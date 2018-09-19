using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Team9_AD.Business_Logics;
using Team9_AD.Model;
using System.Collections;
using Team9_AD.HodClass;
using Team9_AD.AddClass;

using Team9_AD.AndroidBiz;
using System.Net.Mail;

namespace Team9_AD.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<RepClass> listdis(string id)
        {
            try
            {
                var list = BusinessLogic.repAcks(id);

                var newlist = list.Select(y => new RepClass(y.Category, y.Discription, y.RequestQuantity, y.DeliveredQuantity)).ToList<RepClass>();

                return newlist;
                // return newlist;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<WCF_Store_Request> GetListOfRequest()
        {
           List<Store_Request> stores= BusinessLogic.store_Requests();

            List<WCF_Store_Request> wcf_request = new List<WCF_Store_Request>();
            foreach(var v in stores)
            {


                wcf_request.Add(new WCF_Store_Request(v.StoreRequest_ID, v.Department.Department_Name, v.Employee_ID, v.Request_Date,v.Status));
            }

            return wcf_request;
        }

       

        public WCF_Employee PassEmp(String empid,String pass)
        {
            Employee emp= BusinessLogic.GetPassEmp(empid, pass);

             return new WCF_Employee(emp.Employee_ID, emp.Employee_Name, emp.Department_ID, emp.Employee_Role, emp.Password,emp.Email);

        }

        public List<WCF_Store_Request_items> Store_Request_Items(string requestId)
        {
            List<Store_Request_items> request_Items = BusinessLogic.Store_Request_Items(requestId);

            List<WCF_Store_Request_items> store_Request_Items = new List<WCF_Store_Request_items>();
            foreach(var v in request_Items)
            {
                store_Request_Items.Add(new WCF_Store_Request_items(v.StoreRequest_ID,v.Item_Number, v.Description, v.Req_Quantity, v.Delv_Quantity, v.Pend_Quantity, v.Status));

            }

            return store_Request_Items;
        }

        public String Update(WCF_Inventory inventory)
        {
           
            try
            {
               
                    Inventory new_inventory = new Inventory
                    {
                        Item_Number = inventory.Item_Number,
                        Description = inventory.Description,
                        Reorder_level = inventory.Reorder_level,
                        Reorder_qty = inventory.Reorder_qty,
                        Price = inventory.Price,
                        Unit_Measure = inventory.Unit_Measure,
                        Quantity = inventory.Quantity,
                        Bin_number = inventory.Bin_number,
                        Supplier_ID_1 = inventory.Suppiler_ID_1,
                        Supplier_ID_2 = inventory.Suppiler_ID_2,
                        Supplier_ID_3 = inventory.Suppiler_ID_3

                    };
                    
                string status= BusinessLogic.UpdateInventory(new_inventory);


                return   status;
                
               
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }

        public List<string> listdepartment()
        {
            return BusinessLogic.listdepartment();
        }

        public List<WCF_Store_Request> GetListOfRequest_depart(string selectDepartment)
        {
            List<Store_Request> stores = BusinessLogic.GetListOfRequest_depart(selectDepartment);

            List<WCF_Store_Request> wcf_request = new List<WCF_Store_Request>();

            foreach (var v in stores)
            {
                   

                wcf_request.Add(new WCF_Store_Request(v.StoreRequest_ID, v.Department_ID, v.Employee_ID, v.Request_Date,v.Status));
            }

            return wcf_request;
        }

        public List<WCF_Store_Request> StationaryRetrievalList()
        {
            return null;
        }

        public List<WarehouseRetrivelList> WarehouRetrievelList()
        {

          List<WarehouseRetrivelList> arrayLists= BusinessLogic.WarehouseRetrievelList();

           

            return arrayLists;
            
        }

        public string Updatewarehouse(List<WCF_updateWarehouseAndDamage> updateWareAnddamge)
        {
            try
            {
                List<UpdateWarehouseAndDamage> updates = new List<UpdateWarehouseAndDamage>();

                  foreach(var v in updateWareAnddamge)
                {
                    updates.Add(new UpdateWarehouseAndDamage
                        (
                        v.Item_Number,
                        v.Category,
                        v.Description,
                        v.Bin_number,
                        v.Req_Qunty,
                        v.Available,
                        v.Collected_qunty,
                        v.Damage_qnty
                        ));                
                 }
                string result = BusinessLogic.Updatewarehouse(updates);

                return result;

            }
            catch (Exception)
            {
                return "error in services";
            }
        }

        public List<WCF_Employee_Request> getEmployeeReq(string DepartId)
        {
           List<Employee_Request> list= HodBusinessLogic.getAllrequest(DepartId);

            List<WCF_Employee_Request> wcflist = new List<WCF_Employee_Request>();

            foreach( var v in list)
            {
                wcflist.Add(new WCF_Employee_Request(v.Request_ID, v.Department_ID, v.Employee_ID, v.Date_of_Request,v.Status,v.Employee.Employee_Name));

            }

            return wcflist;
        }

        public List<EmplyReqDetails> GetEmp_Request_Items(string requestId)
        {
            try
            {
                return HodBusinessLogic.GetEmp_Request_Items(requestId);

            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public WCF_Employee GetEmployeesdetails(string id)
        {
            Employee employee= HodBusinessLogic.GetEmployees(id);

             return  new WCF_Employee(employee.Employee_ID, employee.Employee_Name, employee.Department_ID, employee.Employee_Role, employee.Password,employee.Email);

        }

        public List<string> GetEmployeesall(string id)
        {
            return HodBusinessLogic.GetEmployeesall(id);
        }


        public string UpdateDamage(WCF_DamageUpdate damageUpdate)
        {
            try
            {
                DamageUpdate damage = new DamageUpdate
                {
                    Location = damageUpdate.Location,
                    Category = damageUpdate.Category,
                    Description = damageUpdate.Description,
                    Quantity = damageUpdate.Quantity,
                    Employee_ID = damageUpdate.Employee_ID
                };


                string result = BusinessLogic.updateDamage(damage);


                return result;

            }
            catch (Exception)
            {
                return "error";
            }
        }










        //Android

        public List<WCF_Employee> GetEmployeeListbyDeptID(String DeptID)
        {
            List<Employee> empl = BusinessLogicAndroid.GetEmployeeListbyDeptID(DeptID);

            List<WCF_Employee> EmplList = new List<WCF_Employee>();

            foreach (var v in empl)
            {
                EmplList.Add(new WCF_Employee(v.Employee_ID, v.Employee_Name, v.Department_ID, v.Employee_Role, v.Password, v.Email));
            }
            return EmplList;
        }

        public WCF_Department GetRepbyDeptID(String DeptID)
        {
            Department dept = BusinessLogicAndroid.GetRepbyDeptID(DeptID);

            return new WCF_Department(dept.Department_ID, dept.Department_Name, dept.Department_Head, dept.Phone_Num, dept.Fax_Num, dept.Collection_Point, dept.Representative_ID);
        }

        public WCF_Employee GetempbyID(String empid)
        {
            Employee employee = BusinessLogicAndroid.GetEmpbyID(empid);

            return new WCF_Employee(employee.Employee_ID, employee.Employee_Name, employee.Department_ID, employee.Employee_Role, employee.Password, employee.Email);

        }

        public String UpdateRep(WCF_Department department)
        {
            try
            {
                Department new_department = new Department
                {
                    Department_ID = department.Department_ID,
                    Department_Name = department.Department_Name,
                    Department_Head = department.Department_Head,
                    Phone_Num = department.Phone_Num,
                    Fax_Num = department.Fax_num,
                    Collection_Point = department.Collection_Point,
                    Representative_ID = department.Representative_ID
                };

                string status = BusinessLogicAndroid.UpdateRep(new_department);

                return status;
            }
            catch (Exception e)
            {
                return e.StackTrace;
            }
        }

        public WCF_Approver CurrentDelg(String Dept_ID)
        {
            Approver approver = BusinessLogicAndroid.CurrentDelg(Dept_ID);

            return new WCF_Approver(approver.ID, approver.Department_ID, approver.Employee_ID, approver.Start_Date, approver.End_Date, approver.Status);

        }

        public String AddApprovers(WCF_Approver wCF_Approver)
        {
            try
            {
                Approver approver = new Approver
                {
                    //ID = wCF_Approver.ID,
                    Department_ID = wCF_Approver.Department_ID,
                    Employee_ID = wCF_Approver.Employee_ID,
                    Start_Date = wCF_Approver.Start_Date,
                    End_Date = wCF_Approver.End_Date,
                    Status = wCF_Approver.Status
                };

                String status = BusinessLogicAndroid.AddApprovers(approver);

                return status;

            }
            catch (Exception e)
            {
                return e.StackTrace;
            }


        }

        //Revoke Delgate

        public String RevokeDelg(WCF_Approver wCF_Approver)
        {
            try
            {
                Approver approver = new Approver
                {
                    ID = wCF_Approver.ID,
                    Department_ID = wCF_Approver.Department_ID,
                    Employee_ID = wCF_Approver.Employee_ID,
                    Start_Date = wCF_Approver.Start_Date,
                    End_Date = wCF_Approver.End_Date,
                    Status = wCF_Approver.Status
                };

                String status = BusinessLogicAndroid.RevokeDelg(approver);

                return status;

            }
            catch (Exception e)
            {
                return e.StackTrace;
            }


        }

        //Send Delegate Mail

        public void sendMailAnd(string empid, string name, String startdate, String enddate)
        {
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = false;
            mail.To.Add(getemail(empid));
            mail.Subject = "Chosen as Delegate";
            mail.Body = "Hi " + name + "," + Environment.NewLine + "You have been chosen as delegate from " + startdate + " to " + enddate + "." + Environment.NewLine + "Best Regards," + Environment.NewLine + "Department Head ";
            SmtpClient smtp = new SmtpClient();
            mail.From = new MailAddress("sgsuren1118@gmail.com", "Surendran");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("sgsuren1118@gmail.com", "littleflower");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
        public string getemail(string empid)
        {
            Logic_University model = new Logic_University();
            string v = model.Employees.Where(x => x.Employee_ID.Equals(empid)).FirstOrDefault<Employee>().Email;
            return v;
        }

        public string Android_hod_Appr(List<WCF_Android_Appr> WCF_Android_Appr)
        {
            String stat = AndroidBiz.BusinessLogicAndroid.Android_hod_Appr(WCF_Android_Appr);

            return stat;
        }


        public WCF_Supplier GetSupplier(string id)
        {
            Supplier supp = BusinessLogic.getSupplier(id);

            return new WCF_Supplier(supp.Supplier_ID, supp.Supplier_Name, supp.Contact_Name, supp.Phone_Num, supp.Fax_Num, supp.Address);
        }

        public List<WCF_Supplier> GetSupplierList()
        {

            List<Supplier> supplier = BusinessLogic.SupplierList();
            List<WCF_Supplier> wcf_supplier = new List<WCF_Supplier>();
            foreach (var v in supplier)
            {
                wcf_supplier.Add(new WCF_Supplier(v.Supplier_ID, v.Supplier_Name, v.Contact_Name, v.Phone_Num, v.Fax_Num, v.Address));
            }
            return wcf_supplier;
        }
    }
}
