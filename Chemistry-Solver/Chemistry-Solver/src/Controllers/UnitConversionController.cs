using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BSmith.ChemistrySolver.Controllers
{
    public partial class UnitConversionController : Form
    {
        private Models.UnitConversionModel model_;

        public UnitConversionController()
        {
            InitializeComponent();
            model_ = new Models.UnitConversionModel();
        }
   
    }
}
