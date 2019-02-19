using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExemploVortice.Service.Infra
{
    public abstract class APIResponseBase<T> where T : new()
    {
        public Error Error { get; set; }
        public bool HasError => !string.IsNullOrEmpty(Error.Description);
        public T Response { get; set; }

        public APIResponseBase()
        {
            Response = new T();
        }
    }

    public class Error
    {
        [JsonProperty(PropertyName = "specificCode")]
        public string SpecificCode { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "stacktrace")]
        public string Stacktrace { get; set; }
    }
}
