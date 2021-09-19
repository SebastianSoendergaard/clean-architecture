using System;

namespace CleanArchitecture.Application.User.Domain
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime? DateOfBirth { get; private set; }
        public int? Age 
        { 
            get 
            {
                if (DateOfBirth == null)
                {
                    return null;
                }

                // Apparently this is harder than you should think: https://stackoverflow.com/questions/4127363/date-difference-in-years-using-c-sharp
                // so for the example I will just do it very simple even though it will not be correct i all cases
                int age = DateTime.Now.Year - DateOfBirth.Value.Year; 
                return age;
            } 
        }

        public static User Create(string name)
        {
            return new User(name);
        }

        private User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public void SetDateOfBirth(DateTime date)
        {
            if (DateOfBirth != null)
            {
                throw new InvalidOperationException("You can not be reborn");
            }

            if (date >= DateTime.Now)
            {
                throw new ArgumentException("User can not be born in the future");
            }

            DateOfBirth = date;
        }
    }
}
