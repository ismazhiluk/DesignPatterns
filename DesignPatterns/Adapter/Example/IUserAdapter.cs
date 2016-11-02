using System;

namespace Adapter.Example
{
    public interface IUserAdapter
    {
        bool VerifyUser(int id, string login,string password);
        UserInfoDto GetInfo(int id);
        void EditInfo(int id, string name, DateTime birthday);
        void EditPassword(int id, string password);
    }
}
