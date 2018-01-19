using System.Collections.Generic;

namespace Model{

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

        public int Id   {get; set;}
        public int For  {get; set;}
        public int Int  {get; set;}
        public int Des  {get; set;}
        public int Cons {get; set;}
        public int Sab  {get; set;}
        public int Car  {get; set;}
        public string Classe {get; set;}
        public int Xp {get; set;}
        public List<Skill> Skills {get; set;}
    }
}        