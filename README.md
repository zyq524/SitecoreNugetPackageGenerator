# SitecoreNugetPackageGenerator
A tool to generate Sitecore nuget package

The command line usage:

  -n, --NuspecFileName    Required. The full path of the Nuspec file.

  -s, --SitecoreDllDir    Required. The directory contains all the Sitecore
                          Dlls.

  -o, --OutputDir         The directory for the created NuGet package file. If
                          not specified, uses the current directory.

  -i, --PackageId         Required. The package Id.

  -v, --PackageVersion    Required. The package version.

  -a, --Authors           Required. The authors.

  -d, --Description       The description.

  -r, --ReferenceList     The assemblies that the target project should
                          reference. Seperates the assemblies by comma, i.e.
                          Sitecore.Kernel.dll, Sitecore.Web.dll

  --help                  Display this help screen.
