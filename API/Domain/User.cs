using System;

namespace Domain
{
    public class User
    {
       public Guid Id { get; set; }
       public string PhotoUrl {get;set;} 
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Profession { get; set; }
      
    }
}