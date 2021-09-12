using System.Threading.Tasks;

namespace WebApp
{
    public class ServiceOne
    {
        public async Task<Car> GetCarAsync(int id)
        {
            await Task.Delay(5000);
            return new(id, $"Volvo {id}", "Me");
        }
    }

    public record Car(int Id, string Mark, string Owner);
}