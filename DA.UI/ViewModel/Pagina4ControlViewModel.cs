using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Windows.Input;
using DA.SS;
using DA.UI.DataGrid;
using DA.UI.Principales.Designacion;
using GemBox.Spreadsheet;
using MaterialDesignThemes.Wpf;
using SelectionType = GemBox.Spreadsheet.SelectionType;


namespace DA.UI.ViewModel
{
    public class Pagina4ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        private List<BE.Partido> _partidosDesignados;

        private bool _exportoExcel;

        private bool _busyExportar;

        public bool BusyExportar
        {
            get => _busyExportar;
            set => SetProperty(ref _busyExportar, value);
        }

        public ICommand RunExportarPdfCommand { get; private set; }
        
        public ICommand RunExportarExcelCommand { get; private set; }

        public Pagina4ControlViewModel()
        {
            RunExportarPdfCommand = new RelayCommand(ExecuteRunExportarPDF);
            RunExportarExcelCommand = new RelayCommand(ExecuteRunExportarExcel);
        }

        private async void ExecuteRunExportarPDF(object obj)
        {
            try
            {
                if (ExportarAPdf())
                {
                    var vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Exportar", "Se exporto la información a PDF");

                    if (vieMensaje != null)
                    {
                        var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                    }
                }

            }
            catch (Exception e)
            {
                var vieMensaje = new Mensaje(TipoMensaje.ERROR, "Exportar", "Ocurrió un error al exportar la información a PDF");

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                }

                Logger.Log.Error(e);
            }

        }

        private bool ExportarAPdf()
        {
            BackgroundWorker worker = new BackgroundWorker();
        
            string excelName = "Planilla de designaciones Fecha " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".pdf";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = excelName;
            saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                worker.DoWork += (o, ea) =>
                {

                    string rutaExcel = ExportToExcel.ExportFutsal(_partidosDesignados[0].Equipo1.Categoria,
                        _partidosDesignados[0].FechaDelCampeonato.Numero, _partidosDesignados,
                        Path.GetDirectoryName(saveFileDialog.FileName), Path.GetFileName(saveFileDialog.FileName));

                    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

                    var workbook = ExcelFile.Load(rutaExcel);

                    foreach (ExcelWorksheet worksheet in workbook.Worksheets)
                    {
                        worksheet.PrintOptions.FitWorksheetWidthToPages = 1;
                        worksheet.PrintOptions.FitWorksheetHeightToPages = 1;
                    }


                    string rutaPDF = rutaExcel.Replace(".xlsx", ".pdf");

                    workbook.Save(rutaPDF, new PdfSaveOptions()
                    {
                        SelectionType = SelectionType.EntireFile
                    });

                    if (!_exportoExcel)
                    {
                        File.Delete(rutaExcel);
                    }


                };
                worker.RunWorkerCompleted += (o, ea) => { BusyExportar = false; };

                BusyExportar = true;
                worker.RunWorkerAsync();
            }
            else
            {
                return false;
            }

            return true;

        }

        private async void ExecuteRunExportarExcel(object obj)
        {
            try
            {

                string excelName = "Planilla de designaciones Fecha " + DateTime.Now.ToShortDateString().Replace('/', '-') + ".xlsx";
               
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.FileName = excelName;
                saveFileDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaExcel = ExportToExcel.ExportFutsal(_partidosDesignados[0].Equipo1.Categoria,
                        _partidosDesignados[0].FechaDelCampeonato.Numero, _partidosDesignados,
                        Path.GetDirectoryName(saveFileDialog.FileName), Path.GetFileName(saveFileDialog.FileName));


                    _exportoExcel = true;

                    var vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Exportar", "Se exporto la información a Excel");

                    if (vieMensaje != null)
                    {
                        var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                    }
                }

            }
            catch (Exception e)
            {
                var vieMensaje = new Mensaje(TipoMensaje.ERROR, "Exportar", "Ocurrió un error al exportar la información a Excel");

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                }

                Logger.Log.Error(e);
            }

        }

        private void ExcelToPdf(string rutaExcel)
        {
            //Application app = new Application();
            //Workbook wkb = app.Workbooks.Open(rutaExcel);

            //string rutaPDF = rutaExcel.Replace(".xlsx", ".pdf");

            //wkb.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, rutaPDF);

            //Workbook workbook = new Workbook();

            //workbook.LoadFromFile(rutaExcel, ExcelVersion.Version2016);

            //string rutaPDF = rutaExcel.Replace(".xlsx", ".pdf");
  
            //workbook.SaveToFile(rutaPDF, Spire.Xls.FileFormat.PDF);


            //workbook.LoadFromFile(rutaExcel);

            //// Set PDF template
            //PdfDocument pdfDocument = new PdfDocument();
            //pdfDocument.PageSettings.Orientation = PdfPageOrientation.Landscape;
            //pdfDocument.PageSettings.Width = 970;
            //pdfDocument.PageSettings.Height = 850;
            
            ////Convert Excel to PDF using the template above
            //PdfConverter pdfConverter = new PdfConverter(workbook);
            //PdfConverterSettings settings = new PdfConverterSettings();
            //settings.TemplateDocument = pdfDocument;
            //pdfDocument = pdfConverter.Convert(settings);

            //string rutaPDF = rutaExcel.Replace(".xlsx", ".pdf");

            //// Save and preview PDF
            //pdfDocument.SaveToFile(rutaPDF);
            ////System.Diagnostics.Process.Start("sample.pdf");
        }

  
   
        public void Hidden(ITransitionerViewModel newViewModel)
        {
            
        }

        public void Shown(ITransitionerViewModel previousViewModel)
        {
            Pagina3ControlViewModel pag3Vm = (Pagina3ControlViewModel)previousViewModel;

            _partidosDesignados = pag3Vm.PartidosDesignados;
            
            _exportoExcel = false;
        }
    }
}
