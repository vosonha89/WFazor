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

namespace WFazorTest
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.wFazorBrowser1.RedirectTo("Index", "Home", null);
        }
    }
}
