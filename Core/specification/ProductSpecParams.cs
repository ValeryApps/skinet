namespace Core.specification
{
   public class ProductSpecParams
   {
      private const int MaxPageSite = 50;
      public int PageIndex { get; set; } = 1;
      private int _pageSize = 6;
      public int PageSize
      {
         get
         {
            return _pageSize;
         }
         set
         {
            _pageSize = (value > MaxPageSite) ? MaxPageSite : value;
         }
      }
      public int? BrandId { get; set; }
      public int? TypeId { get; set; }
      public string sort { get; set; }

      private string _search;
      public string Search
      {
         get { return _search; }
         set { _search = value; }
      }


   }

}