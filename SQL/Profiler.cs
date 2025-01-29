using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webbshopen.Migrations;

namespace Webbshopen.SQL
{
    public class Profiler
    {
        public int Id { get; set; }
        public string? forNamn { get; set; }
        public string? efterNamn { get; set; }
        public string? adress { get; set; }
        public string? email { get; set; }
        public string? losenord { get; set; }
        public bool Admin { get; set; }
    }
}
