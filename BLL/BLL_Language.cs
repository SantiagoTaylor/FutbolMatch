﻿using DAL;
using System.Data;

namespace BLL
{
    public static class BLL_Language
    {
        public static DataTable GetLanguages()
        {
            return DAL_Language.GetLanguages();
        }
        public static DataTable GetAllWebforms()
        {
            return DAL.DAL_Language.GetAllWebforms();
        }
    }
}
