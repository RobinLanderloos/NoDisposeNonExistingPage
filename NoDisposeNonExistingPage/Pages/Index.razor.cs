using System.Timers;

namespace NoDisposeNonExistingPage.Pages
{
    public partial class Index : IDisposable
    {
        private System.Timers.Timer _timer;
        private double _timerInterval = 1000;

        public void Dispose()
        {
            _timer?.Dispose();
            _logger.LogInformation("Dispose called");
        }

        protected override void OnInitialized()
        {
            _timer = new System.Timers.Timer(_timerInterval);
            _timer.Elapsed += OnElapsed;
            _timer.Start();
        }

        private void OnElapsed(object? s, ElapsedEventArgs e)
        {
            _logger.LogInformation("Timer elapsed");
        }
    }
}
