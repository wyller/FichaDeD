
public interface IFichaBLL
{
    int AtualizaXp(int XpAtual, XpDTO XpAdiquirido);
    string AtualizarClasse(string ClasseAtual, EvoluirPersonagemDTO novaClasse);
}