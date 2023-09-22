using System;
using System.Collections;
using System.Data.Common;
using System.Reflection;

namespace Retrieval.ToolKit
{
	internal class ObjectReader<T> : IEnumerable<T>, IEnumerable where T : class, new()
	{
		Enumerator? enumerator;
		public ObjectReader(DbDataReader reader)
		{
			enumerator = new Enumerator(reader);
		}

		public IEnumerator<T> GetEnumerator()
		{
			Enumerator? e = enumerator;
			if (e == null)
				throw new InvalidOperationException("Cannot enumerate more than once");
			enumerator = null;
			return e;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		class Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			DbDataReader reader;
			FieldInfo[] fields;
			int[] fieldLookup;
			T current;

			internal Enumerator(DbDataReader reader)
			{
				this.reader = reader;
				this.fields = typeof(T).GetFields();
			}

			public T Current => current;

			object IEnumerator.Current => current;

			public bool MoveNext()
			{
				if (reader.Read())
				{
					if (fieldLookup == null)
					{
						InitFieldLookup();
					}
					T instance = new T();
					for (int i = 0, n = fields.Length; i < n; i++)
					{
						int index = fieldLookup[i];
						if (index >= 0)
						{
							FieldInfo fi = fields[i];
							if (reader.IsDBNull(index))
							{
								fi.SetValue(instance, null);
							}
							else
							{
								fi.SetValue(instance, reader.GetValue(index));
							}
						}
					}
					current = instance;
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

			private void InitFieldLookup()
			{
				var map = new Dictionary<string, int>(StringComparer.InvariantCultureIgnoreCase);
				for (int i = 0, n = reader.FieldCount; i < n; i++)
				{
					map.Add(reader.GetName(i), i);
				}
				fieldLookup = new int[fields.Length];
				for (int i = 0, n = fields.Length; i < n; i++)
				{
					if (map.TryGetValue(fields[i].Name, out int index))
					{
						fieldLookup[i] = index;
					}
					else
					{
						fieldLookup[i] = -1;
					}
				}
			}
		}
	}
}

