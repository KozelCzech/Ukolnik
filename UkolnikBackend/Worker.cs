namespace UkolnikBackend
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly UserService _userService;

        public Worker(ILogger<Worker> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try 
                {
                    if (_userService.GetLoggedInUser() == null)
                    {
                        _logger.LogInformation("No logged in user");
                    }
                    else
                    {
                        var loggedInUser = _userService.GetLoggedInUser();
                        _logger.LogInformation($"Logged in user: {loggedInUser.Username}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}