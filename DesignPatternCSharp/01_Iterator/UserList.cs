using System;

namespace _01_Iterator
{
    public class UserList : Aggregator<User>
    {
        List<User> _userList;

        public UserList()
        {
            _userList = new List<User>();
        }

        public void Add(User user)
        {
            _userList.Add(user);
        }

        public User At(int index)
        {
            return _userList[index];
        }

        public int Length()
        {
            return _userList.Count();
        }

        public Iterable<User> GetIterator()
        {
            return new UserListIterator(this);
        }

        public Iterable<User> GetMaleIterator()
        {
            return new UserListMaleIterator(this);
        }

        //public Iterable<User> GetIterator(Func<User, bool> clause)
        //{
        //    return new UserListWhereIterator(this, clause);
        //}
    }
}
