using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
	public abstract record BookDtoForManipulation
	{
        [Required(ErrorMessage ="Title is a required field.")]
        [MinLength(2, ErrorMessage ="Title must consist of least 2 characters")]
        [MaxLength(100, ErrorMessage ="Title must consist of maximum 2 characters")]
        public String Title { get; set; }

		[Required(ErrorMessage = "Price is a required field.")]
		[Range(10,10000)]
        public decimal Price { get; set; }
    }
}
