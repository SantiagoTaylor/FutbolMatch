using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICES
{
    public static class DatabaseBackup
    {
        public static void Backup(string backupFilePath)
        {
            DAL_DatabaseBackup.Backup(backupFilePath);
        }

        public static void Restore(string savePath)
        {
            DAL_DatabaseBackup.Restore(savePath);
        }
    }
}
