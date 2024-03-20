namespace Plants.ViewModels
{
	public class PagingViewModel
	{
		public int ItemsPerPage { get; set; }

		public int PageNumber { get; set; }

		public int NextPageNumber => PageNumber + 1;

		public bool HasNextPageNumber => PageNumber < PagesCount;

		public int PreviousPageNumber => PageNumber -1;

		public bool HasPreviousPageNumber => PageNumber > 1;

		public int ItemsCount { get; set; }

		public int PagesCount => (int)Math.Ceiling((decimal)ItemsCount /ItemsPerPage);
	}
}
