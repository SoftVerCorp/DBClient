using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftVer.DBClient
{
    public class DataFactory
    {
        private DatabaseType _dbtype;

        private string _connectionString;

        IDbConnection _cnn;

        private Dictionary<string, IDbCommand> commands;


        public IEnumerable<IDbCommand> Commands
        {
            get
            {
                return commands.Values;
            }
        }

        public DataFactory(string ConnectionString, DatabaseType dbtype)
        {
            this._dbtype = dbtype;
            _connectionString = ConfigurationManager.ConnectionStrings[ConnectionString].ToString();
            commands = new Dictionary<string, IDbCommand>();
            CreateConnection();
        }

        private void CreateConnection()
        {
            switch (this._dbtype)
            {
                case DatabaseType.SQLServer:
                    _cnn = new SqlConnection(this._connectionString);
                    break;
                default:
                    _cnn = new SqlConnection(this._connectionString);
                    break;
            }
            //return _cnn;
        }

        public IDbCommand CreateCommand(string CommandText)
        {
            IDbCommand cmd;

            switch (this._dbtype)
            {
                case DatabaseType.SQLServer:
                    cmd = new SqlCommand
                       (CommandText,
                       (SqlConnection)_cnn);
                    break;
                default:
                    cmd = new SqlCommand
                       (CommandText,
                       (SqlConnection)_cnn);
                    break;
            }

            return cmd;
        }

        public IDbCommand AddCommand(string name, int timeout)
        {
            IDbCommand dbCommand;

            switch (this._dbtype)
            {
                case DatabaseType.SQLServer:
                    if (this.commands.ContainsKey(name))
                    {
                        dbCommand = this.GetCommand(name);
                    }
                    else
                    {
                        dbCommand = new SqlCommand(name, new SqlConnection(this._connectionString))
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandTimeout = timeout
                        };

                        this.commands.Add(name, dbCommand);
                    }
                    break;
                default:
                    if (this.commands.ContainsKey(name))
                    {
                        dbCommand = this.GetCommand(name);
                    }
                    else
                    {
                        dbCommand = new SqlCommand(name, new SqlConnection(this._connectionString))
                        {
                            CommandType = CommandType.StoredProcedure,
                            CommandTimeout = timeout
                        };

                        this.commands.Add(name, dbCommand);
                    }
                    break;
            }

            return dbCommand;
        }

        public IDbCommand AddCommand(string name)
        {
            return this.AddCommand(name, 2000);
        }

        public bool RemoveCommand(string name)
        {
            return this.commands.Remove(name);
        }

        public IDbCommand GetCommand(string name)
        {
            IDbCommand dbcommand;

            if(this.commands.TryGetValue(name, out dbcommand))
            {
                dbcommand.Connection.ConnectionString = this._connectionString;
                return dbcommand;
            }
            throw new Exception(string.Format("{0} {1}",name, "Comando no encontrado"));
        }

        
    }
}