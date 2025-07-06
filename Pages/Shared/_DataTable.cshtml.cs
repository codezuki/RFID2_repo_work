using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RFID2.Pages.Shared
{
    public class _DataTableModel : PageModel
    {
        
            public string TableId { get; set; } = "dataTable";
            public List<string> Columns { get; set; } = new();
            public List<Dictionary<string, object>> Rows { get; set; } = new();  // dynamic-like structure
        
        public void OnGet()
        {
        }
    }
}
