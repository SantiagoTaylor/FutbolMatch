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
        public static Dictionary<(string, string), bool> HorizontalIntegrity()
        {
            List<Tuple<string, string>> tableList = new List<Tuple<string, string>>
            {
                tb_User
            };

            Dictionary<(string, string), bool> tables = new Dictionary<(string, string), bool>();
            foreach (var tupla in tableList)
            {
                DataTable table1, table2;
                table1 = DAL_DatabaseIntegrity.GetHashedTable(tupla.Item1); // la tabla "original" concatenada y hasheada
                table2 = DAL_DatabaseIntegrity.GetDVHTable(tupla.Item2); // la correspondiente tabla de DVH
                tables.Add((tupla.Item1, tupla.Item2), CompareTables(table1, table2)); // se comparan
            }
            return tables;
        }

        private static bool CompareTables(DataTable table1, DataTable table2)
        {
            if (table1.Rows.Count != table2.Rows.Count)
            {
                return false; // Diferente número de filas
            }

            for (int i = 0; i < table1.Rows.Count; i++)
            {
                for (int j = 0; j < table1.Columns.Count; j++)
                {
                    if (!table1.Rows[i][j].Equals(table2.Rows[i][j]))
                    {
                        return false; // Los datos en la celda no son iguales
                    }
                }
            }
            return true;
        }

        public static void RecalculateDigits()
        {
            var results = HorizontalIntegrity();
            foreach (var tablePair in results)
            {
                if (tablePair.Value == false)//false = falla de integridad
                {
                    DAL_DatabaseIntegrity.RecalculateDigits(tablePair.Key);
                }
            }
        }
        #endregion
    }
}
