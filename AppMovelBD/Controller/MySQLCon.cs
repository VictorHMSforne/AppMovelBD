using System;
using System.Collections.Generic;
using System.Text;

using System.Data; //adicionei
using MySqlConnector;//adicionei
using AppMovelBD.Models;//adicionei

namespace AppMovelBD.Controller
{
    public class MySQLCon //remover o internal
    {
        static string conn = @"server=sql.freedb.tech;port=3306;database=freedb_Tds10_Senai;user id=freedb_abcdeTOP;password=BzPy2MPagcF*qe&;charset=utf8";//o @ é um tipo de interpolação 

        public static List<Pessoa> ListarPessoas()
        {
            List<Pessoa> listapessoas = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader()) 
                    {
                        while (reader.Read())
                        {
                            Pessoa pessoa = new Pessoa()
                            {
                                id = reader.GetInt32(0),
                                nome = reader.GetString(1),
                                idade = reader.GetString(2),
                                cidade = reader.GetString(3),
                            };
                            listapessoas.Add(pessoa);
                        }
                    }
                }
                con.Close();
                return listapessoas;
            }
        }

        public static void InserirPessoa(string nome,string idade,string cidade)
        {
            string sql = "INSERT INTO pessoa(nome,idade,cidade) VALUES (@nome,@idade,@cidade)";
        }
    }
}
