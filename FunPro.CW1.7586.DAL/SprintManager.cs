using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace FunPro.CW1._7586.DAL
{
    public class SprintManager : DBManager
    {
        public void Create(Sprint s)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
INSERT INTO sprint (name, date, no_of_developers, status) 
VALUES('{s.Name}', '{s.Date:yyyy-MM-dd}', {s.NumberOfDevelopers}, '{s.Status}')";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }

        }



        public void Update(Sprint s)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
                    UPDATE sprint SET 
                    name = '{s.Name}',
                    date = '{s.Date:yyyy-MM-dd}',
                    no_of_developers = {s.NumberOfDevelopers},
                    status = '{s.Status}'
                    WHERE id = {s.ID}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }



        public Sprint GetById(int id)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
                    SELECT id, name, date, no_of_developers, status 
                    FROM sprint 
                    WHERE id = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var s = new Sprint
                    {
                        ID = Convert.ToInt32(reader.GetValue(0)),
                        Name = Convert.ToString(reader.GetValue(1))
                    };
                    return s;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }
            return null;
        }



        public List<Sprint> GetAll()
        {
            var connection = Connection;
            var result = new List<Sprint>();
            try
            {
                var sql = "SELECT id, name, date, no_of_developers, status FROM sprint";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var s = GetFromReader(reader);
                    result.Add(s);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }

            return result;
        }



        private Sprint GetFromReader(SqlCeDataReader reader)
        {
            var s = new Sprint
            {
                ID = Convert.ToInt32(reader.GetValue(0)),
                Name = reader.GetValue(1).ToString(),
                Date = Convert.ToDateTime(reader.GetValue(2)),
                NumberOfDevelopers = Convert.ToInt32(reader.GetValue(3)),
                Status = reader.GetValue(4).ToString()
            };

            return s;
        }
    }
}
