using System;
using System.Collections.Generic;

namespace ProjectManager.Droid.code.entity
{
    public class Project
    {

        private int id { get; set; }
        private String name { get; set; }
        private String description { get; set; }
        private int estimated_hours { get; set; }
        private Boolean enabled { get; set; }
        private long timestamp_created { get; set; }
        private long timestamp_modif { get; set; }
        private Assignment[] assignment { get; set; }


        public Project()
        {
        }
    }
}
