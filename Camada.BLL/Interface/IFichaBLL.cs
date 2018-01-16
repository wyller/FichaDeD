
using Camada.BLL.Dominio;

public interface IFichaBLL
{
    int AtualizaXp(int XpAtual, XpDTO XpAdiquirido);
    string AtualizarClasse(string ClasseAtual, EvoluirPersonagemDTO novaClasse);
    bool AdicionarSkill(AdicionarSkillDTO SkillNova, int QtdFisica, int QtdMagica);
}