using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Syncfusion.Blazor;
using TangyWeb_Client;
using TangyWeb_Client.Serivce;
using TangyWeb_Client.Serivce.IService;
using TangyWeb_Client.Service;
using TangyWeb_Client.Service.IService;



Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjk5NTg4OUAzMjM0MmUzMDJlMzBGeEZlQk9TMDdjZjlnQmVHdHdZRk8rZWUveWttOGpjNGR6cVVxSURheFNFPQ==");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
builder.Services.AddScoped<AuthStateProvider, AuthStateProvider>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

builder.Services.AddAuthorizationCore();


builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();
