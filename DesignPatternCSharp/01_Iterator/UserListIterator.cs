using System;

namespace _01_Iterator
{
    public class UserListIterator : Iterable<User>
    {
        private UserList _userList;
        private int _pos; // 今どこを指しているか

        public UserListIterator(UserList userList)
        {
            _userList = userList;
            _pos = 0;
        }
        
        public bool HasNext()
        {
            return _userList.Length() > _pos;
        }

        public User Next()
        {
            User result = _userList.At(_pos);
            _pos += 1;
            return result;
        }
    }
}
