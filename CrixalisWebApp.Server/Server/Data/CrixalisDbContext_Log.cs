using Microsoft.EntityFrameworkCore;
using Pantheon.Shared.BaseEntityModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace bwaCrixalis.Server.Data;
public class CrixalisDbContext_Log : DbContext
{
    public CrixalisDbContext_Log(DbContextOptions<CrixalisDbContext_Log> options) : base(options) { }
    //public DbSet<pthT9LogHeader> T9LogHeader { get; set; }
    //public DbSet<pthT9LogDetail> T9LogDetail { get; set; }
    public DbSet<pthT9Log> T9Log { get; set; }
}
