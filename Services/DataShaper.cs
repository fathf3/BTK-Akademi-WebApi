﻿using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
	public class DataShaper<T> : IDataShaper<T> where T : class
	{
		public PropertyInfo[] Properties { get; set; }

		public DataShaper()
		{
			Properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
		}

		public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entites, string filedsString)
		{
			var requiredFields = GetRequiredProperties(filedsString);
			return FetchData(entites, requiredFields);	
		}

		public ExpandoObject ShapeData(T entity, string filedsString)
		{
			var requiredProperties = GetRequiredProperties(filedsString);
			return FetchDataForEntity(entity, requiredProperties);
		}

		private IEnumerable<PropertyInfo> GetRequiredProperties(string filedsString)
		{
			var requiredFields = new List<PropertyInfo>();
			if (!string.IsNullOrWhiteSpace(filedsString))
			{
				// bos olan elamanları eklemez!!
				var fields = filedsString.Split(',', StringSplitOptions.RemoveEmptyEntries);

				foreach (var field in fields)
				{
					var property = Properties
						.FirstOrDefault(pi => pi.Name.Equals(field.Trim(),
						StringComparison.InvariantCultureIgnoreCase));

					if (property is null)
						continue;
					requiredFields.Add(property);

				}

			}
			else
			{
				requiredFields = Properties.ToList();
			}

			return requiredFields;
		}

		private ExpandoObject FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
		{
			var shapeObject = new ExpandoObject();
			foreach (var property in requiredProperties)
			{
				var objectPropertyValue = property.GetValue(entity);
				shapeObject.TryAdd(property.Name, objectPropertyValue);


			}
			return shapeObject;
		}

		private IEnumerable<ExpandoObject> FetchData(IEnumerable<T> entites ,IEnumerable<PropertyInfo> requiredProperties)
		{
			var shapedData = new List<ExpandoObject>();
			foreach (var entity in entites)
			{
				var shapedObject = FetchDataForEntity (entity, requiredProperties);
				shapedData.Add(shapedObject);
			}
			return shapedData;
		}


	}
}
