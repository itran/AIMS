using System;
using System.Windows.Controls;

namespace Horizon.Client.Modules.Engine.Utility
{
    public static class GridExtensions
    {
        public static void SetCopyModeToCurrentCell(this DataGrid dataGrid)
        {
            dataGrid.CopyingRowClipboardContent += DataGrid_CopyingRowClipboardContent;
        }

        private static void DataGrid_CopyingRowClipboardContent(object sender, DataGridRowClipboardEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                var currentCell = e.ClipboardRowContent[dataGrid.CurrentCell.Column.DisplayIndex];
                e.ClipboardRowContent.Clear();
                e.ClipboardRowContent.Add(currentCell);
            }
        }
    }
}