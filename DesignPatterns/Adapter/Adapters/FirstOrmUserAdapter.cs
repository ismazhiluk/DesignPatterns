using System;
using Adapter.FirstOrmLibrary;
using Adapter.Models;

namespace Adapter.Adapters
{
    public class FirstOrmUserAdapter : IUserAdapter
    {
        private readonly IFirstOrm<DbUserEntity> _userOrm;
        private readonly IFirstOrm<DbUserInfoEntity> _userInfoOrm;

        public FirstOrmUserAdapter(IFirstOrm<DbUserEntity> userOrm, IFirstOrm<DbUserInfoEntity> userInfoOrm)
        {
            _userOrm = userOrm;
            _userInfoOrm = userInfoOrm;
        }

        public bool VerifyUser(int id, string login, string password)
        {
            var user = _userOrm.Read(id);
            return user.Login == login && user.PasswordHash == password.GetHashCode().ToString();
        }

        public UserInfoDto GetInfo(int id)
        {
            var userInfo = GetUserInfo(_userOrm.Read(id).UserInfoId);
            return new UserInfoDto
            {
                Name = userInfo.Name,
                Birthday = userInfo.Birthday
            };
        }

        public void EditInfo(int id, string name, DateTime birthday)
        {
            var userInfo = GetUserInfo(_userOrm.Read(id).UserInfoId);
            userInfo.Name = name;
            userInfo.Birthday = birthday;
        }

        public void EditPassword(int id, string password)
        {
            var user = _userOrm.Read(id);
            user.PasswordHash = password.GetHashCode().ToString();
        }

        private DbUserInfoEntity GetUserInfo(int id)
        {
            return _userInfoOrm.Read(id);
        }
    }
}
