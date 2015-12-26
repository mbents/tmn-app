using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TMNApi.Models
{
    public class PlayerModel
    {
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
    }
}