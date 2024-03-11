using Entities.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IDataShaper<T>
	{

		//ExpandObject runtime da olusturabılır nesene
		IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entites, string filedsString);
		ShapedEntity ShapeData(T entity, string filedsString);
	}
}
