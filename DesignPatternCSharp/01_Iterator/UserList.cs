using System;

namespace _01_Iterator
{
    public class UserList : Aggregator
    {
        User[] _userList;

        public UserList()
        {
            _userList = new User[]();
        }

        public Add(User user)
        {
            _userList.Add(user);
        }

        Iterable GetIterator()
        {
            return new UserListIterator(this);
        }
    }
}
