using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressViewModel>> GetAll();
        Task<AddressViewModel> GetById(Guid id);
        Task<AddressViewModel> Add(AddressViewModel address);
        Task<AddressViewModel> Update(AddressViewModel address, bool ignoreUpdate = false);
        Task<bool> Delete(Guid Id);

    }
}
