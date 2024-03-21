`$env:DbConeectionString="Server=localhost;User Id=manager;Password=manager;Port=5432;Database=managerDb"`

`Add-Migration InitDB -Project Infrastructure -StartupProject Web -Context ApplicationDbContext -OutputDir Infrastructure/Migrations -Verbose`