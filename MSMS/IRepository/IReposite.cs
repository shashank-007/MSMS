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
        void AddOwner(Owner_Registration adm);

        //2.2)This method is used to add new OA to database
        Owner_Registration GetOwnerByID(string id);





    }
}
