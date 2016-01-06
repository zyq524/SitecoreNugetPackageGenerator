using System.Text;
using CommandLine;
using CommandLine.Text;

namespace SitecoreNugetPackageGenerator
{
    class Options
    {
        [Option('n', "NuspecFileName", Required = true, HelpText = "The full path of the Nuspec file.")]
        public string NuspecFileName { get; set; }

        [Option('s', "SitecoreDllDir", Required = true, HelpText = "The directory contains all the Sitecore Dlls.")]
        public string SitecoreDllDir { get; set; }

        [Option('o', "OutputDir", Required = false, HelpText = "The directory for the created NuGet package file. If not specified, uses the current directory.")]
        public string OutputDir { get; set; }

        [Option('i', "PackageId", Required = true, HelpText = "The package Id.")]
        public string Id { get; set; }

        [Option('v', "PackageVersion", Required = true, HelpText = "The package version.")]
        public string Version { get; set; }

        [Option('a', "Authors", Required = true, HelpText = "The authors.")]
        public string Authors { get; set; }

        [Option('d', "Description", Required = false, HelpText = "The description.")]
        public string Description { get; set; }

        [Option('r', "ReferenceList", Required = false, HelpText = "The assemblies that the target project should reference. Seperates the assemblies by comma, i.e. Sitecore.Kernel.dll, Sitecore.Web.dll")]
        public string ReferenceList { get; set; }

        [HelpOption(HelpText = "Display this help screen.")]
        public string GetUsage()
        {
            //var usage = new StringBuilder();
            //usage.AppendLine("Sitecore Nuget Package Generator");
            //usage.AppendLine("Read user manual for usage instructions...");
            return HelpText.AutoBuild(this,
                (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            //return usage.ToString();
        }
    }
}
