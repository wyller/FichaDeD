using DAL.Model;
using DAL.Context;
using System.Collections.Generic;

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
        
        public void UpdatePlayer(Player player)
        {
            using(Contexto DB = new Contexto())
            {
                DB.Player.Update(player);
                DB.SaveChanges();
            }
        }

        public void DeletePlayer(Player player)
        {
            using(Contexto DB = new Contexto())
            {
                DB.Player.Remove(player);
                DB.SaveChanges();
            }
        }

        public Player SelectPlayerFind(int id)
        {
            using(Contexto DB = new Contexto())
            {
                return DB.Player.Find(id);
            }
        }
    }
}