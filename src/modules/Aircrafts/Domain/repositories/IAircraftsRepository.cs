using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;

/// <summary>
/// Contrato del repositorio para el agregado Aircraft (Aeronave).
/// Abstrae la persistencia de datos (base de datos) del modelo de dominio.
/// </summary>
public interface IAircraftsRepository
{
    /// <summary>
    /// Obtiene una aeronave específica buscando por su identificador único.
    /// </summary>
    /// <param name="id">El identificador único (Guid) de la aeronave.</param>
    /// <returns>La entidad de la Aeronave, o un valor nulo si no se encuentra en persistencia.</returns>
    Task<Aircraft?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtiene una aeronave específica buscando mediante su matrícula de registro (Registration Number).
    /// </summary>
    /// <param name="registrationNumber">La matrícula (ej. HK-5301).</param>
    /// <returns>La entidad de la Aeronave, o un valor nulo si no se encuentra en persistencia.</returns>
    Task<Aircraft?> GetByRegistrationNumberAsync(string registrationNumber);

    /// <summary>
    /// Obtiene el listado completo de aeronaves registradas en el sistema.
    /// (Esta consulta puede extenderse para admitir paginación en el futuro).
    /// </summary>
    /// <returns>Colección asíncrona de todas las aeronaves (IEnumerable).</returns>
    Task<IEnumerable<Aircraft>> GetAllAsync();

    /// <summary>
    /// Verifica de manera asíncrona si ya existe una aeronave matriculada con ese número.
    /// Es muy útil para validar reglas de negocio antes de intentar crear un registro duplicado.
    /// </summary>
    /// <param name="registrationNumber">El número de matrícula a verificar.</param>
    /// <returns>Verdadero si ya existe en base de datos, Falso en caso contrario.</returns>
    Task<bool> ExistsByRegistrationAsync(string registrationNumber);

    /// <summary>
    /// Agrega y persiste una nueva instancia de aeronave en la base de datos.
    /// </summary>
    /// <param name="aircraft">La instancia de Aircraft a guardar.</param>
    Task AddAsync(Aircraft aircraft);

    /// <summary>
    /// Actualiza el estado o información de una aeronave existente en la persistencia.
    /// </summary>
    /// <param name="aircraft">La instancia de Aircraft con la información y estado modificados.</param>
    Task UpdateAsync(Aircraft aircraft);

    /// <summary>
    /// Elimina de forma permanente un registro de aeronave a partir de su identificador.
    /// Dependiendo de la implementación concreta, puede ser un "Soft Delete" o eliminación física real.
    /// </summary>
    /// <param name="id">El identificador de la aeronave que se quiere eliminar.</param>
    Task DeleteAsync(Guid id);
}
