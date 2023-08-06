using System;

namespace Retrieval.SDK
{
    public sealed class PreferenceProperty<T>
    {
        public string Name { get; set; }
        public PreferenceUsage Usage { get; set; }
        public T Value { get; set; }
        public Type ValueType { get; set; }

        public PreferenceProperty(string name, PreferenceUsage usage, T value, Type valueType)
        {
            Name = name;
            Usage = usage;
            Value = value;
            ValueType = valueType;
        }

        public void OnValueChanged()
        {
        }

        public void Reset()
        {
        }

        public void UndoChanges()
        {
        }

        public class PreferenceUsage
        {
        }
    }
}