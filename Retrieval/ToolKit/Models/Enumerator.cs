using System;
using System.Data.Common;
using System.Collections;
using Retrieval.ToolKit.Abstractions;
namespace Retrieval.ToolKit.Models
{
	internal class Enumerator<T> : ProjectionRow, IEnumerator<T>, IEnumerator, IDisposable
	{
		DbDataReader reader;
		T current;
		Func<ProjectionRow, T> projector;
		internal Enumerator(DbDataReader reader, Func<ProjectionRow, T> projector)
		{
			this.reader = reader;
			this.projector = projector;
		}

        public override object GetValue(int index)
        {
			if (index >= 0)
			{
				if (reader.IsDBNull(index))
				{
					return null;
				}
				else
				{
					return reader.GetValue(index);
				}
			}
			throw new IndexOutOfRangeException();
        }

		public T Current
		{
			get { return current; }
		}

		object IEnumerator.Current
		{
			get { return current; }
		}

        public bool MoveNext()
		{
			if (reader.Read())
			{
				current = projector(this);
				return true;
			}
			return false;
		}

        public void Reset()
        {
        }

        public void Dispose()
        {
			reader.Dispose();
        }
    }
}

