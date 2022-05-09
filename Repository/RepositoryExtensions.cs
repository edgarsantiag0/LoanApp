using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public static class RepositoryExtensions
    {
        public static IQueryable<T1> Filter<T1, T2>(this IQueryable<T1> entities, T2 parameter, Func<IQueryable<T1>, T2, IQueryable<T1>> evaluacion)
        {
            return evaluacion(entities, parameter);
        }

        public static IQueryable<T1> Search<T1, T2>(this IQueryable<T1> entities, T2 parameter, Func<IQueryable<T1>, T2, IQueryable<T1>> evaluacion)
        {
            return evaluacion(entities, parameter);
        }

        public static IQueryable<T1> Sort<T1, T2>(this IQueryable<T1> entities, T2 parameter, Func<IQueryable<T1>, T2, IQueryable<T1>> evaluacion)
        {
            return evaluacion(entities, parameter);
        }

        public static async Task<PagedList<T>> ToPagedList<T>(this IQueryable<T> lista, RequestParameters parameters)
        {
            int total = await lista.CountAsync();

            if (parameters.PageSize > 0)
            {
                int pageSize = parameters.PageSize;
                int cantidadSkip = (parameters.PageNumber - 1) * pageSize;

                if (cantidadSkip >= total)
                {
                    pageSize = 0;
                    cantidadSkip = 0;
                    // return null;
                }

                if (pageSize > total)
                {
                    pageSize = total;
                }

                lista = cantidadSkip > 0 ?
                    lista.Skip(cantidadSkip).Take(pageSize) :
                    lista.Take(pageSize);
            }

            var result = await lista.ToListAsync();

            return new PagedList<T>(result, total, parameters.PageNumber, parameters.PageSize);
        }
    }
}
