using HealthPlus.Core.DataTransferObjects;

namespace HealthPlus.Core.Abstractions
{
    public interface IUserRoleService
    {
        Task<string> GetRoleNameByIdAsync(Guid id);
        Task<Guid?> GetRoleIdByNameAsync(string name);
        Task<int> CreateUserRoleAsync(UserRoleDto dto);
    }
}
