using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace News.Application.Interfaces
{
    public interface INewsDbContext
    {
        DbSet<Domain.News> News { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        bool Initialize();
    }
}
