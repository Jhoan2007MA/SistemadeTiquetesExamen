using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airlines.Application.Interfaces;

/// <summary>
/// Contrato del servicio de aplicación (Application Service) encargado de la 
/// orquestación de la lógica de negocio para las Aerolíneas (Airlines).
/// Funciona como la interfaz principal que la capa de presentación consumirá.
/// </summary>
public interface IAirlinesServices
{
    /// <summary>
    /// Obtiene de manera asíncrona el catálogo completo de todas las aerolíneas 
    /// registradas y activas en el sistema.
    /// </summary>
    /// <returns>Una colección de instancias de <see cref="Airline"/>.</returns>
    Task<IEnumerable<Airline>> GetAllAsync();

    /// <summary>
    /// Consulta una aerolínea específica utilizando su identificador único (GUID).
    /// </summary>
    /// <param name="id">El identificador único de la base de datos.</param>
    /// <returns>Devuelve la aerolínea solicitada, o nulo si no se encuentra ningún registro con ese ID.</returns>
    Task<Airline?> GetByIdAsync(Guid id);

    /// <summary>
    /// Toma los datos de una aerolínea nueva, efectúa las eventuales comprobaciones lógicas
    /// de negocio en la capa de aplicación y persiste el registro delegándolo a la Infraestructura.
    /// </summary>
    /// <param name="airline">Instancia construida de la aerolínea a insertar.</param>
    /// <returns>La misma aerolínea creada, retornada post-inserción.</returns>
    Task<Airline> CreateAsync(Airline airline);

    /// <summary>
    /// Recibe una aerolínea con sus propiedades ya modificadas para poder sincronizar
    /// y actualizar dichos cambios permanentemente en el origen de datos.
    /// </summary>
    /// <param name="airline">Instancia de la aerolínea con los datos alterados (Nombre o Código).</param>
    Task UpdateAsync(Airline airline);

    /// <summary>
    /// Consulta una aerolínea específica utilizando su código oficial (IATA/ICAO).
    /// </summary>
    /// <param name="code">El código de la aerolínea (Ej: AV, LA).</param>
    /// <returns>La aerolínea si existe, de lo contrario nulo.</returns>
    Task<Airline?> GetByCodeAsync(string code);

    /// <summary>
    /// Intenta localizar y remover (ya sea físicamente o con un borrado de estado lógico)
    /// a la aerolínea indicada a través de su identificador.
    /// </summary>
    /// <param name="id">Identificador base de la aerolínea a remover.</param>
    Task DeleteAsync(Guid id);
}
