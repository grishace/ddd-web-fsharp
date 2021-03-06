﻿- title : Web Development With F#
- description : Web Development With F#. Denver Dev Day (October 28, 2016)
- author : Grigoriy Belenkiy (@grishace)
- theme : simple
- transition : zoom

***
- data-background : images/sponsors.png
- data-background-transition : none

' Sponsors slide (required by organizators)

***

### Web Development With F#

![Web Development With F#](./images/title-fsharp.jpg)

<!-- Image from https://theforbiddenknowledgeofenoch.blogspot.com/2014/01/who-are-followers-of-esoteric.html -->

<small>Grigoriy Belenkiy<br/>
Software engineer, S&amp;P Global<br/>
[@grishace](https://twitter.com/grishace)<br/>
<br/>
//denver/dev/day<br/>
October 28, 2016</small>

***

### Agenda

* F#
* ASP.NET WebAPI/MVC
* Suave
* WebSharper

' Freya - similar ideas to Suave - function composition, but could not build the HelloWorld example
' Fable - promising, but hard to implement even such simple example as FB

***

### Why F#?

* Functional
* Object-oriented

' Multi-paradigm

---

### Functional

```fsharp
type WebServer = HttpRequest -> Async<HttpResponse option>
```

' SOLID  and all design patterns replaced with function composition
' example - the essence of a web-server

---

### Object-oriented

```fsharp
type Startup (env:IHostingEnvironment)=

  // This method gets called by the runtime. Use this method to configure 
  // the HTTP request pipeline.
  member this.Configure(app:IApplicationBuilder, env:IHostingEnvironment,
    loggerFactory: ILoggerFactory) =

    loggerFactory
      .AddConsole(configuration.GetSection("Logging"))
      .AddDebug()
      |> ignore

      app.UseMvc() |> ignore
```

' .NET language - need to coexist and interop with other languages
' Can use all (almost?) libraries/packages created for C#
' example - from generated ASP.NET Core MVC application

***

### F#zzBuzz

![FizzBuzz](./images/fizzbuzz.jpg)

' https://en.wikipedia.org/wiki/Fizz_buzz#Programming_interviews

---

### ASP.NET Core WebAPI/MVC

![ASP.NET Core](./images/core-sticker.png)

> ASP.NET Core is a new open-source and cross-platform framework 
> for building modern cloud based internet connected applications, 
> such as web apps, IoT apps and mobile backends.

[https://www.asp.net/core](https://www.asp.net/core)

' https://dribbble.com/shots/3005811-Core-Sticker
' by Pablo Iglesias

---

### Suave

![ASP.NET Core WebAPI](./images/suave_400x400.png)

> Suave is a simple web development F# library providing a 
> lightweight web server and a set of combinators to manipulate 
> route flow and task composition.

[https://suave.io](https://suave.io)

---

### WebSharper

![WebSharper](./images/logo-websharper-icon.png)

> WebSharper is a framework and toolset for developing 
> web/mobile applications and web services entirely in 
> C# or F# (of a mix of the two languages) with strongly-typed
> client-server communication and site navigation.

[http://websharper.com](http://websharper.com)

***

### Books

<table class="no-borders-table"><tr valign="top">
<td width="33%"><a href="http://shop.oreilly.com/product/0636920026099.do" title="Building Web, Cloud, and Mobile Solutions with F#"><img alt="" src="./images/web-fsharp.jpg"/></a></td>
<td width="33%"><a href="https://www.amazon.com/Expert-F-4-0-Don-Syme/dp/1484207416/" title="Expert F# 4.0"><img alt="" src="./images/expert-fsharp.jpg"/></a></td>
<td width="33%"><a href="http://products.tamizhvendan.in/fsharp-applied/" title="F# Applied"><img alt="F# Applied" src="./images/fsharp-applied.jpg"/></a></td>
</tr>
<tr><td>
<small><h3>Building Web, Cloud, and Mobile Solutions with F#</h3>
<h4>by Daniel Mohl</h4></small></td>

<td>
<small><h3>Expert F# 4.0</h3>
<h4>by Don Syme, Adam Granicz, Antonio Cisternino</h4></small></td>

<td>
<small><h3>F# Applied</h3>
<h4>by Tamizhvendan S</h4></small></td>
</tr></table>

***

[![https://github.com/grishace/ddd-web-fsharp](./images/qrcode.png)](https://github.com/grishace/ddd-web-fsharp)<br/>
[https://github.com/grishace/ddd-web-fsharp](https://github.com/grishace/ddd-web-fsharp)
