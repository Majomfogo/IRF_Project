﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IRF_Projekt_EH515M
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FutarszolgalatEntities : DbContext
    {
        public FutarszolgalatEntities()
            : base("name=FutarszolgalatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Étterem> Étterem { get; set; }
        public virtual DbSet<Rendelés> Rendelés { get; set; }
        public virtual DbSet<Futár> Futár { get; set; }
    }
}
