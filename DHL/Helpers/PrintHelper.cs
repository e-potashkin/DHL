using Spire.Pdf;
using System;

namespace DHL.Helpers
{
    internal class PrintHelper
    {
        public PrintHelper(string labelName)
        {
            PrintLabel(labelName);
        }

        /// <summary>
        /// Prints the labels. Simple as that.
        /// Uses Spire.pdf to realise the printing.
        /// </summary>
        /// <param name="labelName">File name of the label that should be printed.</param>
        private static void PrintLabel(string labelName)
        {
            try
            {
                // Print the file
                string filepath = labelName;

                var pdfdocument = new PdfDocument();
                pdfdocument.LoadFromFile(filepath);
                pdfdocument.PrinterName = "";//sett.PrinterName;
                pdfdocument.PrintDocument.PrinterSettings.Copies = 1;
                pdfdocument.PrintDocument.Print();
                pdfdocument.Dispose();

                //logTextToFile("> " + labelName + " was successfully printed!");
                //log.writeLog("> " + labelName + " wurde erfolgreich gedruckt!", true);

            }
            catch (Exception ex)
            {
                //log.writeLog(ex.ToString().ToString(), true);
            }
        }
    }
}
