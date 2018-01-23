using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Model; 

namespace DAL.Model{

    [Table("Player")]
    public class Player
    {

        public Player(int Id, int For, int Int, int Des, int Cons, int Sab, int Car, 
        string Classe, int Xp, List<Skill> Skills)
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
            this.Skills = Skills;

        }
        
        [Key]
        public int Id   {get; set;}
        
        [Required]
        [Display(Name = "Força invalida")]
        [Range(1,20)]
        public int For  {get; set;}
        [Required]
        [Display(Name = "Inteligencia invalida")]
        [Range(1,20)]
        public int Int  {get; set;}
        [Required]
        [Display(Name = "Destresa invalida")]
        [Range(1,20)]
        public int Des  {get; set;}
        [Required]
        [Display(Name = "Constituição invalida")]
        [Range(1,20)]
        public int Cons {get; set;}
        [Required]
        [Display(Name = "Sabedoria invalida")]
        [Range(1,20)]
        public int Sab  {get; set;}
        [Required]
        [Display(Name = "Carisma invalida")]
        [Range(1,20)]
        public int Car  {get; set;}
        [Required]
        [Display(Name = "Classe invalida")]
        [Range(1,20)]
        public string Classe {get; set;}
        [Required]
        [Display(Name = "Experiencia informanda")]
        public int Xp {get; set;}
        public List<Skill> Skills {get; set;}
    }
}        