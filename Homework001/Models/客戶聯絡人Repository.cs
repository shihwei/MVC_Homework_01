using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework001.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(x => x.是否已刪除 == false);
        }

        public 客戶聯絡人 Find(int id)
        {
            return this.All().FirstOrDefault(x => x.Id == id);
        }

        public override void Delete(客戶聯絡人 entity)
        {
            entity.是否已刪除 = true;
        }
	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}