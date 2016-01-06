using System;
using System.Collections.Generic;
using System.Linq;
using SNPG.Core;

namespace SitecoreNugetPackageGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                var nuspceMetadata = new NuspecMetadata
                {
                    Authors = options.Authors,
                    Description = options.Description,
                    Id = options.Id,
                    Version = options.Version,
                    ReferenceList = new List<string>()
                };

                if (!string.IsNullOrEmpty(options.ReferenceList))
                {
                    nuspceMetadata.ReferenceList = options.ReferenceList.Split(',').ToList();
                }

                Core.CreateNuspecFile(options.NuspecFileName, options.SitecoreDllDir, nuspceMetadata);
                Core.Pack(options.NuspecFileName, options.OutputDir);

                Console.WriteLine("Package generated.");
            }
        }
    }
}
