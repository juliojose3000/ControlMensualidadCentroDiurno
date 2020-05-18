using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMensualidadCentroDiurno.domain
{
    class Payment
    {
        private int id;
        private string payDate;
        private string month;
        private int idSenor;

        public Payment()
        {
        }

        public Payment(int id, string payDate, string month, int idSenor)
        {
            this.Id = id;
            this.PayDate = payDate;
            this.Month = month;
            this.IdSenor = idSenor;
        }

        public int Id { get => id; set => id = value; }
        public string PayDate { get => payDate; set => payDate = value; }
        public string Month { get => month; set => month = value; }
        public int IdSenor { get => idSenor; set => idSenor = value; }
    }
}
