using Syncfusion.Blazor;

namespace TangyWeb_Client.Pages
{
    public partial class Index
    {
        private string? activeBreakpoint { get; set; }
        public bool IsProcessing { get; set; } = false;
        private List<MediaBreakpoint> mediaQuery { get; set; } = new List<MediaBreakpoint>()
    {
     new MediaBreakpoint() { Breakpoint = "Iphone", MediaQuery = "(max-width: 500px)" },
     new MediaBreakpoint() { Breakpoint = "Desktop", MediaQuery = "(min-width: 1400px)" },
     new MediaBreakpoint() { Breakpoint = "Ipad", MediaQuery = "(min-width: 900px)" },
     new MediaBreakpoint() { Breakpoint = "Tablet", MediaQuery = "(min-width: 500px)" }
    };



        protected override async Task OnInitializedAsync()
        {
            IsProcessing = true;

            IsProcessing = false;
        }
    }
}
