using DiscRental73TestWpf.Infrastructure.Plugins.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;

namespace DiscRental73TestWpf.Infrastructure.Plugins
{
    public class AdminPluginManager
    {
        [ImportMany(typeof(IAdminPlugin))]
        private List<IAdminPlugin> _AdminPlugin;

        public IAdminPlugin AdminPlugin => _AdminPlugin.FirstOrDefault();

        public AdminPluginManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            var pluginsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
            if (!Directory.Exists(pluginsDirectory)) Directory.CreateDirectory(pluginsDirectory);
            catalog.Catalogs.Add(new DirectoryCatalog(pluginsDirectory));
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
