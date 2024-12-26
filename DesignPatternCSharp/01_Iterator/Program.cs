using _01_Iterator;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var u1 = new User() {Name = "tanaka", Sex = User.SexType.Male };
var u2 = new User() {Name = "saito", Sex = User.SexType.Female };
var u3 = new User() {Name = "takahashi", Sex = User.SexType.Male };
var userList = new UserList();
userList.Add(u1);
userList.Add(u2);
userList.Add(u3);

//var iterator = userList.GetIterator();
var iterator = userList.GetMaleIterator();

while(iterator.HasNext()) 
{
    var u = iterator.Next();
    Console.WriteLine($"Name: {u.Name}, Sex: {u.Sex}");
}