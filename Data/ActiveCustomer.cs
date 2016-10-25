using Bangazon.Models;

namespace BangazonWeb.Data
{
	public class ActiveCustomer
	{
		// Make the class a singleton to maintain state across all uses
		private static ActiveCustomer _instance;
		public static ActiveCustomer Instance
		{
			get {
				// First time an instance of this class is requested
				if (_instance == null) {
					_instance = new ActiveCustomer ();
				}
				return _instance;
			}
		}

		// To track the currently active customer - selected by user
		public Customer Customer { get; set; }

	}
}

