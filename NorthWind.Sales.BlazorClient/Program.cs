var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddNorthWindSalesServices(
    client => client.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]),
    membershipClient => membershipClient.BaseAddress = new Uri(builder.Configuration["WebApiAddress"]));

await builder.Build().RunAsync();
