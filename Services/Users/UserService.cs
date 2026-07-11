using SGC_Database_Backup.Entities;
using SGC_Database_Backup.Services.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGC_Database_Backup.Services.Users
{
    public class UserService(IUnitOfWork unitOfWork):IUserService
    {
        public async Task<User?> FindByIdAsync(int userId)
        {
            return await unitOfWork.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await unitOfWork.Users.GetAllAsync();
        }

        public async Task SaveChanges(User? userToEdit)
        {
            if (userToEdit == null)
            {
                throw new Exception("Datos Erroneos");
            }
            else
            {
                if (await unitOfWork.Users.AnyAsync(x => x.Id == userToEdit.Id))
                {
                    await unitOfWork.Users.UpdateAsync(userToEdit);
                }
                else
                {
                    await unitOfWork.Users.CreateAsync(userToEdit);
                }
            }
        }
    }
}