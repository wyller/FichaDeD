using Camada.BLL.Implementation;
using Camada.BLL.Dominio;
using Xunit;

namespace Prime.UnitTests.Services
{

     public class Skill
    {
        public Skill(string tipo, string nome)
        {
            this.tipo = tipo;
            this.nome = nome;
        }

        public string tipo {get; set;}
        public string nome {get; set;}
    }

    public class PrimeService_IsPrimeShould
    {
        FichaBLL fichaBLL = new FichaBLL();

        AdicionarSkillDTO newSkill = new AdicionarSkillDTO();
        int qtdSkillFisica = 0;

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void AdicionarSkillTest(int qtdSkillMagica)
        {
            bool result = fichaBLL.AdicionarSkill(newSkill, qtdSkillFisica, qtdSkillMagica);
        
            Assert.False(result, $" Não foi possivel adicionar a Skill{newSkill}: QtdMagico= {qtdSkillMagica}, QtdFisico= {qtdSkillFisica}");
        }
    }
}