using System;
using BLL.Interface;
using DAL.Dominio;
using DAL.Model;
using DAL.DAO;

namespace BLL.Implementation
{

    public class FichaBLL : IFichaBLL
    {

        public void insert(Player player)
        {
                PlayerDAO db = new PlayerDAO();
                db.insert(player);
        }

        public void UpdatePlayer(Player player)
        {
            PlayerDAO db = new PlayerDAO();
            db.UpdatePlayer(player);
        }

        public void DeletePlayer(Player player)
        {
            PlayerDAO db = new PlayerDAO();
            db.DeletePlayer(player);
        }

        public Player SelectPlayerFind(int id)
        {
            PlayerDAO db = new PlayerDAO();
            return db.SelectPlayerFind(id);
        }

//-----------
//-----------
//-----------
//-----------

        public int AtualizaXp(int XpAtual, XpDTO XpAdiquirido)
        {
            int novoXp = System.Math.Abs(XpAdiquirido.xp);
            return XpAtual + novoXp;
        }

        public string AtualizarClasse(string ClasseAtual, EvoluirPersonagemDTO NovaClasse)
        {
            if(ClasseAtual == "Mago")
            {
                if(NovaClasse.Classe == "ArkMago")
                {
                    return "ArkMago";
                }else if(NovaClasse.Classe == "Invocador")
                {
                    return "Invocador";
                }
            }else if (ClasseAtual == "Guerreiro")
            {
                if(NovaClasse.Classe == "Gladiador")
                {
                    return "Gladiador";
                }else if(NovaClasse.Classe == "Escudeiro")
                {
                    return "Escudeiro";
                }            
            }
            return null;
        }

        public bool AdicionarSkill(AdicionarSkillDTO SkillNova, int QtdSkillFisica, int QtdSkillMagica)
        {
            if (SkillNova.tipo == "Magico")
            {
                if (QtdSkillMagica < 3)
                {
                    return true;
                }
            }else if (SkillNova.tipo == "Fisico")
            {
                if (QtdSkillFisica < 4)
                {
                    return true;
                }
            }
            return false;
        }
    }
}