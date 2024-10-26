using System;
using ClinicApi.Models.Entity;
using ClinicApi.Models.PortalUser;
using ClinicApi.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Entity> Entity => Set<Entity>();
    public DbSet<Department> Department => Set<Department>();
    public DbSet<Role> Role => Set<Role>();
    public DbSet<PortalUser> PortalUser => Set<PortalUser>();
}
