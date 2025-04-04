using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class MenuTableManager : IMenuTableService
	{
		private readonly IMenuTableDal _menuTable;

		public MenuTableManager(IMenuTableDal menuTable)
		{
			_menuTable = menuTable;
		}

		public void TAdd(MenuTable entity)
		{
			_menuTable.Add(entity);
		}

		public void TDelete(MenuTable entity)
		{
			_menuTable.Delete(entity);
		}

		public MenuTable TGetByID(int id)
		{
			return _menuTable.GetByID(id);
		}

		public List<MenuTable> TGetListAll()
		{
			return _menuTable.GetListAll();
		}

		public int TMenuTableCount()
		{
			return _menuTable.MenuTableCount();
		}

		public void TUpdate(MenuTable entity)
		{
			_menuTable.Update(entity);
		}
	}
}
