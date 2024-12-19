using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorSample.Client.Pages
{

    public class PageBase : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("renderjQueryComponents");
            }
        }
    }

}
