using DAL;
using SERVICES;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_DV_User
    {
        public static void InsertDV(string username)
        {
            // UN MÉTODO HORIZONTAL Y OTRO VERTICAL...
            DataTable table = DAL_DV_User.HashedRowUser(username);
            DAL_DV_User.InsertDV(table);
            //FALTA DVV, POR EJ:
            //DAL_DV_User.InsertDVH(table);
            //DAL_DV_User.InsertDVV(table);
        }

        public static void UpdateDV(string username)
        {
            DataTable table = DAL_DV_User.HashedRowUser(username);
            DAL_DV_User.UpdateDV(table);
        }
    }
}
