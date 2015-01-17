using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFloor.ModernUI.App.Infrastructure
{
    public interface IDialog
    {        
        string Title { get; }
        object DialogResult { get; }
    }
}