using System;

namespace _01_Iterator
{
    /// <summary>
    /// 男性だけを数え上げるイテレータ
    /// </summary>
    public class UserListMaleIterator : Iterable<User>
    {
        private UserList _userList;
        private int _pos; // 今どこを指しているか

        public UserListMaleIterator(UserList userList)
        {
            _userList = userList;
            _pos = 0;
        }
        
        public bool HasNext()
        {
            // ここで_posよりも大きい位置に男性がいるかどうか毎回みないといけなくなる
            return _userList.Length() > _pos;
        }

        public User Next()
        {
            User result = _userList.At(_pos);
            _pos += 1;
            // ここでも男性かどうかをみないといけなくなる
            if(result.Sex == User.SexType.Male)
            {
                return result;
            }
            return Next();
        }
    }
}
