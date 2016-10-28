namespace FizzBuzz

open WebSharper.Html.Server
open WebSharper
open WebSharper.Sitelets

type EndPoint =
    | [<EndPoint "GET /">] Home

module Templating =
    open System.Web

    type Page =
        {
            Title : string
            MenuBar : list<Element>
            Body : list<Element>
        }

    let MainTemplate =
        Content.Template<Page>("~/Main.html")
            .With("title", fun x -> x.Title)
            .With("menubar", fun x -> x.MenuBar)
            .With("body", fun x -> x.Body)

    // Compute a menubar where the menu item for the given endpoint is active
    let MenuBar (ctx: Context<EndPoint>) endpoint =
        let ( => ) txt act =
             LI [if endpoint = act then yield Attr.Class "active"] -< [
                A [Attr.HRef (ctx.Link act)] -< [Text txt]
             ]
        [
            LI ["Home" => EndPoint.Home]
        ]

    let Main ctx endpoint title body : Async<Content<EndPoint>> =
        Content.WithTemplate MainTemplate
            {
                Title = title
                MenuBar = MenuBar ctx endpoint
                Body = body
            }

module Site =

    let HomePage ctx =
        Templating.Main ctx EndPoint.Home "Home" [
            Div [ClientSide <@ Client.Main() @>]
        ]

    [<Website>]
    let Main =
        Application.MultiPage (fun ctx action ->
            match action with
            | Home -> HomePage ctx
        )

[<Sealed>]
type Website() =
    interface IWebsite<EndPoint> with
        member this.Sitelet = Site.Main
        member this.Actions = [Home]

[<assembly: Website(typeof<Website>)>]
do ()
