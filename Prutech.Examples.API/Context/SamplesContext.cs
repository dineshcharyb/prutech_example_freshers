using Microsoft.EntityFrameworkCore;

namespace Prutech.Examples.API.Context;

public class SamplesContext : DbContext
{
    public SamplesContext(DbContextOptions options)
           : base(options)
    {

    }
}
