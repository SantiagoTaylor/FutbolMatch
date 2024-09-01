using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    [Serializable]
    public class BE_Field
    {
        private int _fieldID;
        private string _fieldName;
        private int _size;
        private string _floorType;
        private int _establishmentID;

        public string FieldName { get => _fieldName; }
        public int Size { get => _size; }
        public string FloorType { get => _floorType; }
        public int FieldID { get => _fieldID; }
        public int EstablishmentID { get => _establishmentID; }

        public BE_Field(string fieldName, int size, string floorType, int establishmentID)
        {
            _fieldName = fieldName;
            _size = size;
            _floorType = floorType;
            _establishmentID = establishmentID;
        }
        public BE_Field(int id, string fieldName, int size, string floorType, int establishmentID)
        {
            _fieldID = id;
            _fieldName = fieldName;
            _size = size;
            _floorType = floorType;
            _establishmentID = establishmentID;
        }
        public BE_Field(DataRow r) {
            _fieldID = r.Field<int>("ID");
            _fieldName = r.Field<string>("Nombre");
            _size = r.Field<int>("Tamaño");
            _floorType = r.Field<string>("Piso");
            _establishmentID = 0;//por ahora 0
        }
        public BE_Field() { }
    }
}
