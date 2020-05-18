using CentroDiurnoApplication;
using ControlMensualidadCentroDiurno.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMensualidadCentroDiurno.database
{
    class DBHelperSenor
    {

        private string tableName = "senor";

        DBConnection dBConnection = new DBConnection();

        public List<Senor> read()
        {

            List<Senor> listSenores = new List<Senor>();

            //string command = "select* from fondos_propios;";
            string command = "select* from " + tableName + ";";

            var reader = dBConnection.executeQueryCommand(command);

            Senor senor;

            if (reader == null) { return listSenores; }

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string lastName = reader.GetString(2);


                senor = new Senor(id, name, lastName);

                listSenores.Add(senor);

            }

            dBConnection.closeConnection();

            return listSenores;
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

        public Boolean insert(string name, string lastName)
        {

            string command = "insert into " + tableName + " (name,last_name) " + "values ('" + name + "','" + lastName + "');";

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
