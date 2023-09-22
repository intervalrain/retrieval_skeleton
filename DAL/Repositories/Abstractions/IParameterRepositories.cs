using System;
using System.Collections.Generic;

namespace DAL.Repositories.Abstractions
{
    public interface IParameterRepositories
    {
        IList<ParameterModel> GetParameter();
    }
}