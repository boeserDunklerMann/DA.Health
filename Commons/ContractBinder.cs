using System;
using System.Collections.Generic;

namespace Commons
{
	public static class ContractBinder
	{
		private static HashSet<Tuple<Type, Type>> _container;
		private static int _nCounter = 0;

		static ContractBinder()
		{
			_container = new HashSet<Tuple<Type, Type>>();
		}

		private static void Bind(Type InterfaceType, Type ImplementationType)
		{
			Tuple<Type, Type> item = new Tuple<Type, Type>(InterfaceType, ImplementationType);
			_container.Add(item);
			_nCounter++;
		}

		public static void CreateBindings()
		{
			Bind(typeof(DA.Health.Contracts.Data.IDbAccessor), typeof(DA.Health.DbAccess.MySql.DbaMySql));
			Bind(typeof(DA.Health.Contracts.Encryption.IEncHasher), typeof(DA.Health.Encryption.MD5.Md5Hasher));
		}

		public static TInterface GetObject<TInterface>()
		{
			if (0 == _nCounter)
				CreateBindings();
			foreach (Tuple<Type, Type> bindings in _container)
			{
				if (bindings.Item1.Equals(typeof(TInterface)))
				{
					return (TInterface)Activator.CreateInstance(bindings.Item2);
				}
			}
			return default(TInterface);
		}
	}
}
