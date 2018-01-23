using DAL.Model;
using DAL.Context;

namespace DAL.DAO
{
    public class PlayerDAO
    {
        public void insert(Player player)
        {
            using(Contexto DB = new Contexto())
            {
                DB.Player.Add(player);
                DB.SaveChanges();
            }
        }
    }
}