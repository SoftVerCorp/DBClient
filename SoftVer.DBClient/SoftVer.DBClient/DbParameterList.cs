using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftVer.DBClient
{
    class DbParameterList : IList<DbParameter>, ICollection<DbParameter>
    {

        private List<DbParameter> dbParameters;

        public DbParameter this[int index]
        {
            get
            {
                return this.dbParameters[index];
            }

            set
            {
                this.dbParameters[index] = value;
            }
        }

        public DbParameter this[string name]
        {
            get
            {
                if (!name.StartsWith("@"))
                {
                    name = "@" + name;
                }

                DbParameter dbParameter = this.dbParameters.Find((DbParameter match) => match.ParameterName.ToUpper() == name.ToUpper());

                return DbParameter;
            }
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(DbParameter item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(DbParameter item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(DbParameter[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DbParameter> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(DbParameter item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, DbParameter item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(DbParameter item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
