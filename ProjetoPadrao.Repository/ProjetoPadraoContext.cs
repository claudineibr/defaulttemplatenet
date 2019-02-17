using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using NLog;
using ProjetoPadrao.Domain.Model;
using ProjetoPadrao.Repository.EntityConfiguration;

namespace ProjetoPadrao.Repository
{
    public class ProjetoPadraoContext : DbContext
    {
        private readonly Guid contextGuid;

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ProjetoPadraoContext() : base("name=ProjetoPadraoContext")
        {
            // Database.SetInitializer<ProjetoPadraoContext>(new object());

            this.Configuration.ValidateOnSaveEnabled = false;

            this.Configuration.ProxyCreationEnabled = false;

            this.contextGuid = Guid.NewGuid();

            this.Database.Log = s => Logger.Debug(s);
        }

        public DbSet<MeuServico> MeuServico { get; set; }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public override string ToString()
        {
            return this.contextGuid + " - " + this.Database.Connection.ConnectionString + " - " + this.Database.Connection.State;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.ConfigEntity(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void ConfigEntity(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MeuServicoEntityConfiguration());
        }
    }
}
