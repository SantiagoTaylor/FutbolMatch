using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Field
    {
        private string _fieldName;
        private int _size;
        private string _floorType;
        private int _fieldID;
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
    }
}
