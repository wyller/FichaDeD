using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DAL.Model;

namespace DAL.Model
{
    [Table("Skill")]
    public class Skill
    {
        public Skill(string tipo, string nome)
        {
            this.tipo = tipo;
            this.nome = nome;
        }

        [Key]
        public int Id   {get; set;}

        [Required]
        [Display(Name = "Tipo Skill invalida")]
        public string tipo {get; set;}
        [Required]
        [Display(Name = "Nome Skill invalida")]
        public string nome {get; set;}
    }
}