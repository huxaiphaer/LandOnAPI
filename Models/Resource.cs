using System;
using Newtonsoft.Json;

namespace App.Models
{
    public abstract class Resource
    {
        [JsonProperty(Order =-2)]
       public string Href { get; set; }
    }
}
