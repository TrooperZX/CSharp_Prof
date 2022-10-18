using HealthPlus.DataBase;
using HealthPlus.DataBase.Entities;
using HealthPlus.Core.Abstractions;
using HealthPlus.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using HealthPlus.Core.DataTransferObjects;
using Microsoft.Extensions.Configuration;
using AutoMapper;


namespace HealthPlus.Business.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public UserRoleService(IMapper mapper,
     IConfiguration configuration,
     IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public UserRoleService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetRoleNameByIdAsync(Guid id)
        {
            var role = await _unitOfWork.UserRoles.GetByIdAsync(id);
            return role != null
                ? role.Name
                : string.Empty;
        }

        public async Task<Guid?> GetRoleIdByNameAsync(string name)
        {
            var role = await _unitOfWork.UserRoles.FindBy(role1 => role1.Name.Equals(name))
                .FirstOrDefaultAsync();
            return role?.Id;
        }
        public async Task<int> CreateUserRoleAsync(UserRoleDto dto)
        {
            var entity = _mapper.Map<UserRole>(dto);
            if (entity != null)
            {
                await _unitOfWork.UserRoles.AddAsync(entity);
                var addingResult = await _unitOfWork.Commit();
                return addingResult;
            }
            else
            {
                throw new ArgumentException( nameof(dto) );
            }
        }
    }
}
