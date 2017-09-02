﻿using Abp.Hangfire;
using Abp.Owin;
using Hangfire;
using ImproveX.Api.Controllers;
using ImproveX.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace ImproveX.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseAbp();
           
            app.UseOAuthBearerAuthentication(AccountController.OAuthBearerOptions);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
           
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.MapSignalR();

            //ENABLE TO USE HANGFIRE dashboard (Requires enabling Hangfire in ImproveXWebModule)
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new AbpHangfireAuthorizationFilter() } //You can remove this line to disable authorization
            });
        }
    }
}