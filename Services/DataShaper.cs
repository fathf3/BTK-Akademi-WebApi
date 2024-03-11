using Entities.Models;
using Services.Contracts;
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

		public IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entites, string filedsString)
		{
			var requiredFields = GetRequiredProperties(filedsString);
			return FetchData(entites, requiredFields);	
		}

		public ShapedEntity ShapeData(T entity, string filedsString)
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

		private ShapedEntity FetchDataForEntity(T entity, IEnumerable<PropertyInfo> requiredProperties)
		{
			var shapeObject = new ShapedEntity();
			foreach (var property in requiredProperties)
			{
				var objectPropertyValue = property.GetValue(entity);
				shapeObject.Entity.TryAdd(property.Name, objectPropertyValue);


			}
			var objectProperty = entity.GetType().GetProperty("Id");
			shapeObject.Id = (int)objectProperty.GetValue(entity);
			return shapeObject;
		}

		private IEnumerable<ShapedEntity> FetchData(IEnumerable<T> entites ,IEnumerable<PropertyInfo> requiredProperties)
		{
			var shapedData = new List<ShapedEntity>();
			foreach (var entity in entites)
			{
				var shapedObject = FetchDataForEntity (entity, requiredProperties);
				shapedData.Add(shapedObject);
			}
			return shapedData;
		}


	}
}
