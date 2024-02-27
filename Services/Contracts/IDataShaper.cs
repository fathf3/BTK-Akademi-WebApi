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
		IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entites, string filedsString);
		ExpandoObject ShapeData(T entity, string filedsString);
	}
}
