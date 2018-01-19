using System;
using BLL.Implementation;
using BLL.Dominio;
using Xunit;

namespace Test
{
    public class AdicionarSkill_Test
    {
        [Fact]
        public void DeveRetornarTrueQuandoAQtdSkillFisicaEQtdSkillMagicaForemMenorQue4e3Sucessivamente()
        {

            FichaBLL fichaBLL = new FichaBLL();

            AdicionarSkillDTO newSkill = new AdicionarSkillDTO();
            newSkill.nome = "Voadora";
            newSkill.tipo = "Magico";

            int qtdSkillFisica = 1;
            int qtdSkillMagica = 1;

            bool result = fichaBLL.AdicionarSkill(newSkill, qtdSkillFisica, qtdSkillMagica);
        
            Assert.True(result);
        }

        [Fact]
        public void DeveRetornarTrueQuandoAQtdSkillFisicaEQtdSkillMagicaForemNegativas()
        {
            
            FichaBLL fichaBLL = new FichaBLL();

            AdicionarSkillDTO newSkill = new AdicionarSkillDTO();
            newSkill.nome = "Voadora";
            newSkill.tipo = "Magico";

            int qtdSkillFisica = -1;
            int qtdSkillMagica = -3;

            bool result = fichaBLL.AdicionarSkill(newSkill, qtdSkillFisica, qtdSkillMagica);
        
            Assert.True(result);
        }

        [Fact]
        public void DeveRetornarFalseQuandoAQtdSkillFisicaEQtdSkillMagicaForemMaioresOuIguaisQue4e3Sucessivamente()
        {
            
            FichaBLL fichaBLL = new FichaBLL();

            AdicionarSkillDTO newSkill = new AdicionarSkillDTO();
            newSkill.nome = "Voadora";
            newSkill.tipo = "Magico";

            int qtdSkillFisica = 4;
            int qtdSkillMagica = 3;

            bool result = fichaBLL.AdicionarSkill(newSkill, qtdSkillFisica, qtdSkillMagica);
        
            Assert.False(result);
        }

        [Fact]
        public void DeveRetornarFalseQuandoAQtdSkillFisicaOuQtdSkillMagicaForemMaioresOuIguaisQue4e3Sucessivamente()
        {
            
            FichaBLL fichaBLL = new FichaBLL();

            AdicionarSkillDTO newSkill = new AdicionarSkillDTO();

            int qtdSkillFisica = 1;
            int qtdSkillMagica = 3;

            bool result = fichaBLL.AdicionarSkill(newSkill, qtdSkillFisica, qtdSkillMagica);
        
            Assert.False(result);
        }
    }

    public class AtualizarClasse_Test
    {
        [Fact]
        public void DeveRetornarTrueQuandoAClasseAntigaForMagoEAClasseNovaForArkMago()
        {
            FichaBLL fichaBLL = new FichaBLL();

            EvoluirPersonagemDTO novaClasse = new EvoluirPersonagemDTO();
            novaClasse.Classe = "ArkMago";
            string ClasseAntiga = "Mago";

            string result = fichaBLL.AtualizarClasse(ClasseAntiga, novaClasse);
        
            Assert.True(string.Equals(result, "ArkMago"));
        }

        [Fact]
        public void DeveRetornarTrueQuandoAClasseAntigaForMagoEAClasseNovaForInvocador()
        {
            FichaBLL fichaBLL = new FichaBLL();

            EvoluirPersonagemDTO novaClasse = new EvoluirPersonagemDTO();
            novaClasse.Classe = "Invocador";
            string ClasseAntiga = "Mago";

            string result = fichaBLL.AtualizarClasse(ClasseAntiga, novaClasse);
        
            Assert.True(string.Equals(result, "Invocador"));
        } 

        [Fact]
        public void DeveRetornarTrueQuandoAClasseAntigaForGuerreiroEAClasseNovaForGladiador()
        {
            FichaBLL fichaBLL = new FichaBLL();

            EvoluirPersonagemDTO novaClasse = new EvoluirPersonagemDTO();
            novaClasse.Classe = "Gladiador";
            string ClasseAntiga = "Guerreiro";

            string result = fichaBLL.AtualizarClasse(ClasseAntiga, novaClasse);
        
            Assert.True(string.Equals(result, "Gladiador"));
        } 

        [Fact]
        public void DeveRetornarTrueQuandoAClasseAntigaForGuerreiroEAClasseNovaForEscudeiro()
        {
            FichaBLL fichaBLL = new FichaBLL();

            EvoluirPersonagemDTO novaClasse = new EvoluirPersonagemDTO();
            novaClasse.Classe = "Escudeiro";
            string ClasseAntiga = "Guerreiro";

            string result = fichaBLL.AtualizarClasse(ClasseAntiga, novaClasse);
        
            Assert.True(string.Equals(result, "Escudeiro"));
        }

        [Fact]
        public void DeveRetornarFalseQuandoAClasseAntigaForGuerreiroEAClasseNovaNaoForEscudeiroOuGladiador()
        {
            FichaBLL fichaBLL = new FichaBLL();

            EvoluirPersonagemDTO novaClasse = new EvoluirPersonagemDTO();
            novaClasse.Classe = "ArkMago";
            string ClasseAntiga = "Gerreiro";

            string result = fichaBLL.AtualizarClasse(ClasseAntiga, novaClasse);
        
            Assert.False(result != null);
        }

        [Fact]
        public void DeveRetornarFalseQuandoAClasseAntigaForMagoEAClasseNovaNaoForArkMagoOuInvocador()
        {
            FichaBLL fichaBLL = new FichaBLL();

            EvoluirPersonagemDTO novaClasse = new EvoluirPersonagemDTO();
            novaClasse.Classe = "Gladiador";
            string ClasseAntiga = "Mago";

            string result = fichaBLL.AtualizarClasse(ClasseAntiga, novaClasse);
        
            Assert.False(result != null);
        }
    }

    public class AtualizaXp_Test
    {
        [Fact]
        public void DeveRetornarTrueQuandoOValorXpAntipoEXpNovoForPositivos()
        {
            FichaBLL fichaBLL = new FichaBLL();

            XpDTO xpNovo = new XpDTO();
            xpNovo.xp = 100;

            int xpAntigo = 150;

            int result = fichaBLL.AtualizaXp(xpAntigo, xpNovo);

            Assert.Equal(result, 250);
        }

        [Fact]
        public void DeveRetornarTrueQuandoOValorXpAntipoForNegativoEXpNovoForPositivos()
        {
            FichaBLL fichaBLL = new FichaBLL();

            XpDTO xpNovo = new XpDTO();
            xpNovo.xp = -100;

            int xpAntigo = 150;

            int result = fichaBLL.AtualizaXp(xpAntigo, xpNovo);

            Assert.Equal(result, 250);
        }

    }
}