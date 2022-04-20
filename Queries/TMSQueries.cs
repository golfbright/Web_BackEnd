

using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TMSAPI.Queries
{
    public class TMSQueries : ITMSQueries
    {
        private readonly string _connectionString;

        public TMSQueries(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<AccountViewModel> GetAccountByIdAsync(int accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT ac.*,acr.Id as 'AccountRoleId',acr.RoleId  FROM Account ac
                            LEFT JOIN AccountRoles acr ON acr.AccountId = ac.Id
                            WHERE ac.Id = @accountId";

                var result = await connection.QueryAsync<dynamic>(query, new { accountId });

                return MapAccount(result);
            }

        }

        private AccountViewModel MapAccount(dynamic result)
        {
            var account = new AccountViewModel()
            {
                Id = result[0].Id,
                EmployeeNo = result[0].EmployeeNo,
                CardId = result[0].CardId,
                DriverLicense = result[0].DriverLicense,
                FirstName = result[0].FirstName,
                LastName = result[0].LastName,
                Password = result[0].Password,
                Status = result[0].Status,
                Tel = result[0].Tel,
                ImageProfilePath = result[0].ImageProfilePath,
                AccountRoles = new List<AccountRoleViewModel>()
            };
            foreach (var role in result)
            {
                if (role.RoleId != null)
                {
                    var accountRole = new AccountRoleViewModel()
                {
                    Id = role.AccountRoleId,
                    AccountId = role.Id,
                    RoleId = role.RoleId
                };
                    account.AccountRoles.Add(accountRole);
                }
                
            }

            return account;
        }

        public async Task<IEnumerable<AccountViewModel>> GetAccountListAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM account";

                var result = await connection.QueryAsync<AccountViewModel>(query);


                //return MapAccountForGet(result);
                return result;
            }
        }

        public async Task<List<AccountViewModel>> GetAccountListMapAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM account";

                var result = await connection.QueryAsync<dynamic>(query);


                return MapAccountForGet(result);
            }
        }
        private List<AccountViewModel> MapAccountForGet(dynamic result)
        {
            var accountList = new List<AccountViewModel>();

            foreach (var res in result)
            {
                var account = new AccountViewModel()
                {
                    Id = res.Id,
                    EmployeeNo = res.EmployeeNo,
                    CardId = res.CardId,
                    DriverLicense = res.DriverLicense,
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Password = res.Password,
                    Status = res.Status,
                    Tel = res.Tel,
                    ImageProfilePath = res.ImageProfilePath,
                };
                accountList.Add(account);
            }

            return accountList;

        }
        public async Task<IEnumerable<AccountViewModel>> GetAllAccountAsyncByMap()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT ac.*,acr.Id as 'AccountRoleId',acr.RoleId,ro.RoleName
                            FROM Account ac
                            LEFT JOIN AccountRoles acr ON acr.AccountId = ac.Id
                            LEFT JOIN Role ro ON ro.Id = acr.RoleId";

                var result = await connection.QueryAsync<dynamic>(query);
                return MapAccountList(result);
            }
        }
        private IEnumerable<AccountViewModel> MapAccountList(dynamic result)
        {
            var accountAllData = new List<AccountViewModel>();

            foreach (var getData in result)
            {
                var checkData = accountAllData.FirstOrDefault(x => x.Id == getData.Id);
                if (checkData == null)
                {
                    var account = new AccountViewModel()
                    {
                        Id = getData.Id,
                        EmployeeNo = getData.EmployeeNo,
                        CardId = getData.CardId,
                        DriverLicense = getData.DriverLicense,
                        FirstName = getData.FirstName,
                        LastName = getData.LastName,
                        Password = getData.Password,
                        Status = getData.Status,
                        Tel = getData.Tel,
                        ImageProfilePath = getData.ImageProfilePath,
                        AccountRoles = new List<AccountRoleViewModel>()
                    };
                    foreach (var role in result)
                    {
                        if (role.RoleId != null && getData.Id == role.Id)
                        {
                            var accountRole = new AccountRoleViewModel()
                            {
                                Id = role.AccountRoleId,
                                AccountId = role.Id,
                                RoleId = role.RoleId,
                                RoleName = role.RoleName,
                            };
                            account.AccountRoles.Add(accountRole);
                        }

                    }
                    accountAllData.Add(account);
                }
            }
            return accountAllData;
        }
        public async Task<IEnumerable<AccountViewModel>> AccountLoginChk(string employeeNo,string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT ac.*,acr.Id as 'AccountRoleId',acr.RoleId,ro.RoleName
                            FROM Account ac
                            LEFT JOIN AccountRoles acr ON acr.AccountId = ac.Id
                            LEFT JOIN Role ro ON ro.Id = acr.RoleId
                            WHERE (ac.Id = accountId and ac.EmployeeNo = @employeeNo and ac.Password = @password) or (ac.EmployeeNo = @employeeNo and ac.Password = @password)";

                var result = await connection.QueryAsync<dynamic>(query, new { employeeNo, password });

                return MapAccountList(result);
            }
        }

        public async Task<IEnumerable<AddressViewModel>> GetAddressListByAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM Address";

                var result = await connection.QueryAsync<AddressViewModel>(query);

                return result;
            }
        }

        public async Task<AddressViewModel> GetAddressById(int addressId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"Select * From Address 
                                Where Address.Id = @addressId";

                var result = await connection.QueryAsync<dynamic>(query, new { addressId });

                return MapAddress(result);
            }
        }

        private AddressViewModel MapAddress(dynamic result)
        {
            var address = new AddressViewModel()
            {
                Id = result.Id,
                NamePlace = result.NamePlace,
                Gps = result.Gps,
                AddressNumber = result.AddressNumber,
                District = result.District,
                Country = result.Country,
                Street = result.Street,
                ZipCode = result.ZipCode,
                Province = result.Province,

            };
            return address;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetVehicleListByAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM Vehicle";

                var result = await connection.QueryAsync<VehicleViewModel>(query);

                return result;
            }
        }

        public async Task<VehicleViewModel> GetVehicleById(int vehicleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"Select * Form Vehicle
                              Where Vehicle.Id = @vehicleId";
                var result = await connection.QueryAsync(query, new { vehicleId });
                return MapVehicle(result);
            }
        }

        private VehicleViewModel MapVehicle(dynamic result)
        {
            var vehicle = new VehicleViewModel()
            {
                Id = result.Id,
                VehicleType = result.VehicleType,
                VehicleBrand = result.VehicleBrand,
                VehiclePlate = result.VehiclePlate,
                VehicleStatus = result.VehicleStatus,
            };
            return vehicle;
        }

        public async Task<IEnumerable<AddressViewModel>> GetAllAddressByAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM Address";

                var result = await connection.QueryAsync<AddressViewModel>(query);

                return result;
            }
        }
        public async Task<string> GenerateItem()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"BEGIN TRANSACTION
                    declare @number int;

                    SELECT @number = number + 1 FROM GenerateConfigs WITH (ROWLOCK, UPDLOCK) where [KeyWord] = 'BG'

                    update GenerateConfigs set number = @number where [KeyWord] = 'BG';

                    select * from GenerateConfigs

                    COMMIT TRANSACTION";

                var result = await connection.QuerySingleAsync<dynamic>(query);

                var code = String.Format(result.Format, result.Number);

                return code;

            }
        }

        public async Task<IEnumerable<TaskListViewModel>> GetAllTaskListByAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM TaskList";

                var result = await connection.QueryAsync<TaskListViewModel>(query);

                return result;
            }
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAllCarByAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"SELECT * FROM Vehicle Where Vehicle.VehicleStatus = 'Ready'";

                var result = await connection.QueryAsync<VehicleViewModel>(query);

                return result;
            }
        }

        public async Task<IEnumerable<TaskListViewModel>> GettaskListById(int taskListId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"Select * From TaskList
                              Where TaskList.Id = @taskListId";

                var result = await connection.QueryAsync<TaskListViewModel>(query, new { taskListId });

                return result;
            }
        }

        public async Task<IEnumerable<AddressViewModel>> GetaddressById(int addressId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"Select * From Address
                              Where Address.Id = @addressId";

                var result = await connection.QueryAsync<AddressViewModel>(query, new { addressId });

                return result;
            }
        }

        public async Task<IEnumerable<VehicleViewModel>> GetvehicleById(int vehicleId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"Select * From Vehicle
                              Where Vehicle.Id = @vehicleId";

                var result = await connection.QueryAsync<VehicleViewModel>(query, new { vehicleId });

                return result;
            }
        }

        //=============================================Mobile=============================================
        public async Task<IEnumerable<TaskListViewModel>> GetAllTaskListAndAllDetailAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"select a.*,b.NamePlace,b.Gps,b.AddressNumber,b.District,b.Country,b.Street,b.ZipCode,b.Province,c.VehicleType,c.VehicleBrand,c.VehiclePlate,c.VehicleStatus from TaskList a 
                              LEFT JOIN Address b ON b.id = a.AddressId
                              LEFT JOIN Vehicle c ON c.id = a.VehicleId
                              WHERE a.TaskStatus = N'ยังไม่ได้ดำเนินการ'  and a.AccountId = 0 ";

                var result = await connection.QueryAsync<TaskListViewModel>(query);

                return result;
            }
        }

        public async Task<IEnumerable<TaskListViewModel>> GetAllTaskListAndAllDetailBookedAsync(int accountId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"select a.*,b.NamePlace,b.Gps,b.AddressNumber,b.District,b.Country,b.Street,b.ZipCode,b.Province,c.VehicleType,c.VehicleBrand,c.VehiclePlate,c.VehicleStatus from TaskList a 
                              LEFT JOIN Address b ON b.id = a.AddressId
                              LEFT JOIN Vehicle c ON c.id = a.VehicleId
                              WHERE a.TaskStatus = N'ได้รับการจอง'  and a.AccountId = @accountId ";

                var result = await connection.QueryAsync<TaskListViewModel>(query, new { accountId });

                return result;
            }
        }
        public async Task<List<AccountViewModel>> GetAccountListActiveAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"select * from Account where Status = 'Active'";

                var result = await connection.QueryAsync<dynamic>(query);


                return MapAccountForGet(result);
            }
        }
    }
}