using System.Collections.Generic;
using System.Threading.Tasks;

namespace TMSAPI.Queries
{
    public interface ITMSQueries
    {
        Task<IEnumerable<AccountViewModel>> GetAccountListAsync();
        Task<List<AccountViewModel>> GetAccountListMapAsync();
        Task<IEnumerable<AccountViewModel>> GetAllAccountAsyncByMap();
        Task<AccountViewModel> GetAccountByIdAsync(int id);
        Task<IEnumerable<AccountViewModel>> AccountLoginChk(string employeeNo, string password);
        Task<AddressViewModel> GetAddressById(int addressId);
        Task<IEnumerable<AddressViewModel>> GetAddressListByAsync();
        Task<IEnumerable<VehicleViewModel>> GetVehicleListByAsync();
        Task<VehicleViewModel> GetVehicleById(int vehicleId);
        Task<IEnumerable<AddressViewModel>> GetAllAddressByAsync();
        Task<string> GenerateItem();
        Task<IEnumerable<TaskListViewModel>> GetAllTaskListByAsync();
        Task<IEnumerable<VehicleViewModel>> GetAllCarByAsync();
        Task<IEnumerable<TaskListViewModel>> GettaskListById(int taskListId);
        Task<IEnumerable<AddressViewModel>> GetaddressById(int addressId);
        Task<IEnumerable<VehicleViewModel>> GetvehicleById(int vehicleId);

        //=============================================Mobile=============================================
        Task<IEnumerable<TaskListViewModel>> GetAllTaskListAndAllDetailAsync();
        Task<IEnumerable<TaskListViewModel>> GetAllTaskListAndAllDetailBookedAsync();
        Task<IEnumerable<TaskListViewModel>> GetTaskListAndAllDetailBookedAsync(int accountId);
        Task<IEnumerable<TaskListViewModel>> GetTaskListAndAllDetailInPorgressAsync(int accountId);
        Task<IEnumerable<TaskListViewModel>> GetAllTaskListAndAllDetailInPorgressAsync();
        Task<List<AccountViewModel>> GetAccountListActiveAsync();
    }
}
