using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Amir.Apparel.Demo.Api.Dotnet.Tests.Utilities
{
    public static class MockSetupExtensions
    {
        public static Mock<DbSet<T>> LoadMockDbSetWithData<T>(this Mock<DbSet<T>> mock, IEnumerable<T> data)
            where T : class
        {
            IQueryable<T> queryable = data.AsQueryable();

            mock.SetupMocks(queryable);
            return mock;
        }

        public static Mock<DbSet<T>> LoadMockDbSetWithData<T>(this Mock<DbSet<T>> mock, IQueryable<T> queryable)
            where T : class
        {
            mock.SetupMocks(queryable);
            return mock;
        }

        private static Mock<DbSet<T>> SetupMocks<T>(this Mock<DbSet<T>> mock, IQueryable<T> queryable)
            where T : class
        {
            mock.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryable.Provider);
            mock.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryable.Expression);
            mock.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            mock.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());

            return mock;
        }
    }
}
