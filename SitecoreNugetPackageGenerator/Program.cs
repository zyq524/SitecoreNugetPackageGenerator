using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace SitecoreNugetPackageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dllDir = args[0];
            var files = Directory.GetFiles(dllDir);
            var references = new List<string> {"Sitecore.Kernel.dll"};

            XNamespace aw = "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd";
            XElement package = new XElement(aw + "package",
                new XElement(aw + "metadata",
                    new XElement(aw + "id", "SitecoreNugetPackage"),
                    new XElement(aw + "version", "1.0.0"),
                    new XElement(aw + "authors", "YQZ"),
                    new XElement(aw + "requireLicenseAcceptance", false),
                    new XElement(aw + "description", "This is a nuget package for Sitecore DLLs"),
                    new XElement(aw + "references",
                        from reference in references
                        select
                            new XElement(aw + "reference", new XAttribute("file", reference)))),
                new XElement(aw + "files",
                    new XElement(aw + "file", new XAttribute("src", string.Format(@"{0}\Sitecore.*.dll", dllDir)),
                        new XAttribute("target", "lib")))
                );

            package.Save("my.nuspec");
            string str = File.ReadAllText("my.nuspec");
            Console.WriteLine(str);
        }
    }
}
