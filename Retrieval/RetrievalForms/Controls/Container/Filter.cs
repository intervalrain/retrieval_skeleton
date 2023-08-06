using System;

namespace Retrieval.RetrievalForms.Controls.Container
{
    public class Filter
    {
        private Field _field;
        private object _value;

        public Filter(Field field, object value)
        {
            _field = field;
            _value = value;
        }

        public string GetQuery()
        {
            return "";
        }
    }
}