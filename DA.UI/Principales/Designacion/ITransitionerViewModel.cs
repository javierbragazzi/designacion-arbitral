using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.UI.Principales.Designacion
{
    public interface ITransitionerViewModel
    {
        void Hidden(ITransitionerViewModel newViewModel);
        void Shown(ITransitionerViewModel previousViewModel);
    }
}
