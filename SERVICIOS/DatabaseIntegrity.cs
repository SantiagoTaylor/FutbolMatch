using DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace SERVICES
{
    public static class DatabaseIntegrity
    {
        private static readonly Tuple<string, string> tb_User = new Tuple<string, string>("tb_User", "tb_DVH_User");

        //false = mal
        //true = bien
        #region Horizontal integrity
        public static Dictionary<(string, string), List<string>> HorizontalIntegrity()
        {
            List<Tuple<string, string>> tableList = new List<Tuple<string, string>>
            {
                tb_User
            };

            Dictionary<(string, string), List<string>> tables = new Dictionary<(string, string), List<string>>();
            foreach (var tupla in tableList)
            {
                DataTable table1, table2;
                table1 = DAL_DatabaseIntegrity.GetHashedTable(tupla.Item1); // la tabla "original" concatenada y hasheada
                table2 = DAL_DatabaseIntegrity.GetDVHTable(tupla.Item2); // la correspondiente tabla de DVH
                tables.Add((tupla.Item1, tupla.Item2), CompareTables(table1, table2)); // se comparan
            }
            return tables;
        }

        private static List<string> CompareTables(DataTable table1, DataTable table2)
        {
            List<string> errors = new List<string>();

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                for (int j = 0; j < table1.Columns.Count; j++)
                {
                    if (!table1.Rows[i][j].Equals(table2.Rows[i][j]))
                    {
                        for (int k = 0; k < table2.Columns.Count - 1; k++)
                        {
                            errors.Add(table1.Rows[i][k].ToString());
                        }
                    }
                }
            }
            return errors;
        }

        public static void RecalculateDigits()
        {
            var results = HorizontalIntegrity();
            foreach (var tablePair in results)
            {
                if (tablePair.Value.Count != 0)//false = falla de integridad
                {
                    DAL_DatabaseIntegrity.RecalculateDigits(tablePair.Key);
                }
            }
        }
        #endregion
    }
}
