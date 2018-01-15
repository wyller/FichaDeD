using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace manterFichaDeD.Controllers
{
    [Route("api/[controller]")]
    public class FichaController : Controller
    {

        IFichaBLL fichaBLL = new FichaBLL();

        public class Player
        {
            public Player(int Id, int For, int Int, int Des, int Cons, int Sab, int Car, string Classe, int Xp)
            {
                this.Id = Id;
                this.For = For;
                this.Car = Car;
                this.Cons = Cons;
                this.Des = Des;
                this.Int = Int;
                this.Sab = Sab;
                this.Classe = Classe;
                this.Xp = Xp;

            }

            public int Id   {get; set;}
            public int For  {get; set;}
            public int Int  {get; set;}
            public int Des  {get; set;}
            public int Cons {get; set;}
            public int Sab  {get; set;}
            public int Car  {get; set;}
            public string Classe {get; set;}
            public int Xp {get; set;}
            public List<object> Skills {get; set;}
        }

        public List<Player> players = new List<Player>()
        {
            new Player(1, 03, 16, 05, 07,14, 11, "Mago", 150),
            new Player (2, 18, 03, 11, 16, 03, 14, "Guerreiro", 120),            
            new Player (3, 11, 11, 18, 11, 06, 18, "Guerreiro", 70)
        };

        // GET api/ficha
        [HttpGet]
        public IActionResult getAll()
        {
            try{
                return Json(players);
            }catch(Exception e){
                StatusCode(500, "deu ruim get comum" + e);
                return null;
            }
        }
        
        // GET api/ficha/5
        [HttpGet("{id}")]
        public Player GetPlayer(int id)
        {
            try{
                foreach(Player pl in players){
                    if(pl.Id == id)
                        return pl;  
                }
                return null;
            }
            catch(Exception e){
                StatusCode(500, "deu ruim get id" + e
            );
                return null;
            }
        }

        // GET api/ficha/int/5
        [HttpGet("int/{id}")]
        public IActionResult GetInteligencia(int id)
        {
            try{
                foreach(Player pl in players){
                    if(pl.Id == id)
                        return Json(pl.Int);  
                }
                return null;
            }
            catch(Exception e){
                StatusCode(500, "deu ruim get id" + e);
                return null;
            }
        }

        // GET api/ficha/5
        [HttpGet("{id}")]
        public IActionResult GetSabedoria(int id)
        {
            try
            {
            var sabededoria = players.Where(pl => pl.Id == id).FirstOrDefault();
            if(sabededoria != null)
            {
                return Json(sabededoria.Sab);
            }
            return null;
            }catch( Exception e)
            {
                StatusCode(500, "deu Ruim a busca" + e);
                return null;
            }
        }

        // POST api/ficha
        [HttpPost]
        public IActionResult AddFicha([FromBody] Player pl)
        {
            try
            {
                players.Add(pl);
                return Json(players);
            }
            catch(Exception e)
            {
                StatusCode(500, "post deu ruim" + e);
                return null;
            }
        }

        [HttpPut("Evoluir/{id}")]
        public IActionResult EvoluirPersonagem(int id, [FromBody] EvoluirPersonagemDTO novaClasse)
        {
            try
            {
                var pl = players.Where(jogador => jogador.Id == id).FirstOrDefault();
                if (pl != null)
                {
                    pl.Classe = fichaBLL.AtualizarClasse(pl.Classe, novaClasse);
                    return Json(pl);
                }
                return NotFound();
            }catch(Exception e)
            {
                StatusCode(500, "Evoluir deu ruim" + e);                
                return null;                
            }
        }

        //PUT api/ficha/5
        [HttpPut("{id}")]
        public IActionResult AtualizarXp(int id, [FromBody] XpDTO qtdXp)
        {
            try
            {
                var pl = players.Where(jogador => jogador.Id == id).FirstOrDefault();
                if (pl != null)
                {
                    pl.Xp = fichaBLL.AtualizaXp(pl.Xp, qtdXp);
                    return Json(pl);
                }
                return NotFound();
            }catch(Exception e)
            {
                StatusCode(500, "Atualizar XP deu ruim" + e);                
                return null;                
            }
        }

        // POST api/ficha/5
        [HttpPut]
        public IActionResult AlterarFicha([FromBody]Player player)
        {
            try{
                foreach(Player pl in this.players){
                    if(pl.Id == player.Id){
                        pl.Id = player.Id;
                        pl.For = player.For;
                        pl.Car = player.Car;
                        pl.Cons = player.Cons;
                        pl.Des = player.Des;
                        pl.Int = player.Int;
                        pl.Sab = player.Sab;
                        pl.Xp = player.Xp;
                        pl.Classe = player.Classe;
                    }
                    return Json(player);
                }
                return null;
            }catch(Exception e)
            {
                StatusCode(404, "deu ruim get comum" + e);
                return null;
            }
        }

        //api/ficha/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFicha(int id)
        {
            try
            {
            foreach (Player pl in players)
            {
                if(pl.Id == id)
                {
                    players.Remove(pl);
                    return Json(players);
                }
            }
            return null;
            }catch(Exception e)
            {
                StatusCode(500, "deu ruim no delete" + e);
                return null;
            }
        }
    }
}
