using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.UnitTests.Repository
{
    public static class BaseRepositoryUnitTestsUtilities
    {
        public static Mock<DbSet<T>> LoadMockDbSetWithData<T>(this Mock<DbSet<T>> mock, IEnumerable<T> data)
            where T : class
        {
            IQueryable<T> queryable = data.AsQueryable();

            mock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryable.Provider);
            mock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryable.Expression);
            mock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            mock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mock;
        }
    }
}
