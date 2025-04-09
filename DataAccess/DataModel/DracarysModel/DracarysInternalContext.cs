using Entities.Commons;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataModel.DracarysModel
{
    /// <summary>
    /// AM-001
    /// Author: José Andrés Alvarado Matamoros
    /// Represents the database context for managing connections and configurations 
    /// to interact with the Dracarys database using a connection string provided through a DTO.
    /// </summary>
    public partial class DracarysContext : DbContext
    {
        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Stores the connection string for the database.
        /// </summary>
        private readonly string _connectionString;

        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Constructor that initializes the DbContext with a connection string obtained from the provided DataBaseDTO.
        /// </summary>
        /// <param name="dbDTO">An object containing the default connection string for the database.</param>
        /// <exception cref="Exception">Thrown if the connection string is null or not configured.</exception>
        public DracarysContext(DataBaseDTO dbDTO)
        {
            _connectionString = dbDTO.DefaultConnection ?? throw new Exception("La cadena de conexión no está configurada.");
        }

        /// <summary>
        /// AM-001
        /// Author: José Andrés Alvarado Matamoros
        /// Configures the DbContext to use the SQL Server provider with the specified connection string.
        /// </summary>
        /// <param name="optionsBuilder">The options builder for configuring the DbContext.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
