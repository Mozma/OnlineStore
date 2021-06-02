﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineStore
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MarketDBEntities : DbContext
    {
        public MarketDBEntities()
            : base("name=MarketDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<DeliveryView> DeliveryViews { get; set; }
        public virtual DbSet<OrdersView> OrdersViews { get; set; }
        public virtual DbSet<ProductView> ProductViews { get; set; }
        public virtual DbSet<SellsView> SellsViews { get; set; }
        public virtual DbSet<CartView> CartViews { get; set; }
    
        public virtual ObjectResult<GetChart_Result> GetChart(string category, Nullable<System.DateTime> start, Nullable<System.DateTime> end)
        {
            var categoryParameter = category != null ?
                new ObjectParameter("category", category) :
                new ObjectParameter("category", typeof(string));
    
            var startParameter = start.HasValue ?
                new ObjectParameter("Start", start) :
                new ObjectParameter("Start", typeof(System.DateTime));
    
            var endParameter = end.HasValue ?
                new ObjectParameter("End", end) :
                new ObjectParameter("End", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetChart_Result>("GetChart", categoryParameter, startParameter, endParameter);
        }
    
        public virtual ObjectResult<GetProductReport_Result> GetProductReport(Nullable<System.DateTime> beg_date, Nullable<System.DateTime> end_date)
        {
            var beg_dateParameter = beg_date.HasValue ?
                new ObjectParameter("beg_date", beg_date) :
                new ObjectParameter("beg_date", typeof(System.DateTime));
    
            var end_dateParameter = end_date.HasValue ?
                new ObjectParameter("end_date", end_date) :
                new ObjectParameter("end_date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductReport_Result>("GetProductReport", beg_dateParameter, end_dateParameter);
        }
    }
}
