using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TallerMolinaproyecto
{
    public interface ISearchSource
    {
        string Title { get; }
        IEnumerable<string> GetCategories();
        DataTable Search(string category, string term);
        void OnRowDoubleClick(DataGridViewRow row);
    }
}
