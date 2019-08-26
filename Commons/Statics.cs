using DA.Health.Model;

namespace Commons
{
	public static class Statics
	{
		static Statics()
		{
			CurrentLogin = null;
		}

		public static Login CurrentLogin { get; set; }
	}
}
