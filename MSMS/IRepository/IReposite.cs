using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSMS.Models;

namespace MSMS.IRepository
{
    public interface IReposite
    {
        //1)AdminLogin Controller
        //1.1) this Method is used to check whether the adimin is available or not
        Admin CheckAdmLogin(string UserName, string Password);

        //1.2) this Method is used to get the list of adimin
        List<Admin> GetAdminsList();

        //1.3) this Method is used to get the adimin by id
        Admin GetAdminByID(string id);

        //1.4)This method is used to add new OA to database 
        bool AddAdmin(Admin adm);

        //1.5)This method is used to Edit OA in database
        void EditAdmin(Admin admin);

        //1.6)This method is used to Delete OA in database
        void DeleteAdmin(string id);

        //1.7)This method is used to change OA password in database
        int ChangePassword(string AdminID, string Pwd);

        //2)OperationalAdmin Controller
        //2.1)This method is used to add new OA to database 
        int AddOwner(Owner_Registration adm);

        //2.2)This method is used to find OA from database
        Owner_Registration GetOwnerByID(string id);

        //2.3)This method is used to get list of Owners
        List<Owner_Registration> GetOwnerList();

        //2.4)This method is used to add new Store to database 
        bool AddStore(Store_Registration adm);

        //2.5)This method is used to find the store by store emailid
        Store_Registration GetStoreByID(string id);

        //2.6)This method is used to find the list of stores
        List<Store_Registration> GetStoreList();

        //2.7)This method is used to check the details of owner
        Owner_Registration CheckOwnerLogin(string UserName,string Password);

        //2.8)This method is used to find the stores of owner by ownerID
        List<Store_Registration> GetStoreByOwner(string OwnerId);

        //2.9)This method is used to change Owner password in database
        int OwnerChangePassword(string ownerID,string pwd);

        //3)User Profile
        //3.1)This method is used to get list of Customers
        List<Customer_Details> GetCustomersList();

        //3.2)This method is used to get list of Vendors
        List<Vender_Details> GetVendorsList();

        //3.3)This method is used to get list of Owners
        List<Pharma_Company_Details> GetCompanyList();

        //3.4)This method is used to add Customers
        bool AddCustomer(Customer_Details customerDetails);

        //3.5)This method is used to add Vendors
        bool AddVendors(Vender_Details venderDetails);

        //3.6)This method is used to add Company
        bool AddCompany(Pharma_Company_Details CompanyDetails);

    }
}
