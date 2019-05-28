using System;
using Newtonsoft.Json;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Value Object Base Object of Type T
    /// </summary>
    public class ValueObjectBase<T> : IValueObjectBase<T>
    {
        public ValueObjectBase()
        {

        }

        protected T _value;
        /// <summary>
        /// The ReadOnly Value object property.
        /// The Private Set is used for Serialization purposes only. Do not remove the private set.
        /// </summary>
        /// <value>The value.</value>
        [JsonProperty("Value")]
        public T Value { get { return _value; } private set { _value = value; } }

    }
}
