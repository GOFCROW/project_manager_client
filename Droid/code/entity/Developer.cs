using System;
namespace ProjectManager.Droid.code.entity
{
    public class Developer
    {

        private int id { get; set; }
        private String first_name { get; set; }
        private String last_name { get; set; }
        private String phone_number { get; set; }
        private String experience { get; set; }
        private String skills { get; set; }
        private String email { get; set; }
        private Boolean enabled { get; set; }

        private Assignment asignments { get; set; }

        public Developer()
        {
        }
    }
}
