using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using DA.BE;
using DA.SS;
using DA.UI.DataGrid;
using MaterialDesignThemes.Wpf;

namespace DA.UI.ViewModel
{
    public class AmCalificacionViewModel : ViewModelBaseLocal
    {
        #region Variables

        private TipoMensaje _tipoMensaje;
        private int _dificultadPuntajePrincipal;
        private int _reglasPuntajePrincipal;
        private int _disciplinaPuntajePrincipal;
        private int _condicionPuntajePrincipal;
        private int _jugadasPuntajePrincipal;
        private int _dificultadPuntajeAsistente;
        private int _reglasPuntajeAsistente;
        private int _disciplinaPuntajeAsistente;
        private int _condicionPuntajeAsistente;
        private int _jugadasPuntajeAsistente;
        private Visibility _visibilidad;
        private Visibility _visibilidadPrincipal;
        private Visibility _visibilidadAsistente;
        private List<BE.Arbitro> _arbitros;
        private BE.Arbitro _arbitroSeleccionado;
        private bool _habilitado;

        #endregion

        #region Propiedades Binding

        public Visibility VisibilidadPrincipal
        {
            get => _visibilidadPrincipal;
            set => SetProperty(ref _visibilidadPrincipal, value);
        }

        public Visibility VisibilidadAsistente
        {
            get => _visibilidadAsistente;
            set => SetProperty(ref _visibilidadAsistente, value);
        }

        public bool Habilitado
        {
            get => _habilitado;
            set => SetProperty(ref _habilitado, value);
        }

        public TipoMensaje TipoMensaje
        {
            get => _tipoMensaje;
            set => SetProperty(ref _tipoMensaje, value);
        }

        public List<BE.Arbitro> Arbitros
        {
            get => _arbitros;
            set => SetProperty(ref _arbitros, value);
        }

        public BE.Arbitro ArbitroSeleccionado
        {
            get => _arbitroSeleccionado;
            set => SetProperty(ref _arbitroSeleccionado, value);
        }

        public Visibility Visibilidad
        {
            get => _visibilidad;
            set => SetProperty(ref _visibilidad, value);
        }

        public int DificultadPuntajePrincipal
        {
            get => _dificultadPuntajePrincipal;
            set => SetProperty(ref _dificultadPuntajePrincipal, value);
        }

        public int ReglasPuntajePrincipal
        {
            get => _reglasPuntajePrincipal;
            set => SetProperty(ref _reglasPuntajePrincipal, value);
        }

        public int DisciplinaPuntajePrincipal
        {
            get => _disciplinaPuntajePrincipal;
            set => SetProperty(ref _disciplinaPuntajePrincipal, value);
        }

        public int CondicionPuntajePrincipal
        {
            get => _condicionPuntajePrincipal;
            set => SetProperty(ref _condicionPuntajePrincipal, value);
        }

        public int JugadasPuntajePrincipal
        {
            get => _jugadasPuntajePrincipal;
            set => SetProperty(ref _jugadasPuntajePrincipal, value);
        }

        public int DificultadPuntajeAsistente
        {
            get => _dificultadPuntajeAsistente;
            set => SetProperty(ref _dificultadPuntajeAsistente, value);
        }

        public int ReglasPuntajeAsistente
        {
            get => _reglasPuntajeAsistente;
            set => SetProperty(ref _reglasPuntajeAsistente, value);
        }

        public int DisciplinaPuntajeAsistente
        {
            get => _disciplinaPuntajeAsistente;
            set => SetProperty(ref _disciplinaPuntajeAsistente, value);
        }

        public int CondicionPuntajeAsistente
        {
            get => _condicionPuntajeAsistente;
            set => SetProperty(ref _condicionPuntajeAsistente, value);
        }

        public int JugadasPuntajeAsistente
        {
            get => _jugadasPuntajeAsistente;
            set => SetProperty(ref _jugadasPuntajeAsistente, value);
        }

        #endregion

        #region Propiedades

        public BE.Calificacion CalifTemporalPrincipal { get; set; }
        
        public BE.Calificacion CalifTemporalAsistente { get; set; }
        
        public BE.Partido Partido { get; set; }

        public bool SeGuardo { get;  set; }
       
        public Resultado ResultadoAltaModificacion { get;  set; }

        public bool SeCancelo { get;  set; }

        public bool Editar { get;  set; }

        public BE.Arbitro ArbitroAnterior { get; set; }

        #endregion

        #region Commands

        public ICommand RunGuardar { get; }

        public ICommand RunCancelar { get; }

        public ICommand SelectedItemChangedCommand { get; private set; }

        #endregion

        public AmCalificacionViewModel(BE.Partido partido)
        {
            Visibilidad = Visibility.Collapsed;
            VisibilidadPrincipal = Visibility.Collapsed;
            VisibilidadAsistente = Visibility.Collapsed;
            Habilitado = false;
            Partido = partido;
            Arbitros = new List<Arbitro>();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                foreach (KeyValuePair<Arbitro, TipoArbitro> arbitroYTipo in Partido.ArbitrosYTipos)
                {
                    arbitroYTipo.Key.NombreCompletoTipoArbitro += arbitroYTipo.Key.ObtenerNombreCompleto() + " - " +arbitroYTipo.Value.Descripcion;
                    Arbitros.Add(arbitroYTipo.Key);

                    if (Partido.CalificacionesArbitros.Count != 0)
                    {
                        if (arbitroYTipo.Value.Descripcion.Equals("Principal"))
                            CalifTemporalPrincipal = Partido.CalificacionesArbitros.FirstOrDefault(x => ((BE.TipoArbitro) x.Key).Descripcion == "Principal").Value;
                        else
                            CalifTemporalAsistente = Partido.CalificacionesArbitros.FirstOrDefault(x => ((BE.TipoArbitro) x.Key).Descripcion == "Asistente").Value;

                        ReglasPuntajePrincipal = CalifTemporalPrincipal.ReglasPuntaje;
                        CondicionPuntajePrincipal = CalifTemporalPrincipal.CondicionFisicaPuntaje;
                        DisciplinaPuntajePrincipal = CalifTemporalPrincipal.DisciplinaPuntaje;
                        JugadasPuntajePrincipal = CalifTemporalPrincipal.JugadasPuntaje;
            
                        switch (CalifTemporalPrincipal.DificultadPartidoPuntaje)
                        {
                            case 0D:
                                DificultadPuntajePrincipal = 1;
                                break;

                            case 0.25D:
                                DificultadPuntajePrincipal = 2;
                                break;

                            case 0.50D:
                                DificultadPuntajePrincipal = 3;
                                break;

                            case 0.75D:
                                DificultadPuntajePrincipal = 4;
                                break;
                        }

                        ReglasPuntajeAsistente = CalifTemporalAsistente.ReglasPuntaje;
                        CondicionPuntajeAsistente = CalifTemporalAsistente.CondicionFisicaPuntaje;
                        DisciplinaPuntajeAsistente = CalifTemporalAsistente.DisciplinaPuntaje;
                        JugadasPuntajeAsistente = CalifTemporalAsistente.JugadasPuntaje;
            
                        switch (CalifTemporalAsistente.DificultadPartidoPuntaje)
                        {
                            case 0D:
                                DificultadPuntajeAsistente = 1;
                                break;

                            case 0.25D:
                                DificultadPuntajeAsistente = 2;
                                break;

                            case 0.50D:
                                DificultadPuntajeAsistente = 3;
                                break;

                            case 0.75D:
                                DificultadPuntajeAsistente = 4;
                                break;
                        }
                    }
                    else
                    {
                        ReglasPuntajePrincipal = 1;
                        CondicionPuntajePrincipal = 1;
                        DisciplinaPuntajePrincipal = 1;
                        JugadasPuntajePrincipal = 1;
                        DificultadPuntajePrincipal = 1;

                        ReglasPuntajeAsistente = 1;
                        CondicionPuntajeAsistente = 1;
                        DisciplinaPuntajeAsistente = 1;
                        JugadasPuntajeAsistente = 1;
                        DificultadPuntajeAsistente = 1;
                    }

                }
            }
            
            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunCancelar = new RelayCommand(ExecuteRunCancelar);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);
 

        }

        public AmCalificacionViewModel()
        {
            
            RunGuardar = new RelayCommand(ExecuteRunGuardar);
            RunCancelar = new RelayCommand(ExecuteRunCancelar);
            SelectedItemChangedCommand = new RelayCommand(ExecuteSelectedItemChangedCommand);

        }
        
        private void ExecuteSelectedItemChangedCommand(object obj)
        {
            if (ArbitroSeleccionado != null )
            {

                BE.TipoArbitro tipoArbitroSelec = Partido.ArbitrosYTipos
                    .FirstOrDefault(x => ((BE.Arbitro) x.Key).Id == ArbitroSeleccionado.Id).Value;

                if (tipoArbitroSelec.Descripcion.Equals("Principal"))
                {
                    VisibilidadAsistente = Visibility.Collapsed;
                    VisibilidadPrincipal = Visibility.Visible;
                }
                else
                {
                    VisibilidadAsistente = Visibility.Visible;
                    VisibilidadPrincipal = Visibility.Collapsed;
                }

                  
            }
                

            Visibilidad = Visibility.Visible;
            Habilitado = true;
        }
           
        private async void ExecuteRunGuardar(object obj)
        {

            BLL.Calificacion bllCalificacion = new BLL.Calificacion();
          
            BE.Arbitro arbitro = Arbitros.FirstOrDefault(x => (x.NombreCompletoTipoArbitro.Contains("Principal")));
            BE.TipoArbitro tipoArbitroSelec = Partido.ArbitrosYTipos.FirstOrDefault(x => arbitro != null && ((BE.Arbitro) x.Key).Id == arbitro.Id).Value;
            BE.Calificacion cal = new Calificacion
            {
                DisciplinaPuntaje = DisciplinaPuntajePrincipal,
                CondicionFisicaPuntaje = CondicionPuntajePrincipal,
                JugadasPuntaje = JugadasPuntajePrincipal,
                ReglasPuntaje = ReglasPuntajePrincipal
            };


            switch (DificultadPuntajePrincipal)
            {
                case 1:
                    cal.DificultadPartidoPuntaje = 0;
                    break;

                case 2:
                    cal.DificultadPartidoPuntaje = 0.25D;
                    break;

                case 3:
                    cal.DificultadPartidoPuntaje = 0.5D;
                    break;

                case 4:
                    cal.DificultadPartidoPuntaje = 0.75D;
                    break;
            }

            if (arbitro != null)
                ResultadoAltaModificacion =
                    bllCalificacion.Agregar(cal, Partido, arbitro.Id, tipoArbitroSelec.Id);

            arbitro = Arbitros.FirstOrDefault(x => (x.NombreCompletoTipoArbitro.Contains("Asistente")));
             tipoArbitroSelec = Partido.ArbitrosYTipos.FirstOrDefault(x => arbitro != null && ((BE.Arbitro) x.Key).Id == arbitro.Id).Value;

            cal.DisciplinaPuntaje = DisciplinaPuntajeAsistente;
            cal.CondicionFisicaPuntaje = CondicionPuntajeAsistente;
            cal.JugadasPuntaje = JugadasPuntajeAsistente;
            cal.ReglasPuntaje = ReglasPuntajeAsistente;

            switch (DificultadPuntajeAsistente)
            {
                case 1:
                    cal.DificultadPartidoPuntaje = 0;
                    break;

                case 2:
                    cal.DificultadPartidoPuntaje = 0.25D;
                    break;

                case 3:
                    cal.DificultadPartidoPuntaje = 0.5D;
                    break;

                case 4:
                    cal.DificultadPartidoPuntaje = 0.75D;
                    break;
            }

            if (arbitro != null)
                ResultadoAltaModificacion =
                    bllCalificacion.Agregar(cal, Partido, arbitro.Id, tipoArbitroSelec.Id);


            SeGuardo = !ResultadoAltaModificacion.HayError;
            this.TipoMensaje = ResultadoAltaModificacion.HayError == false ? TipoMensaje.CORRECTO : TipoMensaje.ERROR;
   
            if (SeGuardo)
            {

                var vieMensaje = new Mensaje(TipoMensaje.CORRECTO, "Calificación", "La calificación se guardó con éxito");

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");
                }


            }
            else
            {
                var vieMensaje = new Mensaje(TipoMensaje.ERROR, ResultadoAltaModificacion.Titulo, ResultadoAltaModificacion.Descripcion);

                if (vieMensaje != null)
                {
                    var result = await DialogHost.Show(vieMensaje, "dhMensajes");

                    DialogHost.CloseDialogCommand.Execute(null, vieMensaje);
                }
            }


        }

        private void ExecuteRunCancelar(object obj)
        {
            SeCancelo = true;

            DialogHost.CloseDialogCommand.Execute(null,null);

        }


    }
}
