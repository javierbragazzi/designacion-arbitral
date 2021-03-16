namespace DA.UI.ViewModel
{
    using DA.BLL;
    using DA.SS;
    using DA.UI.DataGrid;
    using DA.UI.Principales.Designacion;
    using GemBox.Spreadsheet;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;
    using System.Windows.Input;
    using Arbitro = DA.BE.Arbitro;
    using SelectionType = GemBox.Spreadsheet.SelectionType;
    using TipoArbitro = DA.BE.TipoArbitro;

    /// <summary>
    /// Defines the <see cref="Pagina4ControlViewModel" />.
    /// </summary>
    public class Pagina4ControlViewModel : ViewModelBaseLocal, ITransitionerViewModel
    {
        #region Fields

        /// <summary>
        /// Defines the _busyExportar.
        /// </summary>
        private bool _busyExportar;

        /// <summary>
        /// Defines the _exportoExcel.
        /// </summary>
        private bool _exportoExcel;

        /// <summary>
        /// Defines the _partidosDesignados.
        /// </summary>
        private List<PartidoHelperUI> _partidosDesignados;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Pagina4ControlViewModel"/> class.
        /// </summary>
        public Pagina4ControlViewModel()
        {
            FechasDisponibles = new List<BE.Fecha>();
            RunExportarPdfCommand = new RelayCommand(ExecuteRunExportarPDF);
            RunExportarExcelCommand = new RelayCommand(ExecuteRunExportarExcel);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether BusyExportar.
        /// </summary>
        public bool BusyExportar { get => _busyExportar; set => SetProperty(ref _busyExportar, value); }

        /// <summary>
        /// Gets or sets the FechasDisponibles.
        /// </summary>
        public List<BE.Fecha> FechasDisponibles { get; set; }

        /// <summary>
        /// Gets the RunExportarExcelCommand.
        /// </summary>
        public ICommand RunExportarExcelCommand { get; private set; }

        /// <summary>
        /// Gets the RunExportarPdfCommand.
        /// </summary>
        public ICommand RunExportarPdfCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The Hidden.
        /// </summary>
        /// <param name="newViewModel">The newViewModel<see cref="ITransitionerViewModel"/>.</param>
        public void Hidden(ITransitionerViewModel newViewModel)
        {
        }

        /// <summary>
        /// The Shown.
        /// </summary>
        /// <param name="previousViewModel">The previousViewModel<see cref="ITransitionerViewModel"/>.</param>
        public void Shown(ITransitionerViewModel previousViewModel)
        {
            Pagina3ControlViewModel pag3Vm = (Pagina3ControlViewModel)previousViewModel;

            FechasDisponibles = pag3Vm.FechasDisponibles;

            _partidosDesignados = pag3Vm.PartidosDesignados;

            _exportoExcel = false;

            GuardarDesignacion();
        }

        /// <summary>
        /// The ExcelToPdf.
        /// </summary>
        /// <param name="rutaExcel">The rutaExcel<see cref="string"/>.</param>
        private void ExcelToPdf(string rutaExcel)
        {
        }

        /// <summary>
        /// The ExecuteRunExportarExcel.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
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

        /// <summary>
        /// The ExecuteRunExportarPDF.
        /// </summary>
        /// <param name="obj">The obj<see cref="object"/>.</param>
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

        /// <summary>
        /// The ExportarAPdf.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
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

        /// <summary>
        /// The GuardarDesignacion.
        /// </summary>
        private void GuardarDesignacion()
        {
            BLL.PartidoArbitro bllPartidoArbitro = new PartidoArbitro();
            BLL.Fecha bllFecha = new Fecha();

            foreach (PartidoHelperUI designado in _partidosDesignados)
            {
                BE.PartidoArbitro partidoArbitro = new BE.PartidoArbitro();
                partidoArbitro.Partido = designado.ConvertirAPartido();
                foreach (KeyValuePair<Arbitro, TipoArbitro> designadoArbitrosYTipo in designado.ArbitrosYTipos)
                {
                    partidoArbitro.Arbitro = designadoArbitrosYTipo.Key;
                    partidoArbitro.TipoArbitro = designadoArbitrosYTipo.Value;
                    partidoArbitro.Procesado = false;
                    partidoArbitro.Calificacion = null;

                    bllPartidoArbitro.Agregar(partidoArbitro);
                }
                
            }

            foreach (BE.Fecha fechasDisponible in FechasDisponibles)
            {
                fechasDisponible.Designado = true;
                bllFecha.Editar(fechasDisponible);
            }
        }

        #endregion
    }
}
