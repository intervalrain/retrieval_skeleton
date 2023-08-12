using System;
using Retrieval.SDK;
using System.Data;
using Retrieval.RetrievalForms.Container;
using DataTable = System.Data.DataTable;

namespace Retrieval.DataCore
{
    public static class Utility
    {
        private static List<TypeCode> _numericTypeCodess = new List<TypeCode>
        {
            TypeCode.Byte, TypeCode.Decimal, TypeCode.Double, TypeCode.Int16, TypeCode.Int32, TypeCode.Int64, TypeCode.SByte, TypeCode.Single, TypeCode.UInt16, TypeCode.UInt32, TypeCode.UInt64
        };
        public static bool IsNumeric(object? obj)
        {
            return (obj != null) && IsNumeric(obj.GetType());
        }

        private static bool IsNumeric(Type? type)
        {
            if (type == null)
            {
                return false;
            }
            TypeCode typeCode = Type.GetTypeCode(type);

            return _numericTypeCodess.Contains(typeCode);
        }
    }
}