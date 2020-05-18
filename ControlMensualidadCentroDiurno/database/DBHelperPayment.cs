using CentroDiurnoApplication;
using ControlMensualidadCentroDiurno.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMensualidadCentroDiurno.database
{
    class DBHelperPayment
    {

        private string tableName = "payment";

        DBConnection dBConnection = new DBConnection();

        public List<Payment> read(string monthToSearch, int year)
        {

            List<Payment> listPayments = new List<Payment>();

            //string command = "select* from payment where "+ monthToSearch + "=MONTH(pay_date) and "+ year + "=YEAR(pay_date);";

            string command = "select* from payment where month='"+ monthToSearch + "' and "+year+"=YEAR(pay_date);";

            var reader = dBConnection.executeQueryCommand(command);

            Payment payment;

            if (reader == null) { return listPayments; }

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string date = reader.GetString(1);
                string month = reader.GetString(2);
                int idSenor = reader.GetInt32(3);

                payment = new Payment(id, date, month, idSenor);

                listPayments.Add(payment);

            }

            dBConnection.closeConnection();

            return listPayments;
        }

        public int maxId()
        {

            int id = -1;

            string command = "select max(id) from " + tableName + ";";

            var reader = dBConnection.executeQueryCommand(command);

            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }

            dBConnection.closeConnection();

            return id;
        }

        public Boolean insert(string payDate,string month, int idSenor)
        {

            string command = "insert into " + tableName + " (pay_date,month,id_senor) " + "values ('" + payDate + "','"+ month + "','" + idSenor + "');";

            if (dBConnection.executeNonQueryCommand(command) == 0)
            {
                return false;
            }

            dBConnection.closeConnection();

            return true;

        }

        public Boolean delete(int id)
        {

            string command = "delete from " + tableName + " where id=" + id + ";";

            if (dBConnection.executeNonQueryCommand(command) == 0)
            {
                return false;
            }

            dBConnection.closeConnection();

            return true;


        }

        public Boolean update(int id, string name, string lastName)
        {

            string command = "update " + tableName + " set name = '" + name + "', last_name = '" + lastName + "' where id = " + id + ";";

            if (dBConnection.executeNonQueryCommand(command) == 0)
            {
                return false;
            }

            dBConnection.closeConnection();

            return true;

        }










    }
}
