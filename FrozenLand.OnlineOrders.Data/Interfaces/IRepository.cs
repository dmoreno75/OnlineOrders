using System;
using System.Collections.Generic;
using System.Linq;

namespace FrozenLand.OnlineOrders.Data
{
	public interface IRepository<T>
	{
		IList<T> Get(Func<T, bool> predicate);
		IList<T> GetAll();
		T GetById(string Id);
        DbTransactionResult Add(T t);
        DbTransactionResult Update(T t);
        DbTransactionResult Delete(T t);
	}

}
