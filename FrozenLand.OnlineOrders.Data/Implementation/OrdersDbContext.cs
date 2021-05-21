using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FrozenLand.OnlineOrders.Data
{
    public class OrdersDbContext : DbContext, IOnlineOrder
    {
        private readonly bool _inMemory;

        public DbSet<Order> Orders { get; set; }
        protected string _connectionStringOrDbName { get; set; }
        public OrdersDbContext()
        {
            _inMemory = true;
            _connectionStringOrDbName = "TestDb";
        }
        public OrdersDbContext(DbContextOptions options) : base(options) { }
        public OrdersDbContext(string connectionStringOrDbName, bool inMemory)
        {
            _inMemory = inMemory;
            _connectionStringOrDbName = connectionStringOrDbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=.\\;Database=OnlineOrder;User Id=sa;Password=PASSWORD;");
            if (!optionsBuilder.IsConfigured)
            {
                if (_inMemory)
                {
                    optionsBuilder.UseInMemoryDatabase(_connectionStringOrDbName);
                }
                else
                {
                    if (!string.IsNullOrEmpty(_connectionStringOrDbName))
                        optionsBuilder.UseSqlServer(_connectionStringOrDbName);
                    else
                        throw new Exception("Database needs configuration");
                }
            }
        }

        public IList<Order> GetAll()
        {
            return this.Orders.ToList();
        }

        public IList<Order> Get(Func<Order, bool> predicate)
        {
            return this.Orders.Where(predicate).ToList();
        }

        public Order GetById(string Id)
        {
            return this.Orders.SingleOrDefault(o => o.Id == Id);
        }

        public DbTransactionResult Add(Order order) => SimpleDbTransaction(this.Orders.Add, order);
        public DbTransactionResult Update(Order order) => SimpleDbTransaction(this.Orders.Update, order);
        public DbTransactionResult Delete(Order order) => SimpleDbTransaction(this.Orders.Remove, order);

        private DbTransactionResult SimpleDbTransaction(Func<Order, EntityEntry<Order>> action, Order order)
        {
            try
            {
                action(order);
                this.SaveChanges();
            }
            catch (Exception e)
            {
                return DbTransactionResult.BuildUnsuccessfulValidationResult(e.Message);
            }

            return DbTransactionResult.BuildSuccessfulValidationResult();
        }
    }

    public class DbTransactionResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public static DbTransactionResult BuildUnsuccessfulValidationResult(string errorMessage)
        {
            return new DbTransactionResult()
            {
                Success = false,
                Error = errorMessage
            };
        }
        public static DbTransactionResult BuildSuccessfulValidationResult() =>
            new DbTransactionResult() { Success = true };
    }
}
