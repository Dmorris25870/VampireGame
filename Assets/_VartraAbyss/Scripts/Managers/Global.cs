using VartraAbyss.Entity;

namespace VartraAbyss.Managers
{
	public class Global : SingletonManager<Global>
	{
		public delegate Actor ActorEvents();
		public static ActorEvents OnGetPlayerEvent;
		public static ActorEvents OnGetEnemyEvent;
	}
}