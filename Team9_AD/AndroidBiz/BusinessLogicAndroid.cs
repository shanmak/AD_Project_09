using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team9_AD.AddClass;
using Team9_AD.Model;
using Team9_AD.WCF;

namespace Team9_AD.AndroidBiz
{
    public class BusinessLogicAndroid
    {
        //Get Employee by Employee ID

        public static Employee GetEmpbyID(String username)
        {
            try
            {
                Logic_University db = new Logic_University();
                var emp = db.Employees.Where(x => (x.Employee_ID == (username))).First();
                return emp;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //List Employees by Department id except HOD
        public static List<Employee> GetEmployeeListbyDeptID(String DeptID)
        {
            try
            {
                Logic_University db = new Logic_University();
                var empl = db.Employees.Where(c => c.Department_ID.Equals(DeptID) && c.Employee_Role != "HOD").ToList<Employee>();
                return empl;
            }
            catch (Exception)
            {
                return null;
            }
        }

        //Get Department row by Deptartment id from which we will be taking the representative id 
        public static Department GetRepbyDeptID(String DeptID)
        {
            try
            {
                Logic_University db = new Logic_University();
                var dept = db.Departments.Where(c => c.Department_ID == DeptID).First();
                return dept;

            }
            catch (Exception)
            {
                return null;
            }
        }

        //Update Representative in department table 
        public static string UpdateRep(Department department)
        {
            try
            {
                using (Logic_University m = new Logic_University())
                {
                    Department dept = m.Departments.Where(x => x.Department_ID == department.Department_ID).FirstOrDefault();
                    dept.Representative_ID = department.Representative_ID;
                    m.SaveChanges();

                    Employee emp = m.Employees.Where(c => c.Department_ID == department.Department_ID && c.Employee_Role == "Employee-Rep").FirstOrDefault();
                    emp.Employee_Role = "Employee";
                    m.SaveChanges();

                    Employee emp1 = m.Employees.Where(c => c.Department_ID == department.Department_ID && c.Employee_ID == department.Representative_ID).FirstOrDefault();
                    emp1.Employee_Role = "Employee-Rep";
                    m.SaveChanges();

                    return "BiZ_true";


                }
            }
            catch (Exception)
            {
                return "error";
            }

        }

        //Pull current delegate by department id

        public static Approver CurrentDelg(string deptid)
        {
            try
            {
                using (Logic_University m = new Logic_University())
                {
                    Approver result = m.Approvers.Where(x => x.Department_ID.Equals(deptid) && x.Status == "Active").FirstOrDefault();
                    return result;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static String AddApprovers(Approver approver)
        {
            try
            {
                if (CurrentDelg(approver.Department_ID) == null)
                {
                    Logic_University db = new Logic_University();
                    db.Approvers.Add(approver);
                    db.SaveChanges();
                    return "true";
                }
                else
                    return "error";
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public static string RevokeDelg(Approver approver)
        {
            try
            {
                using (Logic_University m = new Logic_University())
                {
                    Approver appr = m.Approvers.Where(x => x.ID == approver.ID).FirstOrDefault();
                    appr.Status = "Inactive";
                    m.SaveChanges();
                    return "BiZ_true";
                }
            }
            catch (Exception)
            {
                return "error";
            }
        }

        public static string Android_hod_Appr(List<WCF_Android_Appr> list)
        {
            try
            {
                int request_id = int.Parse(list.Select(x => x.Request_id).First().ToString());
                String deptid = list.Select(x => x.Department_ID).First().ToString();
                String empid = list.Select(x => x.HOD_ID).First().ToString();
                DateTime date = DateTime.Today;
                List<Android_Appr> hodReqItems = list.Select(x => new Android_Appr(x.Request_id, x.Quantity, x.Status, x.Comments, x.Description, x.HOD_ID, x.Department_ID)).ToList<Android_Appr>();


                using (Logic_University m = new Logic_University())
                {
                    List<Android_Appr> androidList = list.Select(x => new Android_Appr(x.Request_id, x.Quantity, x.Status, x.Comments, x.Description, x.HOD_ID, x.Department_ID)).ToList<Android_Appr>();
                    
                    foreach (Android_Appr a in androidList)
                    {
                        if (a.Status == "Approved")
                        {

                            var item = (from z in m.Inventories where z.Description == a.Description select z.Item_Number).SingleOrDefault();
                            
                            string status1 = a.Status;
                            string comment1 = a.Comments;
                            int req = int.Parse(a.Request_id);
                         

                            updateresponse(status1, comment1, item,req);
                           
                        }
                        else
                        {

                            string itemID = m.Inventories.Where(x => x.Description == a.Description).Select(y => y.Item_Number).FirstOrDefault();
                            string status1 = a.Status;
                            string comment2 = a.Comments;
                            int req = int.Parse(a.Request_id);
                            
                            updateresponse(status1, comment2, itemID,req);

                        }
                    }

                     
                    updateEmplyeeRequest(request_id);


                    insertrequesttostore(deptid, empid, date, hodReqItems);
                }
                
            }
            catch(Exception e)
            {
                return "error";
            }
            return null;
        }

        public static void updateresponse(string status, string comment, string itemID,int req_id)
        {

            using (Logic_University m = new Logic_University())
            {
                string itemnum = itemID;
                {
                    List<Emp_Request_items> n = m.Emp_Request_items.Where(x => x.Request_ID == req_id && x.Item_Number.Equals(itemnum)).ToList<Emp_Request_items>();
                    foreach (var i in n)
                    {
                        i.Status = status;
                        if (status == "Rejected")
                        {
                            i.Comments = comment;
                        }
                    }
                }

                m.SaveChanges();
            }
        }

        public static void updateEmplyeeRequest(int Id)
        {
            using (Logic_University m = new Logic_University())
            {
                var empreq = m.Employee_Request.Where(x => x.Request_ID == Id).FirstOrDefault();
                empreq.Status = "Completed";
                m.SaveChanges();
            }
        }

        public static void insertrequesttostore(string deptid, string empid, DateTime date, List<Android_Appr> reqItems)  //,date
        {
            using (Logic_University m = new Logic_University())
            {

                Store_Request sr = new Store_Request()
                {
                    Department_ID = deptid,
                    Employee_ID = empid,
                    Request_Date = date,
                    Status = "Pending"
                };

                m.Store_Request.Add(sr);

                m.SaveChanges();

                Store_Request storeid = m.Store_Request.OrderByDescending(x => x.StoreRequest_ID).Take(1).FirstOrDefault();


                foreach (var v in reqItems)
                {
                    Store_Request_items store_Request = new Store_Request_items();
                    String itm = (from z in m.Inventories where z.Description == v.Description select z.Item_Number).SingleOrDefault();

                    store_Request.StoreRequest_ID = storeid.StoreRequest_ID;
                    store_Request.Item_Number = itm;
                    store_Request.Description = v.Description;
                    store_Request.Req_Quantity = Convert.ToInt32(v.Quantity);
                    store_Request.Pend_Quantity = Convert.ToInt32(v.Quantity);
                    store_Request.Status = "Pending";

                    m.Store_Request_items.Add(store_Request);

                    m.SaveChanges();
                }

            }

        }

    }
}