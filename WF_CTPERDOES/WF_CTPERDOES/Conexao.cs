using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_CTPERDOES
{
    class Conexao
    {

        public string sql = "";

        MySqlConnection conecta = new MySqlConnection();

        public int Runsql()
        {
            int nrlinhas;
            try
            {

                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = sql;
                comando.Connection = conecta;

                nrlinhas = comando.ExecuteNonQuery();

            }
            catch
            {
                nrlinhas = 0;
            }

            return nrlinhas;
        }

        public MySqlDataReader Execsql()
        {

            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = sql;
            comando.Connection = conecta;

            MySqlDataReader dados = comando.ExecuteReader();

            return dados;
        }


        public int ExecuteScalar()
        {

            Int32 conta = 0;

            try
            {


                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = sql;
                comando.Connection = conecta;

                conta = (Int32)comando.ExecuteScalar();
            }
            catch
            {
                conta = 0;
            }
            return conta;

        }


        public void open()
        {
           
                if (conecta.State == ConnectionState.Closed)
                {
                    conecta.ConnectionString = ("Server=localhost;Database=bd_ctperdoes;User=root;Pwd=''");
                    conecta.Open();
                }
            
           
        }

        public void close()
        {
            if (conecta.State == ConnectionState.Open)
            {
                conecta.Close();
            }
        }

    }
}
