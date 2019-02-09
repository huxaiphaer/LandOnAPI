using System;
using Newtonsoft.Json;

namespace App.Models
{
    public abstract class Resource : Link
    {
        [JsonIgnore]
       public Link Self { get; set; }
    }
}
