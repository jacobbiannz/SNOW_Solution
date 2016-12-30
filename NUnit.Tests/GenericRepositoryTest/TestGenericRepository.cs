using NUnit.Framework;
using SNOW_Solution.Controllers;
using SNOW_Solution.Models;
using SNOW_Solution.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NUnit.Tests.GenericRepositoryTest
{
    public class TestGenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Insert(BaseEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Insert(T obj)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> SelectAll()
        {
            return null;
    }

        public T SelectByID(object id)
        {
            throw new NotImplementedException();
        }

        public void Update(BaseEntity obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<BaseEntity> IGenericRepository<T>.SelectAll()
        {
            throw new NotImplementedException();
        }

        BaseEntity IGenericRepository<T>.SelectByID(object id)
        {
            throw new NotImplementedException();
        }
    }
}
