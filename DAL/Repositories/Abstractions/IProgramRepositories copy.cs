using System;

namespace DAL.Repositories.Abstractions
{
    public interface ProgramRepositories
    {
        IList<string> GetProgram();
    }
}