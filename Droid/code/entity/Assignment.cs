using System;
namespace ProjectManager.Droid.code.entity
{
    public class Assignment
    {
        private int fk_dev { get; set; }
        private int fk_proj { get; set; }
        private int fk_role { get; set; }
        private int hours_worked { get; set; }

        private Developer developer { get; set; }
        private Project project { get; set; }
        private RoleDev role{ get; set; }

        public Assignment()
        {

        }
    }
}
