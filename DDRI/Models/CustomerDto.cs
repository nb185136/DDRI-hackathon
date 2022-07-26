using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDRI.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public string IsDeleted { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RewardPoints { get; set; }


    }
}