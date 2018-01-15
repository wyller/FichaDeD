public class FichaBLL : IFichaBLL
{
    public int AtualizaXp(int XpAtual, XpDTO XpAdiquirido)
    {
        return XpAtual + XpAdiquirido.xp;
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
}