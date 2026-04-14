using MVCTemplate.Models.CountriesModel;
using MVCTemplate.Models.PortalUser;
using MVCTemplate.Models.Role;
using Microsoft.EntityFrameworkCore;
using System;
using MVCTemplate.Models.AuditsModel;

namespace MVCTemplate.Data;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions<DataContext> options) : base(options)
  {

  }
  public DbSet<PortalUser> PortalUser => Set<PortalUser>();
  public DbSet<Role> Role => Set<Role>();
  public DbSet<Countries> Countries => Set<Countries>();
  public DbSet<Audits> Audits => Set<Audits>();
}
