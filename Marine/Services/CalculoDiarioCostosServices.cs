using Marine.Data;
using Marine.Entitys;
using System.Threading.Tasks;

namespace Marine.Services
{
    public class CalculoDiarioCostosServices : IHostedService, IDisposable
    {
        /// <summary>
        /// variable global de IServiceProvier
        /// </summary>
        public IServiceProvider _services { get; }

        private Timer _timer;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="services"></param>
        /// <param name="sender"></param>
        public CalculoDiarioCostosServices(IServiceProvider services)
        {
            this._services = services;
        }

        /// <summary>
        /// Inicia el Servicio
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }

        /// <summary>
        /// Detiene el Servicio
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        /// <summary>
        /// donde ocurre la magias
        /// </summary>
        /// <param name="state"></param>
        private async void DoWork(object state)
        {
            try
            {
                using (var scope = _services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var hoy = DateTime.Now;
                    CostosMes all = new();
                    await all.CompleteDataBase(context, hoy);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        /// <summary>
        /// Detiene el Timer
        /// </summary>
        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
