using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace efproject.Models{
    public class Categoria{
        //Innecesario gracias a FluentAPI
        //[Key]
        public Guid CategoriaId {get; set;} 
        //[Required]
        //[MaxLength(30)]
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public int Peso { get; set;}
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas {get;set;}
    }
}