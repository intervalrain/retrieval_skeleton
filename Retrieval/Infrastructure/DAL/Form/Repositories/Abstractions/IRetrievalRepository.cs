using System;
using Retrieval.Infrastructure.Abstractions;
using Retrieval.Infrastructure.DAL.Form.Entities.Abstractions;
using Retrieval.Infrastructure.DAL.Form.Models.Abstractions;
using Retrieval.Infrastructure.Enumerates;

namespace Retrieval.Infrastructure.DAL.Form.Repositories.Abstractions
{
    public interface IRetrievalRepository//<TEntity> where TEntity : IEntity
    {
        object GetResult(List<DataModel> models);
    }
}