using System;
namespace Retrieval.Infrastructure.DAL.Form.Entities.Abstractions
{
    public interface IEntity
    {
        string Key { get; }
        string Id { get; }
    }
}

