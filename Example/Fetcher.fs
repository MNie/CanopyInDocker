namespace Example.Fetcher

open canopy
open canopy.classic
open canopy.types
open OpenQA.Selenium.Chrome

open System
module internal Fetcher =
    let private search () =
        (elements ".city").Length > 0

    let private startChrome () =
        let chromeOptions = ChromeOptions()
        chromeOptions.AddArgument("--no-sandbox")
        chromeOptions.AddArgument("--headless")
        let chromeNoSandbox = ChromeWithOptions(chromeOptions)
        start chromeNoSandbox

    let fetchHtml (city) =
        startChrome ()
        
        url "http://www.licytacje.komornik.pl/Notice/Search"
        waitFor search
        ".city" << city
        click "#Type"
        click "Nieruchomość"
        click ".button_next_active"

        let page = browser.PageSource
        quit ()

        page

