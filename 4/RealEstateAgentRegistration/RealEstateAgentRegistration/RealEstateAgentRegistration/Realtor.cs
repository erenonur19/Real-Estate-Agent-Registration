using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgentRegistration
{
    public class Realtor
    {
        private int realtor_Id;
        // private string address;
        // private string realtor_Name;
        private string realtor_Username;
        private string realtor_Password;

        public int Realtor_ID { get => realtor_Id; set => realtor_Id = value; }

        //public string Address { get => address; set => address = value; }
        //public string Realtor_Name { get => realtor_Name; set => realtor_Name = value; }
        public string Realtor_Username { get => realtor_Username; set => realtor_Username = value; }
        public string Realtor_Password { get => realtor_Password; set => realtor_Password = value; }

        public Realtor(string realtor_Username, string realtor_Password)
        {
            this.Realtor_ID = realtor_Id;
            //this.Address = address;
            //this.Realtor_Name = realtor_Name;
            this.Realtor_Username = realtor_Username;
            this.Realtor_Password = realtor_Password;
        }
    }
}

