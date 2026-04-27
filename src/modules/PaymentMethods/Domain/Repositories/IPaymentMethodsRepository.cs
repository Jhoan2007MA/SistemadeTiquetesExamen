using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;

public interface IPaymentMethodsRepository
{
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
    Task<PaymentMethod?> GetByIdAsync(Guid id);
    Task AddAsync(PaymentMethod method);
    Task UpdateAsync(PaymentMethod method);
    Task DeleteAsync(Guid id);
}
