#Summary#

FileTagger provides HTML helpers to create tags for JavaScript, CSS or other file-based elements in an ASP.NET MVC project.

This was originally built for injecting revision-named JavaScript and CSS bundles from client-side build tools, such as [grunt-filerev](https://github.com/yeoman/grunt-filerev) or [gulp-rev](https://github.com/sindresorhus/gulp-rev).  However, it could be used simply to inject tags baesd on the virtual path of the hosting application.

This run-time technique is an alternative to injection tools which write script tags at build time. Ideally, this will keep your Razor layout file free from contention and merge conflicts when working with a team of developers.

#Usage#
Currently, FileTagger is an abstraction over [DirectoryInfo.GetFiles()](http://msdn.microsoft.com/en-us/library/8he88b63%28v=vs.110%29.aspx), so it only supports a limited search pattern such as asterisks and question marks.

Following are some usage examples, assuming you have a ```@using FileTagger``` directive at the top of your layout file.

JavaScript bundle wildcard usage (what I built this for)
```
@Render.Script("~/public/build/js/app_bundle*.js")
```

Virtual path usage - single file
```
@Render.Link("~/Content/bootstrap.css")
```

Wildcard usage - multiple files
```
@Render.Links("~/Content/bootstrap-theme*.css")
```
 
Single character wildcard usage with question marks
```
@Render.Script("~/Scripts/jquery-2.?.?.js")
```


#Installation#
You can either include FileTagger.cs into your ASP.NET MVC project directly or use the NuGet package I created to keep it as an externally versioned  dependency.

If you'd like to install via NuGet package manager console:
```
Install-Package FileTagger
```
