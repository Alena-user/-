using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace практика_ис1
{
    public class MenuItem
    {
        public int Id { get; }
        public string Name { get; }
        public Action Method { get; }
        
       
        public MenuItem(int id, string name, Action method)
        {
            Id = id;
            Name = name;
            Method = method;
            
        }

    }
}
