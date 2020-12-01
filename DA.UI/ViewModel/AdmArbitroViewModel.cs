﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using DA.BE;
using DA.SS;
using DA.UI.ABM;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class AdmArbitroViewModel : ViewModelBaseLocal
    {
        private bool _busyIndicator;


        public bool BusyIndicator
        {
            get => _busyIndicator;
            set => SetProperty(ref _busyIndicator, value);
        }

        AmArbitro viewModelAmArbitro = new AmArbitro()
        {
            DataContext = new AmArbitroViewModel()
        };

        public AdmArbitroViewModel()
        { 
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += (o, ea) =>
            {
                CargaGrillaArbitro();

                GoToNextPageCommand = new RelayCommand(a => ColeccionArbitro.GoToNextPage());
                GoToPreviousPageCommand = new RelayCommand(a => ColeccionArbitro.GoToPreviousPage());
                CleanCommand = new RelayCommand(ExecuteCleanCommand);
                RunAltaArbitro = new RelayCommand(ExecuteRunAltaArbitro);
                RunEditarArbitro = new RelayCommand(ExecuteRunEditarArbitro);
                RunGuardarArbitro = new RelayCommand(ExecuteRunGuardarArbitro);
                RunEliminarArbitro = new RelayCommand(ExecuteRunEliminarArbitro);

            };
            worker.RunWorkerCompleted += (o, ea) =>
            {

                BusyIndicator = false;
              
            };
       
            BusyIndicator = true;
            worker.RunWorkerAsync();



            //((AmArbitroViewModel)view.DataContext).CargarComboDeportes();
            //((AmArbitroViewModel)view.DataContext).CargarComboNivel();
        }

        private async void ExecuteRunEliminarArbitro(object obj)
        {
            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            Mensaje vieMensaje = null;
     

            if (ArbitroSeleccionado != null)
            {
                
                MensajeConsulta mensajeConsulta = new MensajeConsulta();

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");
            
                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                    {

                        Resultado resultado = bllArbitro.Quitar(ArbitroSeleccionado);

                        if (resultado.HayError == false)
                        {
                            vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Baja de Arbitro",
                                "Se elimino el Arbitro seleccionado");
                        }
                        else
                            vieMensaje = new Mensaje(TipoMensaje.ERROR, "Baja de Arbitro",
                                "El Arbitro no pudo ser eliminado");

                        Limpiar();
                        CargaGrillaArbitro();
                    } 
                    break;

                }

            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar Arbitro", "Debe seleccionar un Arbitro");


            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }
        }

        private async void ExecuteRunGuardarArbitro(object obj)
        {

            BLL.Arbitro bllArbitro = new BLL.Arbitro();
            Mensaje vieMensaje = null;
     

            if (ArbitroSeleccionado != null)
            {
                
                MensajeConsulta mensajeConsulta = new MensajeConsulta();

                object resultadoConsulta = await DialogHost.Show(mensajeConsulta, "dhMensajes");
            
                Respuesta respuesta = (Respuesta)(resultadoConsulta ?? Respuesta.Nada);
                switch (respuesta)
                {
                    case Respuesta.Si:
                        Resultado resultado = null;
                        foreach (Arbitro arbitro in Arbitros)
                        {
                            resultado = bllArbitro.Editar(arbitro);
                        }
                        

                        if (resultado.HayError == false)
                        {
                            vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Edición de Arbitro", "Se editó el Arbitro seleccionado");
                            Limpiar();
                            CargaGrillaArbitro();
                        }
                        else
                        { 
                            vieMensaje = new Mensaje(TipoMensaje.ERROR, "Edición de Arbitro", resultado.Descripcion);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Eliminar Arbitro", "Debe seleccionar un Arbitro");

            if (vieMensaje != null)
            {
                var resul = await DialogHost.Show(vieMensaje, "dhMensajes");
            }




        }

        private void CargaGrillaArbitro()
        {
            ColeccionArbitro = null;
            BLL.Arbitro blllArbitro = new BLL.Arbitro();

            Arbitros = blllArbitro.ObtenerArbitrosReducido();

            ColeccionArbitro = new SortablePageableCollection<BE.Arbitro>(Arbitros);
        }

        private async void ExecuteRunAltaArbitro(object obj)
        {


            //AmArbitroViewModel viewModel = (AmArbitroViewModel)view.DataContext;

            AmArbitroViewModel viewModel = (AmArbitroViewModel)viewModelAmArbitro.DataContext;

            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Id = 0;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Nombre = string.Empty;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Apellido = string.Empty;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Ranking = 0;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).AniosExperiencia = 0;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).NotaAFA = 0;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Genero = string.Empty;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).DNI = string.Empty;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Activo = true;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).FechaNacimiento = DateTime.Now;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).TituloValidoArgentina = false;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).LicenciaInternacional = false;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).ExamenTeorico = false;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).ExamenFisico = false;

            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Nivel = null;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Deporte = null;

            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Visibilidad = Visibility.Visible;
            ((AmArbitroViewModel)viewModelAmArbitro.DataContext).Titulo = "Alta de Arbitro";

            await DialogHost.Show(viewModelAmArbitro, "RootDialog");

            Mensaje vieMensaje = null;

            if (viewModel.SeCancelo == false)
            {
                if (viewModel.SeGuardo)
                {
                    Limpiar();
                    CargaGrillaArbitro();
                    vieMensaje = new Mensaje(viewModel.TipoMensaje, "Alta de Árbitro",
                        "Se dio de alta el árbitro");
                }
                else
                {
                    vieMensaje = new Mensaje(viewModel.TipoMensaje, "Alta de Árbitro",
                        viewModel.ResultadoAltaModificacion.Descripcion);
                }
            }

            if (vieMensaje != null)
            {
               await DialogHost.Show(vieMensaje, "dhMensajes");
            }

        }

        private async void ExecuteRunEditarArbitro(object obj)
        {
            Mensaje vieMensaje = null;

            AmArbitro frmAmArbitro = new AmArbitro();

            if (ArbitroSeleccionado != null)
            {
                AmArbitroViewModel viewModelAmArbitro = new AmArbitroViewModel();

                

                viewModelAmArbitro.Titulo = "Editar Árbitro";
                viewModelAmArbitro.ArbitroSeleccionado = ArbitroSeleccionado;
        
                viewModelAmArbitro.Id = ArbitroSeleccionado.Id;
                viewModelAmArbitro.Nombre = ArbitroSeleccionado.Nombre;
                viewModelAmArbitro.Apellido = ArbitroSeleccionado.Apellido;
                viewModelAmArbitro.Ranking = ArbitroSeleccionado.Ranking;
                viewModelAmArbitro.AniosExperiencia = ArbitroSeleccionado.AniosExperiencia;
                viewModelAmArbitro.NotaAFA = ArbitroSeleccionado.NotaAFA;
                viewModelAmArbitro.LicenciaInternacional = ArbitroSeleccionado.LicenciaInternacional;
                viewModelAmArbitro.Genero = ArbitroSeleccionado.Genero;
                viewModelAmArbitro.DNI = ArbitroSeleccionado.DNI;
                viewModelAmArbitro.Activo = ArbitroSeleccionado.Estado;
                viewModelAmArbitro.FechaNacimiento = ArbitroSeleccionado.FechaNacimiento;

                viewModelAmArbitro.TituloValidoArgentina = ArbitroSeleccionado.TituloValidoArgentina;
                viewModelAmArbitro.ExamenTeorico = ArbitroSeleccionado.ExamenTeorico;
                viewModelAmArbitro.ExamenFisico = ArbitroSeleccionado.ExamenFisico;

                viewModelAmArbitro.CargarComboDeportes();
                viewModelAmArbitro.Deporte = ArbitroSeleccionado.Deporte;
                viewModelAmArbitro.Habilitado = true;
                viewModelAmArbitro.CargarComboNivel(ArbitroSeleccionado.Deporte.Id);
                viewModelAmArbitro.Nivel = ArbitroSeleccionado.Nivel;
                viewModelAmArbitro.Visibilidad = Visibility.Visible;

                viewModelAmArbitro.Editar = true;

                frmAmArbitro.DataContext = viewModelAmArbitro;

                //show the dialog
                var result = await DialogHost.Show(frmAmArbitro, "RootDialog");

                if (viewModelAmArbitro.SeCancelo == false)
                {
                    if (viewModelAmArbitro.SeGuardo)
                    {
                        Limpiar();
                        CargaGrillaArbitro();
                        vieMensaje = new Mensaje(viewModelAmArbitro.TipoMensaje, "Edición de Arbitro",
                            "Se editó el Arbitro seleccionado");
                    }
                    else
                    {
                        vieMensaje = new Mensaje(viewModelAmArbitro.TipoMensaje, "Edición de Arbitro",
                            "El Arbitro no pudo ser editado");
                    }
                }

            }
            else
                vieMensaje = new Mensaje(TipoMensaje.NORMAL, "Editar Arbitro", "Debe seleccionar un Arbitro");

            if (vieMensaje != null)
            {
                var result = await DialogHost.Show(vieMensaje, "dhMensajes");
            }


        }

        #region Propiedades

        private SortablePageableCollection<BE.Arbitro> _coleccionArbitro;

        public SortablePageableCollection<BE.Arbitro> ColeccionArbitro
        {
            get
            {
                return _coleccionArbitro;
            }
            set
            {
                if (_coleccionArbitro != value)
                {
                    _coleccionArbitro = value;
                    SendPropertyChanged(() => ColeccionArbitro);
                }
            }
        }

        private List<BE.Arbitro> _arbitros;

        public List<BE.Arbitro> Arbitros
        {
            get => _arbitros;
            set => SetProperty(ref _arbitros, value);
        }

        private BE.Arbitro _arbitroSeleccionado;

        public BE.Arbitro ArbitroSeleccionado
        {
            get => _arbitroSeleccionado;
            set => SetProperty(ref _arbitroSeleccionado, value);
        }
        
        public List<int> EntriesPerPageList
        {
            get
            {
                return new List<int>() { 5, 10, 15, 20 };
            }
        }
       
        #endregion

        #region Commands

        public ICommand GoToNextPageCommand { get; private set; }

        public ICommand GoToPreviousPageCommand { get; private set; }

        public ICommand CleanCommand { get; private set; }

        public ICommand RunAltaArbitro { get; private set; }

        public ICommand RunEditarArbitro { get; private set; }

        public ICommand RunGuardarArbitro { get; private set; }
       
        public ICommand RunEliminarArbitro { get; private set; }


        #endregion


        public void ExecuteCleanCommand(object obj)
        {
           Limpiar();
      
        }

        private void Limpiar()
        {
            ArbitroSeleccionado = null;
            ColeccionArbitro = null;
        }

    }
}
