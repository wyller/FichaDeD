using Model;

namespace Model
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
}