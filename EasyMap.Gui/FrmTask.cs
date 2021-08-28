using EasyMap.Gui.Utils;
using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;

namespace EasyMap.Gui
{
    public partial class FrmTask<T> : Form
    {
        private readonly TextBoxStreamWriter _writer;

        public delegate void JobHandler(T param);

        #region Properties

        private Thread _thread;

        public JobHandler Job { get; set; }

        public bool CanCancel
        {
            get { return btnCancel.Enabled; }
            set { btnCancel.Enabled = value; }
        }

        public T Param { get; set; }

        #endregion

        #region Constructor(s)

        public FrmTask()
        {
            InitializeComponent();
            TopMost = UserSettings.AlwaysOnTop;
            _writer = new TextBoxStreamWriter(richTextBox1);

            System.Console.SetOut(_writer);
        }

        #endregion

        private void InternalBeginTask()
        {
            System.Threading.Thread.Sleep(1500);

            try
            {
                Job(Param);

                Invoke((MethodInvoker)delegate
                {
                    label1.Text = "Task Succeeded";
                    label2.Text = "";
                });
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"[ERR] {ex.Message}");

                Invoke((MethodInvoker)delegate
                {
                    label1.Text = "Task Failed";
                    label2.Text = "Please refer to the log below for troubleshooting";
                    label1.ForeColor = Color.Red;
                });
            }

            Invoke((MethodInvoker)delegate
            {
                CanCancel = true;
            });
        }

        private void FrmTask_Load(object sender, System.EventArgs e)
        {
            if (_thread != null)
            {
                throw new Exception("Cannot start the same dialog with a predefined task. Please consider using a new instance.");
            }

            _thread = new Thread(InternalBeginTask);
            _thread.Start();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!CanCancel)
            {
                MessageBox.Show("This task cannot be canceled till it is done.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _thread?.Join();
            _writer?.Dispose();
        }
    }
}
