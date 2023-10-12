using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Retrieval.ToolKit.Abstractions;

namespace Retrieval.ToolKit.Models.Readers
{
	internal class ProjectionReader<T> : IEnumerable<T>, IEnumerable 
	{
		Enumerator<T> enumerator;
		internal ProjectionReader(DbDataReader reader, Func<ProjectionRow, T> projector)
		{
            enumerator = new Enumerator<T>(reader, projector);
		}

        public IEnumerator<T> GetEnumerator()
        {
            Enumerator<T> e = enumerator;
            if (e == null)
                throw new InvalidOperationException("Cannot enumerate more than once");
            enumerator = null;
            return e;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

