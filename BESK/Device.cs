using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESK
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string MAC { get; set; }
        public string ServiceTag { get; set; }

        //public Device (int _id, string _name, string _dep, string _mac, string _service)
        //{
        //    Id = _id;
        //    Name = _name;
        //    Department = _dep;
        //    MAC = _mac;
        //    ServiceTag = _service;
        //}
    }
}
