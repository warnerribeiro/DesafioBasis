using NBomber.CSharp;

using var httpClient = new HttpClient();

var scenario = Scenario.Create("hello_world_scenario", async context =>
{
    var response = await httpClient.GetAsync("https://nbomber.com");

    return response.IsSuccessStatusCode
        ? Response.Ok()
        : Response.Fail();
})
.WithoutWarmUp()
.WithLoadSimulations(
    Simulation.Inject(rate: 10,
                      interval: TimeSpan.FromSeconds(1),
                      during: TimeSpan.FromSeconds(30))
);

NBomberRunner
    .RegisterScenarios(scenario)
    .Run();
