using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace API.Tests.Extensions
{
    public static class DbSetExtensions
    {
        public static Mock<DbSet<T>> CreateMockDbSet<T>(this IEnumerable<T> elements) where T : class 
        {
            var asQueryableElements = elements.AsQueryable();
            var mockDbSet = new Mock<DbSet<T>>();

            mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(asQueryableElements.Provider);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(asQueryableElements.Expression);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(asQueryableElements.ElementType);
            mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(asQueryableElements.GetEnumerator());
            mockDbSet.Setup(x => x.AsQueryable()).Returns(asQueryableElements);

            return mockDbSet;
        } 
    }
}
