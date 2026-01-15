using Microsoft.EntityFrameworkCore;


/*
    db context in c# is a session with the database 
        the context object allow querying(for example linq methods )
        and saving data (CRUD operation ....).  
        its like a The manager between your C# code and the database 
        our application never talks directly to the database.
        It talks to DbContext, and DbContext talks to the database.

*/

// DbContext :=>   dotnet add package Microsoft.EntityFrameworkCore.SqlServer

// Migrations :=> dotnet add package Microsoft.EntityFrameworkCore.Tools
/*
    This is needed for:

        dotnet ef migrations
        dotnet ef database update

*/
internal class AppDbContext : DbContext // primary constractor  as in the c# discution 
{

    public DbSet<FishingCompany>    FishingCompanies {get; set;}
    public DbSet<FishingTrip>       FishingTrips {get; set;} 
    public DbSet<FishingVessel>     FishingVessels {get; set;}
    

    
    //    : for no ambiguous EF Core must know which DbContext these options belong to, especially when multiple DbContexts exist.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);



    }


    
}

