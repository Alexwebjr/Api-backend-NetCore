using ApiTestBK.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiTestBK.Models
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Contribuyente> Contribuyentes { get; set; }
        public DbSet<ComprobanteFiscal> ComprobantesFiscales { get; set; }

        //DataInicial Temporal
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Contribuyentes
            modelBuilder.Entity<Contribuyente>().HasData(
                new Contribuyente { Id = 1, RncCedula = "00112345678", Nombre = "JUAN PEREZ", Tipo = "PERSONA FISICA", Estatus = "activo" },
                new Contribuyente { Id = 2, RncCedula = "00187654321", Nombre = "MARIA LOPEZ", Tipo = "PERSONA FISICA", Estatus = "activo" },
                new Contribuyente { Id = 3, RncCedula = "13145678901", Nombre = "EMPRESAS DOMINICANAS SRL", Tipo = "PERSONA JURIDICA", Estatus = "inactivo" },
                new Contribuyente { Id = 4, RncCedula = "40211222333", Nombre = "PEDRO GARCIA", Tipo = "PERSONA FISICA", Estatus = "suspendido" },
                new Contribuyente { Id = 5, RncCedula = "40199887766", Nombre = "SOLUCIONES TECNICAS EIRL", Tipo = "PERSONA JURIDICA", Estatus = "activo" }
            );

            // Comprobantes
            modelBuilder.Entity<ComprobanteFiscal>().HasData(
                new ComprobanteFiscal { Id = 1, RncCedula = "00112345678", NCF = "E310000000001", Monto = 200.00m, Itbis18 = 36.00m, ContribuyenteId = 1 },
                new ComprobanteFiscal { Id = 2, RncCedula = "00112345678", NCF = "E310000000002", Monto = 1500.00m, Itbis18 = 270.00m, ContribuyenteId = 1 },
                new ComprobanteFiscal { Id = 3, RncCedula = "00187654321", NCF = "E310000000003", Monto = 500.00m, Itbis18 = 90.00m, ContribuyenteId = 2 },
                new ComprobanteFiscal { Id = 4, RncCedula = "13145678901", NCF = "B010000000001", Monto = 10000.00m, Itbis18 = 1800.00m, ContribuyenteId = 3 },
                new ComprobanteFiscal { Id = 5, RncCedula = "13145678901", NCF = "B010000000002", Monto = 7500.00m, Itbis18 = 1350.00m, ContribuyenteId = 3 },
                new ComprobanteFiscal { Id = 6, RncCedula = "13145678901", NCF = "B010000000003", Monto = 2500.00m, Itbis18 = 450.00m, ContribuyenteId = 3 },
                new ComprobanteFiscal { Id = 7, RncCedula = "40199887766", NCF = "E310000000004", Monto = 1200.00m, Itbis18 = 216.00m, ContribuyenteId = 5 },
                new ComprobanteFiscal { Id = 8, RncCedula = "40199887766", NCF = "E310000000005", Monto = 300.00m, Itbis18 = 54.00m, ContribuyenteId = 5 }
            );
        }

    }
}
