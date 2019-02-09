﻿using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace App.Models
{
    public class Link
    {
        public const string GetMethod = "GET";

        public static Link To(string routeName, object routeValues = null)
         => new Link
         {
             RouteName = routeName,
             RouteValues = routeValues,
             Method = GetMethod,
             Relations = null,
         };

        [JsonProperty(Order = -4)]
        public string Href { get; set; }

        [JsonProperty(Order =-3,PropertyName ="rel" ,
         NullValueHandling= NullValueHandling.Ignore)]
        public string[] Relations { get; set; }

        [JsonProperty(Order =-2, 
        DefaultValueHandling = DefaultValueHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore)]
        [DefaultValue(GetMethod)]
        public string Method { get; set; }

        //Stores the route name before being rewritten by the LinkRewritingFilter
        [JsonIgnore]
        public string RouteName { get; set; }

        //Stores the route parameters before being rewritten by the LinkRewritingFilter
        [JsonIgnore]
        public object RouteValues { get; set; }
    }
}