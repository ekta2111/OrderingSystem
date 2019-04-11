using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace OrderSystem.Models
{
    public class User_Registration
    {
        

        [Key]
        public int User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string User_Address { get; set; }
        public string Email_ID { get; set; }
        public string User_Password { get; set; }
        //public string Date_Of_Birth { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string City_Name { get; set; }
        public string Zip_Code { get; set; }
        public string State_Name { get; set; }
        public Boolean User_Status { get; set; }
        

    }
}
