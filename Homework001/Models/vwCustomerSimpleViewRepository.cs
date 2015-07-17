using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework001.Models
{   
	public  class vwCustomerSimpleViewRepository : EFRepository<vwCustomerSimpleView>, IvwCustomerSimpleViewRepository
	{

	}

	public  interface IvwCustomerSimpleViewRepository : IRepository<vwCustomerSimpleView>
	{

	}
}