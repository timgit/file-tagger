file-tagger
===========

Dynamically creates HTML tags for JavaScript, CSS or other file-based elements in an ASP.NET MVC project.

This was originally built for injecting revision-named JavaScript and CSS bundles from client-side build tools, such as grunt-filerev or gulp-rev.  However, it could be used simply to inject tags baesd on the virtual path of the hosting application.

This run-time technique is an alternative to injection tools which write script tags at build time. Ideally, this will keep your Razor layout file free from contention and merge conflicts when working with a team of developers.
