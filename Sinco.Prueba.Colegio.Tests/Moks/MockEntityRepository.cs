using AutoFixture.Dsl;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Sinco.Prueba.Colegio.Domain.Common;
using Sinco.Prueba.Colegio.Infrastructure.Persistence;

namespace Sinco.Prueba.Colegio.Tests.Moks
{
    public static class MockEntityRepository
    {
        public static void SaveIntoDb<T, TContext>(
            this IPostprocessComposer<T> composer,
            TContext context,
            int count = 10
            )
            where T : Entity
            where TContext : DbContext
        {
            AddRangeToContext(context, composer.CreateMany(count).ToList());
        }

        public static void SaveIntoDb<T, TContext>(
            this IEnumerable<T> fixtures,
            TContext context
            )
            where T : Entity
            where TContext : DbContext
        {
            AddRangeToContext(context, fixtures.ToList());
        }

        public static void SaveIntoDb<T, TContext>(
            this T fixture,
            ColegioDbContext context
            )
            where T : Entity
            where TContext : DbContext
        {
            AddToContext(context, fixture);
        }


        public static ICustomizationComposer<T> CreateFixture<T>() where T : Entity
        {
            Fixture fixture = new();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            return fixture.Build<T>();
        }

        public static void CreateFixture<T, TContext>(TContext context, int count = 10)
            where T : Entity
            where TContext : DbContext
        {
            Fixture fixture = new();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var entities = fixture.Build<T>();
            AddRangeToContext(context, entities.CreateMany(count).ToList());
        }

        private static void AddToContext<TContext, TEntity>(TContext context, TEntity entity)
            where TContext : DbContext
            where TEntity : Entity
        {
            var entities = context.Set<TEntity>().ToList();
            if (!entities.Any(e => e.Id == entity.Id))
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        private static void AddRangeToContext<TContext, TEntity>(TContext context, List<TEntity> entities)
            where TContext : DbContext
            where TEntity : Entity
        {
            var existingEntities = context.Set<TEntity>().ToList();
            if (!entities.Any(en => existingEntities.Any(e => e.Id == en.Id)))
            {
                context.Set<TEntity>().AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
