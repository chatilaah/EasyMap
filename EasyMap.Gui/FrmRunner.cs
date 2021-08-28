using EasyMap.Gui.Utils;
using System.IO;
using System.Windows.Forms;

namespace EasyMap.Gui
{
    public partial class FrmRunner : Form
    {
        public string ExecutablePath { get { return textBox1.Text; } set { textBox1.Text = value; } }

        public string CommandLineArgs { get { return textBox2.Text; } set { textBox2.Text = value; } }

        #region Constructor(s)
        public FrmRunner()
        {
            InitializeComponent();
            TopMost = UserSettings.AlwaysOnTop;
        }

        #endregion

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void FrmRunner_Load(object sender, System.EventArgs e)
        {
            textBox1.ReadOnly = !string.IsNullOrEmpty(ExecutablePath);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(ExecutablePath))
            {
                MessageBox.Show("Please specify the executable path!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!File.Exists(ExecutablePath))
            {
                MessageBox.Show("The specified executable does not exist on disk!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!ExecutablePath.ToLower().EndsWith(".exe"))
            {
                MessageBox.Show("The specified file is not a Windows executable file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var proc = System.Diagnostics.Process.Start(ExecutablePath, CommandLineArgs);
            
            if (checkBox1.Checked)
            {
                proc.WaitForExit();
            }

            Close();
        }
    }
}
