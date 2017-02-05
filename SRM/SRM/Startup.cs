using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using SRM.Models;
using System.Data.Entity;

[assembly: OwinStartup(typeof(SRM.Startup))]

namespace SRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SRMContext>());
            using (var context = new SRMContext())
            {
                context.Database.Initialize(force: true);
            }
            ConfigureAuth(app);
        }
    }
}