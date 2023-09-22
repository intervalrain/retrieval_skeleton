using System;
using Retrieval.Infrastructure.DAL.Form.Models.Abstractions;
using Retrieval.Infrastructure.DAL.Form.Repositories.Abstractions;

namespace Retrieval.Infrastructure.DAL.Form.Usecases
{
	public class DataCombinationFill
	{
		private readonly IRetrievalRepository _repository; 

		public DataCombinationFill(IRetrievalRepository repository)
		{
			_repository = repository;
		}

		public void Execute(Input input, ListBoxControl listbox)
		{
			var DataCombination = _repository.GetResult(input.models);
            listbox.Presenter = DataCombination;
        }

		public record Input(List<DataModel> models);

		public class ListBoxControl
        {
			public ListBoxControl()
			{
			}
			public object Presenter { get; set; }
			
		}
	}
}

