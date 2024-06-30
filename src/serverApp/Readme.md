`$env:DbConeectionString="Server=localhost;User Id=manager;Password=manager;Port=5432;Database=managerdb"`

`Add-Migration InitDB -Project Infrastructure -StartupProject Web -Context ApplicationDbContext -OutputDir Infrastructure/Migrations -Verbose`