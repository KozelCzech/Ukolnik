using Microsoft.AspNetCore.Hosting;
using LiteDB;
using UkolnikBackend;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<UserService>();
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.UseStartup<Startup>()
        .UseUrls("http://localhost:5000");
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();


