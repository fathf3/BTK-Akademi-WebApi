using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories.EFCore.Extensions
{
	public static class OrderQueryBuilder
	{
		public static String CreateOrderQuery<T>(String orderByQueryString)
		{
			var orderParams = orderByQueryString.Trim().Split(',');

			// Book sınıfına ait bilgileri aldık 
			var properyInfos = typeof(T)
				.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			var orderQueryBuilder = new StringBuilder();

			foreach (var param in orderParams)
			{
				if (string.IsNullOrWhiteSpace(param))
					continue;
				var propertyFromQueryName = param.Split(' ')[0];


				// buyuk kucuk harf ayrımı olmayacak!
				var objectProperty = properyInfos
					.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

				if (objectProperty is null)
					continue;

				var direction = param.EndsWith(" desc") ? "descending" : "ascending";

				// title ascending, price descending, ....
				orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");


			}

			var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

			return orderQuery;
		}
	}
}
