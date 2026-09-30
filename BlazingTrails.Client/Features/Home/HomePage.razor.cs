using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazingTrails.Client.Features.Home
{
    public partial class HomePage
    {
        private IEnumerable<Trail>? _trails;

        [Inject] public HttpClient Http { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                _trails = await Http.GetFromJsonAsync<IEnumerable<Trail>>("trails\\trail-data.json");
            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine($"There was a problem loading trail data: {ex.Message}");
            }
        }
    }
}
