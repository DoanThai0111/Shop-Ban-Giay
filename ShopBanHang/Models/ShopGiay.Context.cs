//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopBanHang.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ShopGiayEntities : DbContext
    {
        public ShopGiayEntities()
            : base("name=ShopGiayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admins { get; set; }
        public virtual DbSet<chude> chudes { get; set; }
        public virtual DbSet<ctdathang> ctdathangs { get; set; }
        public virtual DbSet<ctthamdo> ctthamdoes { get; set; }
        public virtual DbSet<dondathang> dondathangs { get; set; }
        public virtual DbSet<giay> giays { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<menu> menus { get; set; }
        public virtual DbSet<nhaxuatban> nhaxuatbans { get; set; }
        public virtual DbSet<quangcao> quangcaos { get; set; }
        public virtual DbSet<tacgia> tacgias { get; set; }
        public virtual DbSet<thamdo> thamdoes { get; set; }
        public virtual DbSet<vietgiay> vietgiays { get; set; }
    }
}
