using System;

namespace Retrieval.SDK
{
    public abstract class CustomPreference
    {
        private bool isEmpty;
        public bool IsEmpty => IsEmpty;

        private List<PreferenceProperty<string>> stringProperties;
        private List<PreferenceProperty<int>> intProperties;
        private List<PreferenceProperty<float>> floatProperties;

        protected void AddPreference(PreferenceProperty<string> property)
        {
            stringProperties.Add(property);
        }
        protected void AddPreference(PreferenceProperty<int> property)
        {
            intProperties.Add(property);
        }
        protected void AddPreference(PreferenceProperty<float> property)
        {
            floatProperties.Add(property);
        }
    }
}