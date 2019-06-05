using System;
using System.Runtime.Serialization;

namespace Task9
{
    /// <summary>
    /// The class has properties of currency.
    /// </summary>
    [DataContract]
    [Serializable()]
    public class Currency
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public Currency() { }

        /// <summary>
        /// Constructor of Currency.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public Currency(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
