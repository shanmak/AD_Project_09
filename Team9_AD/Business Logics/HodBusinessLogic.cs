using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team9_AD.HodClass;
using Team9_AD.Model;
using Team9_AD.WCF;
namespace Team9_AD.Business_Logics

{
    public class HodBusinessLogic
    {
       static Logic_University model = new Logic_University();
       static string Pending = "Pending";
        public static List<Employee_Request> getAllrequest(String Departid)
        {
            var list = model.Employee_Request.Where(x => x.Status==Pending && x.Department_ID== Departid).ToList();

            return list;
        }

        public static List<EmplyReqDetails> GetEmp_Request_Items(string Id)
        {
            try
            {
                int id = Convert.ToInt32(Id);

                var list = model.Emp_Request_items.Where(x => x.Request_ID.Equals(id)).Select(x => new { x.Inventory.Category, x.Inventory.Description, x.Quantity,x.Comments,x.Status });

                List<EmplyReqDetails> reqlist = new List<EmplyReqDetails>();

                foreach (var v in list)
                {
                    reqlist.Add(new EmplyReqDetails(v.Category, v.Description, v.Quantity,v.Comments,v.Status));
                }

                return reqlist;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Employee GetEmployees(string id)
        {
            return model.Employees.Where(c => c.Employee_ID==id).FirstOrDefault();
        }

        public static List<string> GetEmployeesall(string id)
        {
          var list= model.Employees.Where(c => c.Department_ID == id && c.Employee_Role != "HOD").ToList<Employee>();

            List<string> employeelist = new List<string>();

            foreach(var v in list)
            {
                employeelist.Add(v.Employee_Name);
            }

            return employeelist;
        }

        

    
    }
}