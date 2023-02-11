using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MatuteNotes.DataAcces.AdoNet
{
    public class AdoContext
    {

        private SqlConnection sql;
        public AdoContext(string url)
        {
            sql = new SqlConnection(url);
        }
        public void Dispose()
        {
            sql.Dispose();
        }
        public async Task<IEnumerable<T>> Query<T>(int top = 9999) where T : class, new()
        {
            try
            {
                await sql.OpenAsync();
                string entityName = typeof(T).Name;
                string querySql = $"SELECT * FROM {entityName}";
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = CommandType.Text;

                    List<T> objectList = new List<T>();
                    using (var reader = await cm.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            T obj = new T();
                            foreach (var prop in obj.GetType().GetProperties())
                            {
                                try
                                {
                                    PropertyInfo info = obj.GetType().GetProperty(prop.Name);
                                    info.SetValue(obj, Convert.ChangeType(reader[prop.Name], info.PropertyType), null);
                                }
                                catch
                                { continue; }
                            }
                            objectList.Add(obj);
                        }
                    }
                    return objectList;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<IEnumerable<T>> Query<T>(string id) where T : class, new()
        {
            try
            {
                await sql.OpenAsync();
                string entityName = typeof(T).Name;
                string columnID = "Id";// $"{typeof(T).Name}ID";
                string querySql = $"SELECT * FROM {entityName} WHERE {columnID}='{id}'";
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = CommandType.Text;

                    List<T> objectList = new List<T>();
                    using (var reader = await cm.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            T obj = new T();
                            foreach (var prop in obj.GetType().GetProperties())
                            {
                                try
                                {
                                    PropertyInfo info = obj.GetType().GetProperty(prop.Name);
                                    info.SetValue(obj, Convert.ChangeType(reader[prop.Name], info.PropertyType), null);
                                }
                                catch
                                { continue; }
                            }
                            objectList.Add(obj);
                        }
                    }
                    return objectList;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public async Task<DataSet> ExecuteDataSet(string command)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlDataAdapter da = new SqlDataAdapter(command, sql))
                {
                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<DataSet> ExecuteDataSet(string command, params SqlParameter[] SqlParameters)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlDataAdapter da = new SqlDataAdapter(command, sql))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddRange(SqlParameters);

                    var ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<DataTable> ExecuteDataTable(string command)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlDataAdapter da = new SqlDataAdapter(command, sql))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<DataTable> ExecuteDataTable(string command, params SqlParameter[] SqlParameters)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlDataAdapter da = new SqlDataAdapter(command, sql))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddRange(SqlParameters);

                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<IEnumerable<T>> ExecuteToList<T>(string command) where T : class, new()
        {
            try
            {
                await sql.OpenAsync();
                using (SqlDataAdapter da = new SqlDataAdapter(command, sql))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return ToList<T>(dt);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<IEnumerable<T>> ExecuteToList<T>(string procedure, params SqlParameter[] SqlParameters) where T : class, new()
        {
            try
            {
                await sql.OpenAsync();
                using (SqlDataAdapter da = new SqlDataAdapter(procedure, sql))
                {
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.AddRange(SqlParameters);

                    var dt = new DataTable();
                    da.Fill(dt);
                    return ToList<T>(dt);
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        List<T> ToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                var list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(property.Name);
                            propertyInfo.SetValue(obj,
                                    Convert.ChangeType(row[property.Name],
                                    propertyInfo.PropertyType,
                                    null));
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<Int32> ExecuteNonQuery(string querySql, CommandType commandType, params SqlParameter[] SqlParameters)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = commandType;
                    cm.Parameters.AddRange(SqlParameters);

                    return await cm.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<Int32> ExecuteNonQuery(string querySql, CommandType commandType)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = commandType;
                    return await cm.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<Object> ExecuteEscalar(string querySql, CommandType commandType, params SqlParameter[] SqlParameters)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = commandType;
                    cm.Parameters.AddRange(SqlParameters);
                    return await cm.ExecuteScalarAsync();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<Object> ExecuteEscalar(string querySql, CommandType commandType)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = commandType;
                    return await cm.ExecuteScalarAsync();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<IEnumerable<T>> ExecuteReader<T>(string querySql, CommandType commandType) where T : class, new()
        {
            try
            {
                await sql.OpenAsync();
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = commandType;

                    List<T> objectList = new List<T>();
                    using (var reader = await cm.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            T obj = new T();
                            foreach (var prop in obj.GetType().GetProperties())
                            {
                                try
                                {
                                    PropertyInfo info = obj.GetType().GetProperty(prop.Name);
                                    info.SetValue(obj, Convert.ChangeType(reader[prop.Name], info.PropertyType), null);
                                }
                                catch
                                { continue; }
                            }
                            objectList.Add(obj);
                        }
                    }
                    return objectList;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
        public async Task<IEnumerable<T>> ExecuteReader<T>(string querySql,
            CommandType commandType,
            params SqlParameter[] SqlParameters) where T : class, new()
        {
            try
            {
                await sql.OpenAsync();
                using (SqlCommand cm = new SqlCommand(querySql, sql))
                {
                    cm.CommandType = commandType;
                    cm.Parameters.AddRange(SqlParameters);
                    var reader = await cm.ExecuteReaderAsync(CommandBehavior.CloseConnection);

                    List<T> objectList = new List<T>();
                    while (reader.Read())
                    {
                        T obj = new T();
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            try
                            {
                                PropertyInfo info = obj.GetType().GetProperty(prop.Name);
                                info.SetValue(obj, Convert.ChangeType(reader[prop.Name], info.PropertyType), null);
                            }
                            catch
                            { continue; }
                        }
                        objectList.Add(obj);
                    }

                    return objectList;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }


        public async Task<Int32> ExecuteNonQueryTransac(string querySql, CommandType commandType, params SqlParameter[] SqlParameters)
        {
            try
            {
                await sql.OpenAsync();
                using (SqlTransaction transaction = sql.BeginTransaction())
                {
                    using (SqlCommand cm = new SqlCommand(querySql, sql, transaction))
                    {
                        cm.CommandType = commandType;
                        cm.Parameters.AddRange(SqlParameters);
                        try
                        {
                            var response = await cm.ExecuteNonQueryAsync();
                            transaction.Commit();
                            return response;
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            sql.Close();
                            throw e;
                        }
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }


}

