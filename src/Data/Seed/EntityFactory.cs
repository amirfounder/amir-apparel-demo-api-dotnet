using Amir.Apparel.Demo.Api.Dotnet.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amir.Apparel.Demo.Api.Dotnet.Data.Seed
{
    public abstract class EntityFactory<T> where T : IEntity
    {
        protected readonly Random _rand;
        protected readonly IEnumerable<char> _alphabet;

        protected EntityFactory()
        {
            _rand = new();
            _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }
        public IEnumerable<T> BuildEntities(int count) => Enumerable.Range(1, count).Select(i => BuildEntity(i));
        public abstract T BuildEntity(int id);
    }
}
