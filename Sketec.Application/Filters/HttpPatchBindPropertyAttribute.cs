using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sketec.Application.Filters
{
    public class HttpPatchBindPropertyAttribute : Attribute, IResourceFilter, IActionFilter
    {
        bool runable;

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (context.HttpContext.Request.Method == "PATCH"
                && context.HttpContext.Request.ContentType.ToLower().Contains("application/json")
                && context.HttpContext.Request.ContentLength.GetValueOrDefault() > 4)
            {
                runable = true;
                context.HttpContext.Request.EnableBuffering();
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (runable)
            {
                var controllerType = context.Controller.GetType();
                var fileds = controllerType.GetFields().FirstOrDefault(f => f.FieldType == typeof(BindPropertyCollection));
                if (fileds != null)
                {
                    var httpPatchCollection = new BindPropertyCollection();
                    context.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                    using (var sr = new StreamReader(context.HttpContext.Request.Body))
                    {
                        var json = sr.ReadToEnd();
                        var jObject = JObject.Parse(json);
                        foreach (var keyPaire in jObject)
                        {
                            httpPatchCollection.AddFlag(keyPaire.Key);
                        }
                    }

                    fileds.SetValue(context.Controller, httpPatchCollection);
                }
            }
        }



        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

    public class BindPropertyCollection
    {
        ICollection<string> _properties = new List<string>();
        public bool HasFlag(string name)
        {
            if (name == null)
                return false;
            return _properties.Any(p => name.ToLower().Equals(p));
        }

        public void AddFlag(string name)
        {
            if (name == null)
                return;
            name = name.ToLower();
            if (!_properties.Any(p => name.Equals(p)))
                _properties.Add(name);
        }

        public IEnumerable<string> AllKeyFlag => _properties.AsEnumerable();
    }
}
