using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.concrete;


namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private	readonly INotificationService _notificationService;


		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_productService = productService;
			_categoryService = categoryService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("RecieveCategoryCount", value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("RecieveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("RecieveActiveCategoryCount", value3);

			var value4 = _categoryService.TPasiveCategoryCount();
			await Clients.All.SendAsync("RecievePasiveCategoryCount", value4);

			var value5= _productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("RecieveProductCountByCategoryNameHamburger", value5);

			var value6= _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("RecieveProductCountByCategoryNameDrink", value6);

			var value7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("RecieveProductPriceAvg", value7.ToString("0.00")+ "TL");

			var value8= _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("RecieveProductNameByMaxPrice", value8);

			var value9 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("RecieveProductNameByMinPrice", value9);

			var value10 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("RecieveProductAvgPriceByHamburger", value10.ToString("0.00") + "TL");

			var value11=_orderService.TTotalOrderCount();
			await Clients.All.SendAsync("RevieveTotalOrderCount", value11);

			var value12 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("RevieveActiveOrderCount", value12);

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("RevieveLastOrderPrice", value13.ToString("0.00") + "TL");

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("RevieveTotalMoneyCaseAmount", value14.ToString("0.00") + "TL");

			var value16 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("RevieveMenuTableCount", value16);

		}

		public async Task SendProgress()
		{

            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("RecieveTotalMoneyCaseAmount", value.ToString("0.00") + "TL");

			var value2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("RecieveActiveOrderCount", value2);

			var value3=_menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("RecieveMenuTableCount", value3);
        }

		public async Task GetBookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}

		public async Task SendNotification()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("RecieveNotificationCountByFalse", value);

			var notificationListByFalse= _notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
		}

		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task OnConnectedAsync()
        {
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnDisconnectedAsync(exception);
        }

    }
}
