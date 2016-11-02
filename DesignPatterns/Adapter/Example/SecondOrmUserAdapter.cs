using System;
using System.Linq;
using Adapter.Models;
using Adapter.SecondOrmLibrary;

namespace Adapter.Example
{
    public class SecondOrmUserAdapter : IUserAdapter
    {
        private readonly ISecondOrm _secondOrm;

        public SecondOrmUserAdapter(ISecondOrm secondOrm)
        {
            _secondOrm = secondOrm;
        }

        public bool VerifyUser(int id, string login, string password)
        {
            return _secondOrm.Context.Users.Any(i => i.Id == id && i.Login == login && i.PasswordHash == password.GetHashCode().ToString());
        }

        public UserInfoDto GetInfo(int id)
        {
            var userInfo = GetUserInfo(GetUser(id).UserInfoId);
            return new UserInfoDto
            {
                Name = userInfo.Name,
                Birthday = userInfo.Birthday
            };
        }

        public void EditInfo(int id, string name, DateTime birthday)
        {
            var userInfo = GetUserInfo(GetUser(id).UserInfoId);

            userInfo.Name = name;
            userInfo.Birthday = birthday;
        }

        public void EditPassword(int id, string password)
        {
            var user = GetUser(id);
            user.PasswordHash = password.GetHashCode().ToString();
        }

        private DbUserEntity GetUser(int id)
        {
            return _secondOrm.Context.Users.FirstOrDefault(i => i.Id == id);
        }

        private DbUserInfoEntity GetUserInfo(int id)
        {
            return _secondOrm.Context.UserInfos.FirstOrDefault(i => i.Id == id);
        }
    }
}
