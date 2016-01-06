using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace SNPG.Core
{
    public static class Core
    {
        public static void CreateNuspecFile(string fileName, string sitecoreDllDir, NuspecMetadata metadata)
        {
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(sitecoreDllDir) || metadata == null)
            {
                return;
            }

            XNamespace aw = "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd";
            XElement package = new XElement(aw + "package",
                new XElement(aw + "metadata",
                    new XElement(aw + "id", metadata.Id),
                    new XElement(aw + "version", metadata.Version),
                    new XElement(aw + "authors", metadata.Authors),
                    new XElement(aw + "requireLicenseAcceptance", false),
                    new XElement(aw + "description", metadata.Description),
                    new XElement(aw + "references",
                        from reference in metadata.ReferenceList
                        select
                            new XElement(aw + "reference", new XAttribute("file", reference)))),
                new XElement(aw + "files",
                    new XElement(aw + "file", new XAttribute("src", $@"{sitecoreDllDir}\Sitecore.*.dll"),
                        new XAttribute("target", "lib")))
                );

            package.Save(fileName);
        }

        public static void Pack(string nuspecFile, string outputDirectory)
        {

            var proc = new Process
            {
                StartInfo =
                {
                    FileName = "nuget.exe",
                    Arguments = string.IsNullOrEmpty(outputDirectory)
                        ? $"pack {nuspecFile}"
                        : $"pack {nuspecFile} -OutputDirectory {outputDirectory}"
                }
            };
            proc.Start();
            proc.WaitForExit();
            var exitCode = proc.ExitCode;
            proc.Close();
        }
    }
}
