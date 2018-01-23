using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Dominio;
using DAL.Model;
using BLL.Interface;
using BLL.Implementation;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    public class FichaController : Controller
    {
        IFichaBLL fichaBLL = new FichaBLL();

        public List<Player> players = new List<Player>()
        {
            new Player(1, 03, 16, 05, 07,14, 11, "Mago", 150, new List<Skill>
            {
                new Skill("Magico", "FireBall"),
                new Skill("Magico", "Blink")
            }),
            new Player(2, 18, 03, 11, 16, 03, 14, "Guerreiro", 120, new List<Skill>
            {
                new Skill("Magico", "FireBall"),
                new Skill("Magico", "Blink")
            }),            
            new Player(3, 11, 11, 18, 11, 06, 18, "Guerreiro", 70, new List<Skill>
            {
                new Skill("Magico", "FireBall"),
                new Skill("Magico", "Blink")
            })
        };

        // GET api/ficha
        [HttpGet]
        public IActionResult getAll()
        {
            try
            {
                return Json(players);
            }catch(Exception e)
            {
                StatusCode(500, "deu ruim get comum" + e);
                return null;
            }
        }
        
        // GET api/ficha/5
        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            try
            {
                var pl = players.Where(jogador=>jogador.Id == id).FirstOrDefault();
                if (pl == null)
                {
                return Json(pl);  
                    
                }
                
                return null;
            }
            catch(Exception e)
            {
                StatusCode(500, "deu ruim get id" + e
            );
                return null;
            }
        }

        // GET api/ficha/int/5
        [HttpGet("int/{id}")]
        public IActionResult GetInteligencia(int id)
        {
            try
            {
                foreach(Player pl in players)
                {
                    if(pl.Id == id)
                        return Json(pl.Int);  
                }
                return null;
            }
            catch(Exception e)
            {
                StatusCode(500, "deu ruim get id" + e);
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
                fichaBLL.insert(pl);
                return Json(players);
            }
            catch(Exception e)
            {
                StatusCode(500, "post deu ruim" + e);
                return null;
            }
        }

        //PUT api/ficha/5
        [HttpPut("evoluir/{id}")]
        public IActionResult EvoluirPersonagem(int id, [FromBody] EvoluirPersonagemDTO novaClasse)
        {
            try
            {
                var pl = players.Where(jogador => jogador.Id == id).FirstOrDefault();
                if (pl != null)
                {
                    string result = fichaBLL.AtualizarClasse(pl.Classe, novaClasse);
                    if(result != null)
                    {
                        pl.Classe = result;
                    }
                    return Json(pl);
                }
                return NotFound();
            }catch(Exception e)
            {
                StatusCode(500, "Evoluir deu ruim" + e);                
                return null;                
            }
        }

        //PUT api/ficha/addxp/5
        [HttpPut("addxp/{id}")]
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
                return Json(pl);
            }catch(Exception e)
            {
                StatusCode(500, "Atualizar XP deu ruim" + e);                
                return null;                
            }
        }

        //PUT api/ficha/5
        [HttpPut("addabilidade/{id}")]
        public IActionResult AdicionarSkill(int id, [FromBody] AdicionarSkillDTO novaSkill)
        {
            int QtdSkillsFisicas = 0;
            int QtdSkillsMagicas = 0;
            Skill newSkill = new Skill(novaSkill.tipo, novaSkill.nome);

            var pl = players.Where(jogador => jogador.Id == id).FirstOrDefault();
            foreach (Skill Skill in pl.Skills)
            {
                if (Skill.tipo == "Magico")
                {
                    QtdSkillsMagicas++;
                }else if (Skill.tipo == "Fisico")
                {
                    QtdSkillsFisicas++;
                }
            }
            if((fichaBLL.AdicionarSkill(novaSkill, QtdSkillsFisicas, QtdSkillsMagicas)))
            {

                pl.Skills.Add(newSkill);
                return Json(pl);
            }
                return Json(pl);           
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
