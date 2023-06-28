using efproject.Models;
using Microsoft.EntityFrameworkCore;

namespace efproject
{
    public class TareasContext: DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        public TareasContext(DbContextOptions<TareasContext> options): base(options) { } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("31636b99-5138-4115-a766-b8e384a102ca"), Nombre = "Actividades pendientes", Peso = 20 });
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("31636b99-5138-4115-a766-b8e384a10007"), Nombre = "Actividades personales", Peso = 50 }); 


            modelBuilder.Entity<Categoria>(categoria=>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);
                categoria.HasData(categoriasInit);
            });

            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("31636b99-5138-4115-a766-b8e384a10210"), CategoriaId = Guid.Parse("31636b99-5138-4115-a766-b8e384a102ca"), PrioridadTarea = Prioridad.Media, Titulo = "Pagar servicios", FechaCreacion = DateTime.Now });
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("31636b99-5138-4115-a766-b8e384a10211"), CategoriaId = Guid.Parse("31636b99-5138-4115-a766-b8e384a10007"), PrioridadTarea = Prioridad.Alta, Titulo = "Lavarme los dientes", FechaCreacion = DateTime.Now });



            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(50);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Ignore(p => p.Resumen);
                tarea.HasData(tareasInit);
            });
        }
    }
}
