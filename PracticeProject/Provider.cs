namespace PracticeProject
{
    internal class Provider<U> where U : User
    {
        public void CheckBalance(U user)
        {
            Console.WriteLine($"User id : {user.UserId}\nBalance: {user.Balance:C}");
        }
    }
}
