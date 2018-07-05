using BusinessContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    [Export(typeof(IAcmeFlightAvailability))]
    public class AcmeFlightAvailability : IAcmeFlightAvailability
    {

    }
}
