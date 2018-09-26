using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WFazor;
using WFazorTest.Controllers;

namespace WFazorTest
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            WFazorEngine.Instance.Initialize(this, new AppRoute());
        }
    }
}
