using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using ControlzEx;
using DocumentFormat.OpenXml.Drawing;

namespace DA.SS
{
    public static class ExportToExcel
    {
        public static string ExportFutsal(BE.Categoria categoria, int numeroFecha, List<PartidoHelperUI> partidos, string directorio, string excelName)
        {
            //string directorio = @"C:\Designaciones\";
            //string directorio = ConfigurationManager.AppSettings["PathDesignaciones"];
            
            if (!Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);


            XLWorkbook workbook = new XLWorkbook();

            var worksheet = GenerateNewWorksheet(workbook, categoria, numeroFecha);

            int cont = 1;
            int actualRowNumber = 12;

            foreach (PartidoHelperUI partido in partidos)
            {
                if (partido.Equipo1.Categoria.Id == categoria.Id)
                {
                    AddMatchesToWorksheet(worksheet, actualRowNumber, cont, partido);

                    cont++;
                    actualRowNumber++;

                }
                else
                {
                    FormatBottomBorderStyleMedium(worksheet, "A" + (actualRowNumber - 1) + ":" + "E" + (actualRowNumber - 1));

                    AddFooterToWorksheet(worksheet, actualRowNumber);

                    categoria = partido.Equipo1.Categoria;

                    worksheet.Range("A24:A500").Delete(XLShiftDeletedCells.ShiftCellsUp);

                    worksheet = GenerateNewWorksheet(workbook, categoria, partido.FechaDelCampeonato.Numero);

                    cont = 1;
                    actualRowNumber = 12;
                }
            }

            FormatBottomBorderStyleMedium(worksheet, "A" + (actualRowNumber - 1) + ":" + "E" + (actualRowNumber - 1));

            AddFooterToWorksheet(worksheet, actualRowNumber);

            worksheet.Column(1).AdjustToContents(11, 12);
            worksheet.Columns(2, 7).AdjustToContents();

           // string excelName = "Planilla de designaciones Futsal Fecha " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".xlsx";
        
      
            var fileName = directorio + @"\"+ excelName.ToLowerInvariant().Replace(".pdf","") + ".xlsx";

   
            workbook.SaveAs(fileName);

            return fileName;

        }

        private static void AddMatchesToWorksheet(IXLWorksheet worksheet, int actualRowNumber, int cont, PartidoHelperUI partido)//, List<BE.PartidoArbitro> partidoArbitros)
        {
            var actualLetter = 'A';
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = cont;
            FormatNumberCell(worksheet, actualLetter.ToString() + actualRowNumber);
            actualLetter = GetNextLetter(actualLetter);
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = partido.Equipo1.Nombre;
            FormatTeamCell(worksheet, actualLetter.ToString() + actualRowNumber);
            actualLetter = GetNextLetter(actualLetter);
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = partido.Equipo2.Nombre;
            FormatTeamCell(worksheet, actualLetter.ToString() + actualRowNumber);
            actualLetter = GetNextLetter(actualLetter);
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = partido.ArbitrosYTipos.FirstOrDefault(x => ((BE.TipoArbitro)x.Value).Descripcion == "Principal" ).Key.ObtenerNombreCompleto();
            //worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = partidoArbitros.FirstOrDefault(x => (x.TipoArbitro.Id == 1))?.Arbitro.ObtenerNombreCompleto();
            FormatRefereeCell(worksheet, actualLetter.ToString() + actualRowNumber);
            actualLetter = GetNextLetter(actualLetter); 
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = partido.ArbitrosYTipos.FirstOrDefault(x => ((BE.TipoArbitro)x.Value).Descripcion == "Asistente" ).Key.ObtenerNombreCompleto();
            //worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = partidoArbitros.FirstOrDefault(x => (x.TipoArbitro.Id == 2))?.Arbitro.ObtenerNombreCompleto();
            FormatRefereeCell(worksheet, actualLetter.ToString() + actualRowNumber);
        }

        private static void AddFooterToWorksheet(IXLWorksheet worksheet, int actualRowNumber)
        {
            var actualLetter = 'B';
            actualLetter = GetNextLetter(actualLetter);
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = "Instructores";

            var rngInst = worksheet.Range(actualLetter.ToString() + actualRowNumber);
            rngInst.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rngInst.Style.Font.Bold = true;
            rngInst.Style.Font.Underline = XLFontUnderlineValues.Single;
            rngInst.Style.Font.FontSize = 28;
            rngInst.Style.Font.FontName = "Calibri";

            actualLetter = GetNextLetter(actualLetter);
            worksheet.Cell(actualLetter.ToString() + actualRowNumber).Value = "Sciancalepore, Juan C.";
            worksheet.Cell(actualLetter.ToString() + (actualRowNumber + 1)).Value = "Zechillo, Pablo";

            var rngNames =
                worksheet.Range(actualLetter.ToString() + actualRowNumber + ":" + actualLetter.ToString() + (actualRowNumber + 1));
            rngNames.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rngNames.Style.Font.Bold = true;
            rngNames.Style.Font.FontSize = 26;
            rngNames.Style.Font.FontName = "Calibri";


            worksheet.Column(1).AdjustToContents(11, 12);
            worksheet.Columns(2, 7).AdjustToContents();
        }

        public static void FormatBottomBorderStyleMedium(IXLWorksheet worksheet, string range)
        {
            var rng = worksheet.Range(range);
            rng.Style.Border.BottomBorder = XLBorderStyleValues.Medium;

        }

        public static void FormatNumberCell(IXLWorksheet worksheet, string range)
        {
            var rng = worksheet.Range(range);
            rng.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rng.Style.Font.Bold = true;
            rng.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 192, 0);
            rng.Style.Font.FontSize = 22;
            rng.Style.Font.FontName = "Tahoma";
            rng.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            rng.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rng.Style.Border.RightBorder = XLBorderStyleValues.Medium;
        }

        public static void FormatTeamCell(IXLWorksheet worksheet, string range)
        {
            var rng = worksheet.Range(range);
            rng.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rng.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 0);
            rng.Style.Font.FontSize = 22;
            rng.Style.Font.FontName = "Tahoma";
            rng.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            rng.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rng.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rng.DataType = XLDataType.Text;
            //rng.Style.
        }

        public static void FormatRefereeCell(IXLWorksheet worksheet, string range)
        {
            var rng = worksheet.Range(range);
            rng.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rng.Style.Fill.BackgroundColor = XLColor.FromArgb(146, 208, 80);
            rng.Style.Font.FontSize = 22;
            rng.Style.Font.FontName = "Tahoma";
            rng.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            rng.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rng.Style.Border.RightBorder = XLBorderStyleValues.Medium;
        }

        private static IXLWorksheet GenerateNewWorksheet(XLWorkbook workbook, BE.Categoria categoriaActual, int nroFecha)
        {
            var worksheet = workbook.Worksheets.Add(categoriaActual.Descripcion);

            worksheet.Cell("A1").Value = "ASOCIACION DEL FUTBOL ARGENTINO";
            worksheet.Cell("A3").Value = "DIRECCION NACIONAL DE ARBITRAJE";
            worksheet.Cell("A5").Value = "DEPARTAMENTO DE FUTSAL Y F. PLAYA";
            worksheet.Cell("A7").Value = "PLANILLA DE DESIGNACIONES";
            worksheet.Cell("A9").Value = "FECHA " + nroFecha + " - " + categoriaActual.Descripcion;

            worksheet.Cell("A11").Value = "N°";
            worksheet.Cell("B11").Value = "EQUIPOS";
            worksheet.Cell("C11").Value = "EQUIPOS";
            worksheet.Cell("D11").Value = "ARBITRO PPAL.";
            worksheet.Cell("E11").Value = "2° ARBITRO";
            //worksheet.Cell("F11").Value = "CRONO";
            //worksheet.Cell("G11").Value = "SUPLENTES";

            //Titulo 1//
            var rngTitle1 = worksheet.Range("A1");
            rngTitle1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rngTitle1.Style.Font.Bold = true;
            rngTitle1.Style.Font.Underline = XLFontUnderlineValues.Single;
            rngTitle1.Style.Font.FontSize = 36;
            rngTitle1.Style.Font.FontName = "Tahoma";
            //Titulo 1//

            //Titulo 2//
            var rngTitle2 = worksheet.Range("A3");
            rngTitle2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rngTitle2.Style.Font.Bold = true;
            rngTitle2.Style.Font.Underline = XLFontUnderlineValues.Single;
            rngTitle2.Style.Font.FontSize = 28;
            rngTitle2.Style.Font.FontName = "Tahoma";
            //Titulo 2//

            //Titulo 3//
            var rngTitle3 = worksheet.Range("A5");
            rngTitle3.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rngTitle3.Style.Font.Bold = true;
            rngTitle3.Style.Font.Underline = XLFontUnderlineValues.Single;
            rngTitle3.Style.Font.FontSize = 20;
            rngTitle3.Style.Font.FontName = "Tahoma";
            rngTitle3.Style.Font.FontColor = XLColor.FromArgb(47, 117, 181);
            //Titulo 3//

            //Titulo 4//
            var rngTitle4 = worksheet.Range("A7");
            rngTitle4.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
            rngTitle4.Style.Font.Bold = true;
            rngTitle4.Style.Font.Underline = XLFontUnderlineValues.Single;
            rngTitle4.Style.Font.FontSize = 18;
            rngTitle4.Style.Font.FontName = "Tahoma";
            rngTitle4.Style.Font.FontColor = XLColor.FromArgb(0, 32, 96);
            //Titulo 4//

            //Fecha y Categoría//
            var rngDateAndCategory = worksheet.Range("A9:E9");
            rngDateAndCategory.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngDateAndCategory.Style.Font.Bold = true;
            rngDateAndCategory.Style.Fill.BackgroundColor = XLColor.FromArgb(142, 169, 219);
            rngDateAndCategory.Style.Font.FontSize = 24;
            rngDateAndCategory.Style.Font.FontName = "Tahoma";
            rngDateAndCategory.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngDateAndCategory.Style.Border.TopBorder = XLBorderStyleValues.Medium;
            var rngFirst = worksheet.Range("A9");
            rngFirst.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            var rngLast = worksheet.Range("E9");
            rngLast.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            rngDateAndCategory.Merge();

            //Fecha y Categoría//

            //Header de la tabla//
            var rngHeaders = worksheet.Range("A11:E11");
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.FromArgb(217, 225, 242);
            rngHeaders.Style.Font.FontSize = 22;
            rngHeaders.Style.Font.FontName = "Tahoma";
            rngHeaders.Style.Border.BottomBorder = XLBorderStyleValues.Medium;
            rngHeaders.Style.Border.TopBorder = XLBorderStyleValues.Medium;
            rngHeaders.Style.Border.LeftBorder = XLBorderStyleValues.Medium;
            rngHeaders.Style.Border.RightBorder = XLBorderStyleValues.Medium;
            //Header de la tabla//
            return worksheet;
        }

        private static char GetNextLetter(char letter)
        {
            char nextLetter;

            if (letter == 'z')
                nextLetter = 'a';
            else if (letter == 'Z')
                nextLetter = 'A';

            else
                nextLetter = (char)(letter + 1);

            return nextLetter;
        }
    }
}
