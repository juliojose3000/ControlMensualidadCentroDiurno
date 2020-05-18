using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMensualidadCentroDiurno.domain
{
    class Senor
    {

        private int id;
        private string name;
        private string lastName;

        public Senor(int id, string name, string lastName)
        {
            this.Id = id;
            this.Name = name;
            this.LastName = lastName;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
