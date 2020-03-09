namespace LT.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LTDBContent : DbContext
    {
        public LTDBContent()
            : base("name=DBContent")
        {
        }

        public virtual DbSet<CommodityImages> CommodityImages { get; set; }
        public virtual DbSet<LTCommoditys> LTCommoditys { get; set; }
        public virtual DbSet<LTCommodityTypes> LTCommodityTypes { get; set; }
        public virtual DbSet<LTUsers> LTUsers { get; set; }
        public virtual DbSet<LTUsersAddrs> LTUsersAddrs { get; set; }
        public virtual DbSet<LTUsersInfos> LTUsersInfos { get; set; }
        public virtual DbSet<ShopImgs> ShopImgs { get; set; }
        public virtual DbSet<ShopOrders> ShopOrders { get; set; }
        public virtual DbSet<ShopOrdersInfos> ShopOrdersInfos { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CommodityImages>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<CommodityImages>()
                .Property(e => e.ImgDescribe)
                .IsUnicode(false);

            modelBuilder.Entity<LTCommoditys>()
                .Property(e => e.CommodityName)
                .IsUnicode(false);

            modelBuilder.Entity<LTCommoditys>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<LTCommoditys>()
                .Property(e => e.CommodityImage)
                .IsUnicode(false);

            modelBuilder.Entity<LTCommoditys>()
                .HasMany(e => e.CommodityImages)
                .WithRequired(e => e.LTCommoditys)
                .HasForeignKey(e => e.CommodityId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LTCommoditys>()
                .HasMany(e => e.ShopOrdersInfos)
                .WithOptional(e => e.LTCommoditys)
                .HasForeignKey(e => e.CommodityId);

            modelBuilder.Entity<LTCommodityTypes>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<LTCommodityTypes>()
                .Property(e => e.CommodityDesc)
                .IsUnicode(false);

            modelBuilder.Entity<LTCommodityTypes>()
                .HasMany(e => e.LTCommoditys)
                .WithRequired(e => e.LTCommodityTypes)
                .HasForeignKey(e => e.TypeId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LTCommodityTypes>()
                .HasMany(e => e.LTCommodityTypes1)
                .WithRequired(e => e.LTCommodityTypes2)
                .HasForeignKey(e => e.ParentId);

            modelBuilder.Entity<LTUsers>()
                .Property(e => e.UsersAcount)
                .IsUnicode(false);

            modelBuilder.Entity<LTUsers>()
                .Property(e => e.UsersPwd)
                .IsUnicode(false);

            modelBuilder.Entity<LTUsers>()
                .HasMany(e => e.LTUsersAddrs)
                .WithRequired(e => e.LTUsers)
                .HasForeignKey(e => e.CustomerLoginId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LTUsers>()
                .HasMany(e => e.LTUsersInfos)
                .WithRequired(e => e.LTUsers)
                .HasForeignKey(e => e.UsersLoginId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LTUsersInfos>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<LTUsersInfos>()
                .Property(e => e.TelPhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LTUsersInfos>()
                .HasMany(e => e.ShopOrdersInfos)
                .WithOptional(e => e.LTUsersInfos)
                .HasForeignKey(e => e.UsersId);

            modelBuilder.Entity<ShopImgs>()
                .Property(e => e.PicUrl)
                .IsUnicode(false);

            modelBuilder.Entity<ShopImgs>()
                .Property(e => e.ImgDescribe)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.OrderSn)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.ShipingUser)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.TelPhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.PayMoney)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.ShippingCompName)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrders>()
                .Property(e => e.ShippingNo)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrdersInfos>()
                .Property(e => e.ProductName)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrdersInfos>()
                .Property(e => e.ProductImages)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrdersInfos>()
                .Property(e => e.ProductRize)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrdersInfos>()
                .Property(e => e.ProductColor)
                .IsUnicode(false);

            modelBuilder.Entity<ShopOrdersInfos>()
                .Property(e => e.TotalPrices)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShopOrdersInfos>()
                .HasMany(e => e.ShopOrders)
                .WithOptional(e => e.ShopOrdersInfos)
                .HasForeignKey(e => e.OrderId);

            modelBuilder.Entity<Shops>()
                .Property(e => e.BackgroundImage)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.ShowName)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<Shops>()
                .HasMany(e => e.ShopOrdersInfos)
                .WithOptional(e => e.Shops)
                .HasForeignKey(e => e.ShopId);
        }
    }
}
