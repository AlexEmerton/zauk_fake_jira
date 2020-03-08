using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace FunPro.CW1._7586.DAL
{
    public class TicketManager : DBManager
    {
        public void Create(Ticket t)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
                    INSERT INTO ticket (summary, description, estimation, priority, status, sprint_id) 
                    VALUES('{t.Summary}', '{t.Description}', {t.Estimation}, '{t.Priority}', '{t.Status}', {t.Sprint.Id})";
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

        public void Update(Ticket t)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
                    UPDATE ticket SET 
                    summary = '{t.Summary}', 
                    description = '{t.Description}', 
                    estimation = {t.Estimation}, 
                    priority = '{t.Priority}', 
                    status = '{t.Status}', 
                    sprint_id = {t.Sprint.Id}
                    WHERE id = {t.Id}";
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



        public void Delete(int id)
        {
            var connection = Connection;
            try
            {
                var sql = $"DELETE FROM ticket WHERE id = {id}";
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



        public Ticket GetById(int id)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
                    SELECT id, summary, description, estimation, priority, status, sprint_id 
                    FROM ticket
                    WHERE id = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var t = GetFromReader(reader);
                    return t;
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

            // if we are here - something went wrong
            return null;
        }



        public List<Ticket> GetAll()
        {
            var connection = Connection;
            var result = new List<Ticket>();
            try
            {
                var sql = "SELECT id, summary, description, estimation, priority, status, sprint_id FROM ticket";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var t = GetFromReader(reader);
                    result.Add(t);
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



        private Ticket GetFromReader(SqlCeDataReader reader)
        {
            var t = new Ticket
            {
                Id = Convert.ToInt32(reader.GetValue(0)),
                Summary = reader.GetValue(1).ToString(),
                Description = reader.GetValue(2).ToString(),
                Estimation = Convert.ToInt32(reader.GetValue(3)),
                Priority = reader.GetValue(4).ToString(),
                Status = reader.GetValue(5).ToString(),
                Sprint = new SprintManager().GetById(Convert.ToInt32(reader.GetValue(6)))
            };

            return t;
        }

        public List<Ticket> GetBacklog()
        {
            var connection = Connection;
            var result = new List<Ticket>();
            try
            {
                var sql = "SELECT id, summary, description, estimation, priority, status, sprint_id FROM ticket";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(5).ToString() == "Backlog")
                    {
                        var t = GetFromReader(reader);
                        result.Add(t);
                    }
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
    }
}
