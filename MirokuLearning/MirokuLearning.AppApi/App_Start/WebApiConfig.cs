﻿using FluentValidation.WebApi;
using MirokuLearning.AppApi.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;

namespace MirokuLearning.AppApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var container = UnityConfiguration.Config();
            config.DependencyResolver = new UnityResolver(container);

            config.Filters.Add(new ValidateModelStateFilter());

            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));

            

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }

            );

            FluentValidationModelValidatorProvider.Configure(config);
        }
    }
}
