using System;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace LiftModel
{
    public class Statistics
    {
        Lift Lifft;

        public Statistics(Lift lifft)
        {
            Lifft = lifft;
        }

        public string People()
        {
            return Lifft.peopleNum.ToString();
        }

        public string AllTrips()
        {
            return Lifft.TripsCounter.ToString();
        }

        public string AllEmptyTrips()
        {
            return Lifft.EmptyTripsCounter.ToString();
        }

        public string TimeMoving()
        {
            return Lifft.CurrentMin.ToString() + " м " + Lifft.CurrentSec.ToString() + " с ";
        }

        public void ToExcel()
        {
            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook eWB;
            Excel.Worksheet eWSh;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                eWB = ExcelApp.Workbooks.Add();
                ExcelApp.Visible = true;
                eWSh = (Excel.Worksheet)eWB.Worksheets.get_Item(1);

                eWSh.Cells[1, 1] = "Общее количество поездок";
                eWSh.Cells[2, 1] = "Количество холостых поездок";
                eWSh.Cells[3, 1] = "Время работы лифта";
                eWSh.Cells[4, 1] = "Количество перевезенных людей";

                eWSh.Cells[1, 2] = AllTrips();
                eWSh.Cells[2, 2] = AllEmptyTrips();
                eWSh.Cells[3, 2] = TimeMoving();
                eWSh.Cells[4, 2] = People();
            }
            catch (Exception ex)
            {
                ExcelApp.Quit();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        public void ToWord()
        {
            Word._Application application = new Word.Application();
            Word._Document document;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                application.Visible = true;
                document = application.Documents.Add();

                Word.Range wordRange = document.Sections[1].Range;
                wordRange.Font.Size = 14;

                wordRange.Text = "Общее количество поездок - " + AllTrips() + "\n"
                                + "Количество холостых поездок - " + AllEmptyTrips() + "\n"
                                + "Время работы лифта - " + TimeMoving() + "\n"
                                + "Количество перевезенных людей - " + People() + "\n";
            }
            catch (Exception ex)
            {
                application.Quit();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
    }
}
