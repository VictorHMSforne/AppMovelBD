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
        //parametros algo mais direto, usado somente para poucos dados, mais recomendável procedure para grandes valores.
        public static void InserirPessoa(string nome,string idade,string cidade)
        {
            string sql = "INSERT INTO pessoa(nome,idade,cidade) VALUES (@nome,@idade,@cidade)";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = idade;
                    cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cidade;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        //procedure resume e evita criação de muitos parametros por meio do Model
        public static void AtualizarPessoa(Pessoa pessoa)
        {
            string sql = "UPDATE pessoa SET nome=@nome,idade=@idade,cidade=@cidade WHERE id=@id";
            try
            {
                using (MySqlConnection con = new MySqlConnection(conn))
                {
                    con.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, con))
                    {
                        cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = pessoa.nome;
                        cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = pessoa.idade;
                        cmd.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = pessoa.cidade;
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        
        public static void ExcluirPessoa(Pessoa pessoa)
        {
            string sql = "DELETE FROM pessoa WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }


    }
}
