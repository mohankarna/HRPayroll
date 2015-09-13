using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;
using HRPayroll.Service.Utility;

namespace HRPayroll.Service
{
    public class UsersService : ServiceBase<Users>
    {
        public UsersService()
            : base(new UsersRepository())
        {
        }
        public override Users Add(Users entity)
        {
            entity.Password = EncryptionHelper.Encrypt(entity.Password);
            return base.Add(entity);
        }
        public bool CheckLogin(Users users)
        {
            var entity = base.Get(user => user.UserName == users.UserName);
            if (entity.Password== users.Password)
            {
                return true; 
            }
            return false;
        }
    }
}