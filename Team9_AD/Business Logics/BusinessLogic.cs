using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Team9_AD.WCF;
using Team9_AD.AddClass;

using Team9_AD.Model;
using System.Web.Security;

namespace Team9_AD.Business_Logics
{
    public class BusinessLogic
    {

        static string Pending = "Pending";
        public static Employee GetPassEmp(String username,String pass)
        {
            try
            {
                Logic_University db = new Logic_University();

                var emp = db.Employees.Where(x => (x.Employee_ID.Equals(username) && x.Password.Equals(pass))).First();
                return emp;

                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public static string GetHashed(string password, string salt)
        {
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(password + salt, "SHA1");
            return hashedPwd;
        }


        public static List<RepAck> repAcks(string departid)
        {
            try
            {
                Logic_University model = new Logic_University();
                List<Disbursement_List> singlist = model.Disbursement_List.Where(x => x.Department_ID == departid && x.Status == "Pending").ToList();

                List<Disbursement_List_dtl> list = new List<Disbursement_List_dtl>();

                foreach (var v in singlist)
                {

                    list.AddRange(model.Disbursement_List_dtl.Where(x => x.Disburse_ID == v.Disburse_ID).ToList());
                }

                var list2 = list.GroupBy(x => new { x.Item_number, x.Discription, x.Inventory }).Select(x => new { Category = x.Key.Inventory.Category, Discription = x.Key.Discription, RequestQuantity = x.Sum(y => y.req_qunty), DeliveredQuantity = x.Sum(y => y.Quantity) }).ToList();

                List<RepAck> acks = list2.Select(x => new RepAck(x.Category, x.Discription, x.RequestQuantity, x.DeliveredQuantity)).ToList<RepAck>();
                return acks;

                
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string UpdateInventory(Inventory inventory)
        {
            try
            {
                using (Logic_University m = new Logic_University())
                {
                    m.Inventories.Add(inventory);
                    m.SaveChanges();
                    return "BiZ_true";
                }
            }catch(Exception )
            {
                return "error";
            }

        }

        public static List<Store_Request> store_Requests()
        {
            try
            {
                using(Logic_University m = new Logic_University())
                {
                    return m.Store_Request.Where(x => x.Status.Equals(Pending)).ToList();
                }
            }catch(Exception)
            {
                return null;
            }
        }

        public static List<Store_Request_items> Store_Request_Items(string Id)
        {
            try
            {
                using(Logic_University m = new Logic_University())
                {
                    int id = Convert.ToInt32(Id);
                    return m.Store_Request_items.Where(x => x.StoreRequest_ID.Equals(id) && x.Status.Equals("Pending")).ToList<Store_Request_items>();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static List<string> listdepartment()
        {
            List<String> Departmentlist = new List<string>();
            using(Logic_University m = new Logic_University())
            {
               var departmentlist= m.Departments.ToList<Department>();

              foreach(var list in departmentlist)
                {
                    Departmentlist.Add(list.Department_Name);
                }
                return Departmentlist;
            }
        }


        public static List<Store_Request> GetListOfRequest_depart(string department)
        {
            using (Logic_University m = new Logic_University())
            {
                var dept = m.Departments.Where(x => x.Department_Name.Equals(department)).FirstOrDefault<Department>();

                string depart_id = dept.Department_ID;

                return m.Store_Request.Where(x => x.Department_ID.Equals(depart_id) && x.Status=="Pending").ToList<Store_Request>();

            }

        }

        public static List<Store_Request_items> StationaryRetrievalList()
        {
            using (Logic_University m = new Logic_University())
            {
              var resullt=  m.Store_Request_items.Where(x => x.Status.Equals("Pending")).GroupBy(rd => rd.Item_Number, rd => rd.Req_Quantity, (item, qunty) => new
                {
                    Item_Number = item,
                    Req_Quantity = qunty.Sum()

                });

                return null;
            }
        }


        public static List<WarehouseRetrivelList> WarehouseRetrievelList()
        {
           
            

            using (Logic_University lg = new Logic_University())
            {
                string test = "Pending";


                var result3 = lg.Store_Request.Where(x => x.Status.Equals(test)).Join(lg.Store_Request_items, c => c.StoreRequest_ID, o => o.StoreRequest_ID, (c, o) => new { c, o }).Where(x=> x.o.Status=="Pending").GroupBy(gd => new
                { gd.o.Item_Number, gd.o.Inventory }).Select(y => new
                { y.Key.Item_Number, y.Key.Inventory.Category, y.Key.Inventory.Description, y.Key.Inventory.Bin_number, Req_Qunty = y.Sum(a => a.o.Pend_Quantity), Available = y.Key.Inventory.Quantity }).ToList();

                var list = result3.Select(x => new WarehouseRetrivelList(x.Item_Number, x.Category, x.Description, x.Bin_number, (int)x.Req_Qunty, (int)x.Available)).ToList();

                return list;
            }

           
        }



        public static string Updatewarehouse(List<UpdateWarehouseAndDamage> list)
        {
            string wareupdat;
            try
            {
                using (Logic_University m = new Logic_University())
                {

                    if (list.Count != 0)
                    {
                        Wrehse_Trans trans = new Wrehse_Trans();
                    //    trans.Trans_ID = 1;
                        trans.Employee_ID = "STR003";
                        trans.Trans_Date = DateTime.Now;

                        m.Wrehse_Trans.Add(trans);
                        m.SaveChanges();
                        foreach (var v in list)
                        {

                            if (!v.Collected_qunty.Equals(0))
                            {

                                Wrehse_Trans_Dtl trans_Dtl = new Wrehse_Trans_Dtl();
                             //   trans_Dtl.Trans_ID = 1;
                                trans_Dtl.Item_number = v.Item_Number;
                                trans_Dtl.Retrived_Qunty = v.Collected_qunty;
                                trans_Dtl.Available_Qunty = v.Collected_qunty;

                                m.Wrehse_Trans_Dtl.Add(trans_Dtl);
                                m.SaveChanges();
                            }

                        }
                    }

                    wareupdat = "Update success";
                }


                
                return wareupdat;
            }
            catch (Exception)
            {
                return "error in biz";
            }
        }



        public static string updateDamage(DamageUpdate damage)
        {
            using (Logic_University model = new Logic_University())
            {
                Dmg_Goods_Dtl dmg_Goods = new Dmg_Goods_Dtl();


              var item=  model.Inventories.Where(x => x.Category == damage.Category).FirstOrDefault();

                dmg_Goods.Item_number = item.Item_Number;
                dmg_Goods.Damage_Qnty = damage.Quantity;
                dmg_Goods.Location = damage.Location;
                dmg_Goods.Employee_ID = damage.Employee_ID;
                dmg_Goods.Details = "Pending";
                dmg_Goods.Dmg_Date = DateTime.Now;

                model.Dmg_Goods_Dtl.Add(dmg_Goods);
                model.SaveChanges();

                return "done";
               
            }

        }


        public static Supplier getSupplier(string id)
        {

            try
            {
                using (Logic_University lg = new Logic_University())
                {
                    Supplier s = lg.Suppliers.Where(x => x.Supplier_ID == id).FirstOrDefault();
                    return s;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }


        public static List<Supplier> SupplierList()
        {
            List<Supplier> list = new List<Supplier>();
            try
            {
                using (Logic_University lg = new Logic_University())
                {
                    return lg.Suppliers.ToList<Supplier>();
                }
               
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}