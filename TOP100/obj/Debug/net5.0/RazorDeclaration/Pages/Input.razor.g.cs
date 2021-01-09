// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TOP100.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using TOP100;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using TOP100.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\_Imports.razor"
using TOP100.Pages;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\Pages\Input.razor"
using FrontendLogic;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\Pages\Input.razor"
using Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\Pages\Input.razor"
using ViewModels;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/input/{param}")]
    public partial class Input : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 52 "C:\Users\loosv\source\repos\2021pop-simonloosveldt\TOP100\Pages\Input.razor"
       
    public InputHandler inputHandler { get; set; }

    public string pageTitle { get; set; } = "TOP100";

    [Parameter]
    public string Param { get; set; }

    public int UpperLimit { get; set; }
    public int LowerLimit { get; set; }

    public string save_button { get; set; } = "SAVE";

    public List<ListEntryViewModel> userListEntries;


    protected override void OnInitialized()
    {
        if (accountService.loggedInUser == null) HandleNotLoggedIn();

        this.inputHandler = new InputHandler();

        string[] partsArray = Param.Split('_');

        UpperLimit = Int32.Parse(partsArray[0]);
        LowerLimit = Int32.Parse(partsArray[1]);

        userListEntries = inputHandler.GetPreviousData(accountService.loggedInUser, UpperLimit, LowerLimit);

        //Task<Timer> timedSync = InitializeAndStartTimer();

        //InitializeAndStartTimer();

    }

    private async void UpdateDatabase(/*Object source, ElapsedEventArgs e*/)
    {
        save_button = "PRESSED";
        inputHandler.UpdateDatabase(accountService.loggedInUser, userListEntries);

    }

    public void HandleNotLoggedIn()
    {
        NavigationManager.NavigateTo("/login", true);
    }

    //public void InitializeAndStartTimer()
    //{
    //    Timer t = new Timer(60000);
    //    t.AutoReset = true;
    //    t.Elapsed += new ElapsedEventHandler(UpdateDatabase);
    //    t.Start();
    //}

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountService accountService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591