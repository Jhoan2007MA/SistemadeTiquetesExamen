using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Application.Interfaces;

public interface IPaymentMethodsServices
{
    Task<IEnumerable<PaymentMethod>> GetAllAsync();
    Task<PaymentMethod?> GetByIdAsync(Guid id);
    Task<PaymentMethod> CreateAsync(PaymentMethod method);
    Task UpdateAsync(PaymentMethod method);
    Task DeleteAsync(Guid id);
}
