﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.RequestFeatures
{
	public abstract class RequestParameters
	{
		const int maxPageSize = 50; // 50den fazla kayıt verilmeyecek!
		// Auto-impememted property -> get set var  logic yok
        public int PageNumber { get; set; }


		// Full-property ->
		private int _pageSize;

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value > maxPageSize ? maxPageSize : value; }
		}

	}


}
