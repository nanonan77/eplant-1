using iText.Layout.Borders;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sketec.FileWriter.Extensions
{
    public static class TableExtension
    {
        public static Cell AddCellNoBorder(this Table table, int rowSpan = 1, int colSpan = 1, int space = 0, bool border = false, int spaceRuler = 2)
        {
            var cell = new Cell(rowSpan, colSpan)
                .SetMargin(0)
                .SetPadding(0);

            if (space > 0)
                cell.SetPaddingLeft(space).SetPaddingRight(space);


            //if (spaceRuler > 0)
            //    cell.SetPaddingTop(spaceRuler).SetPaddingBottom(spaceRuler);

            if (!border)
                cell.SetBorder(Border.NO_BORDER);

            table.AddCell(cell);

            return cell;
        }

        public static Cell AddCellTable(this Table table, bool isLast = false, int rowSpan = 1, int colSpan = 1, int space = 4)
        {
            var cell = new Cell(rowSpan, colSpan)
                .SetMargin(0)
                .SetPadding(0)
                .SetBorderTop(Border.NO_BORDER)
                .SetPadding(space);


            if (!isLast)
                cell.SetBorderBottom(Border.NO_BORDER);

            table.AddCell(cell);

            return cell;
        }

        public static Cell AddCell(this Table table, int rowSpan = 1, int colSpan = 1)
        {
            var cell = new Cell(rowSpan, colSpan)
                .SetMargin(0)
                .SetPaddingLeft(2)
                .SetPaddingRight(2);

            table.AddCell(cell);

            return cell;
        }
    }
}
